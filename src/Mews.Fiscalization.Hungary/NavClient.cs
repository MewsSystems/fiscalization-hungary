using Mews.Fiscalization.Hungary.Models;
using Mews.Fiscalization.Hungary.Models.TaxPayer;
using Mews.Fiscalization.Hungary.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mews.Fiscalization.Hungary
{
    public sealed class NavClient
    {
        private TechnicalUser TechnicalUser { get; }

        private SoftwareIdentification SoftwareIdentification { get; }

        private static HttpClient HttpClient { get; }

        private NavEnvironment Environment { get; }

        static NavClient()
        {
            HttpClient = new HttpClient();
        }

        public NavClient(TechnicalUser technicalUser, SoftwareIdentification softwareIdentification, NavEnvironment environment)
        {
            TechnicalUser = technicalUser;
            SoftwareIdentification = softwareIdentification;
            Environment = environment;
        }

        public async Task<ResponseResult<string>> SendInvoicesAsync(ExchangeToken token, IEnumerable<InvoiceData> invoices)
        {
            // TODO: Handle additionalSignatureData
            var request = CreateRequest<Dto.ManageInvoiceRequest>();
            request.exchangeToken = Convert.ToBase64String(token.Value);
            request.invoiceOperations = new Dto.InvoiceOperationListType
            {
                compressedContent = false,
                invoiceOperation = MapToInvoiceOperation(invoices).ToArray()
            };

            return await ProcessRequestAsync<Dto.ManageInvoiceRequest, Dto.ManageInvoiceResponse, string>("manageInvoice", request, response =>
            {
                return new ResponseResult<string>(successResult: response.transactionId);
            });
        }

        private IEnumerable<Dto.InvoiceOperationType> MapToInvoiceOperation(IEnumerable<InvoiceData> invoices)
        {
            var operations = new List<Dto.InvoiceOperationType>();
            for (int i = 1; i <= invoices.Count(); ++i)
            {
                var invoice = invoices.ElementAt(i);
                operations.Add(new Dto.InvoiceOperationType
                {
                    index = i,
                    invoiceData = Encoding.UTF8.GetBytes(MapInvoiceData(invoice).ToString()), // TODO: invoice data serialized and then converted to base64.
                    invoiceOperation = Dto.ManageInvoiceOperationType.CREATE // For now, we will only support create operations.
                });
            }

            return operations;
        }

        private Dto.InvoiceData MapInvoiceData(InvoiceData invoice)
        {
            return new Dto.InvoiceData
            {
                invoiceIssueDate = invoice.InvoiceIssueDate,
                invoiceMain = new Dto.InvoiceMainType
                {
                    Items = new object[]
                    {
                        // TODO: fill in with Invoice items.
                    }
                },
                invoiceNumber = invoice.InvoiceNumber
            };
        }

        public async Task<ResponseResult<ExchangeToken>> GetExchangeTokenAsync()
        {
            var request = CreateRequest<Dto.TokenExchangeRequest>();
            return await ProcessRequestAsync<Dto.TokenExchangeRequest, Dto.TokenExchangeResponse, ExchangeToken>("tokenExchange", request, response =>
            {
                var decryptedToken = Aes.Decrypt(TechnicalUser.EncryptionKey, response.encodedExchangeToken);
                return new ResponseResult<ExchangeToken>(successResult: new ExchangeToken(
                    value: decryptedToken,
                    validFrom: response.tokenValidityFrom,
                    validTo: response.tokenValidityTo
                ));
            });
        }

        public async Task<ResponseResult<TaxPayerData>> GetTaxPayerDataAsync(string taxNumber)
        {
            var request = CreateRequest<Dto.QueryTaxpayerRequest>();
            request.taxNumber = taxNumber;
            return await ProcessRequestAsync<Dto.QueryTaxpayerRequest, Dto.QueryTaxpayerResponse, TaxPayerData>("queryTaxpayer", request, response =>
            {
                if (response.taxpayerValidity) // TODO - it's nullable
                {
                    return new ResponseResult<TaxPayerData>(successResult: TaxPayerData.Map(response));
                }
                else
                {
                    return new ResponseResult<TaxPayerData>(errorResult: new ErrorResult("Invalid tax payer.", ResultErrorCode.InvalidTaxPayer));
                }
            });
        }

        private T CreateRequest<T>(string additionalSignatureData = null)
            where T : Dto.BasicRequestType, new()
        {
            var requestId = RequestId.CreateRandom();
            var timestamp = DateTime.UtcNow;
            return new T
            {
                header = new Dto.BasicHeaderType
                {
                    requestId = requestId,
                    timestamp = timestamp.ToString("yyyy-MM-ddTHH:mm:ssZ"),
                    requestVersion = Dto.RequestVersionType.Item20,
                    headerVersion = Dto.HeaderVersionType.Item10
                },
                user = new Dto.UserHeaderType
                {
                    login = TechnicalUser.Login,
                    passwordHash = TechnicalUser.PasswordHash,
                    taxNumber = TechnicalUser.TaxNumber,
                    requestSignature = GetRequestSignature(TechnicalUser, requestId, timestamp, additionalSignatureData)
                },
                software = new Dto.SoftwareType
                {
                    softwareId = SoftwareIdentification.Id,
                    softwareName = SoftwareIdentification.Name,
                    softwareOperation = (Dto.SoftwareOperationType)SoftwareIdentification.Type,
                    softwareMainVersion = SoftwareIdentification.MainVersion,
                    softwareDevName = SoftwareIdentification.DeveloperName,
                    softwareDevContact = SoftwareIdentification.DeveloperContact,
                    softwareDevCountryCode = SoftwareIdentification.DeveloperCountry,
                    softwareDevTaxNumber = SoftwareIdentification.DeveloperTaxNumber
                }
            };
        }

        private string GetRequestSignature(TechnicalUser user, string requestId, DateTime timestamp, string additionalSignatureData = null)
        {
            var formattedTimestamp = timestamp.ToString("yyyyMMddHHmmss");
            var signatureData = $"{requestId}{formattedTimestamp}{user.XmlSigningKey}{additionalSignatureData}";
            return Sha512.GetSha3Hash(signatureData);
        }

        private async Task<ResponseResult<TResult>> ProcessRequestAsync<TRequest, TDto, TResult>(string endpoint, TRequest request, Func<TDto, ResponseResult<TResult>> successFunc)
            where TRequest : class
            where TDto : class
            where TResult : class
        {
            var httpResponse = await SendRequestAsync(endpoint, request);
            return await DeserializeAsync(httpResponse, successFunc);
        }

        private async Task<HttpResponseMessage> SendRequestAsync<TRequest>(string endpoint, TRequest request)
            where TRequest : class
        {
            var content = new StringContent(XmlManipulator.Serialize(request), Encoding.UTF8, "application/xml");
            var uri = new Uri(ServiceInfo.BaseUrls[Environment], $"{ServiceInfo.RelativeServiceUrl}{endpoint}");
            return await HttpClient.PostAsync(uri, content);
        }

        private async Task<ResponseResult<TResult>> DeserializeAsync<TDto, TResult>(HttpResponseMessage response, Func<TDto, ResponseResult<TResult>> successFunc)
            where TDto : class
            where TResult : class
        {
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return successFunc(XmlManipulator.Deserialize<TDto>(content));
            }
            else
            {
                var errorResult = XmlManipulator.Deserialize<Dto.GeneralErrorResponse>(content);
                return new ResponseResult<TResult>(errorResult: ErrorResult.Map(errorResult));
            }
        }
    }
}