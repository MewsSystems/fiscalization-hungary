using Mews.Fiscalization.Hungary.Models;
using Mews.Fiscalization.Hungary.Models.TaxPayer;
using Mews.Fiscalization.Hungary.Utils;
using System;
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

        public async Task<ResponseResult<ExchangeToken>> GetExchangeTokenAsync()
        {
            var request = new Dto.TokenExchangeRequest(GetMetadata());
            return await ProcessRequestAsync<Dto.TokenExchangeRequest, Dto.TokenExchangeResponse, ExchangeToken>("tokenExchange", request, response =>
            {
                var tokenBase64 = response.EncodedExchangeToken;
                var tokenData = Convert.FromBase64String(tokenBase64);
                var decryptedToken = Aes.Decrypt(TechnicalUser.EncryptionKey, tokenData);
                return new ResponseResult<ExchangeToken>(successResult: new ExchangeToken(
                    value: decryptedToken,
                    validFrom: response.TokenValidityFrom,
                    validTo: response.TokenValidityTo
                ));
            });
        }

        public async Task<ResponseResult<TaxPayerData>> GetTaxPayerDataAsync(string taxNumber)
        {
            var request = new Dto.QueryTaxpayerRequest(GetMetadata(), taxNumber);
            return await ProcessRequestAsync<Dto.QueryTaxpayerRequest, Dto.QueryTaxpayerResponse, TaxPayerData>("queryTaxpayer", request, response =>
            {
                if (response.IsValidTaxPayer)
                {
                    return new ResponseResult<TaxPayerData>(successResult: TaxPayerData.Map(response));
                }
                else
                {
                    return new ResponseResult<TaxPayerData>(errorResult: new ErrorResult("Invalid tax payer.", ResultErrorCode.InvalidTaxPayer));
                }
            });
        }

        private Dto.RequestMetadata GetMetadata(string additionalSignatureData = null)
        {
            return new Dto.RequestMetadata(TechnicalUser, SoftwareIdentification, additionalSignatureData);
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