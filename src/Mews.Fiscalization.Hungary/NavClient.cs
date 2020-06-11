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
            var response = await SendRequestAsync("tokenExchange", request);

            if (response.IsSuccessStatusCode)
            {
                var successResult = XmlManipulator.Deserialize<Dto.TokenExchangeResponse>(await response.Content.ReadAsStringAsync());
                var tokenBase64 = successResult.EncodedExchangeToken;
                var tokenData = Convert.FromBase64String(tokenBase64);
                var decryptedToken = Aes.Decrypt(TechnicalUser.EncryptionKey, tokenData);
                return new ResponseResult<ExchangeToken>(successResult: new ExchangeToken(
                    value: decryptedToken,
                    validFrom: successResult.TokenValidityFrom,
                    validTo: successResult.TokenValidityTo
                ));
            }
            else
            {
                var errorResult = XmlManipulator.Deserialize<Dto.GeneralErrorResponse>(await response.Content.ReadAsStringAsync());
                return new ResponseResult<ExchangeToken>(errorResult: ErrorResult.Map(errorResult));
            }
        }

        public async Task<ResponseResult<TaxPayerData>> GetTaxPayerDataAsync(string taxNumber)
        {
            var request = new Dto.QueryTaxpayerRequest(GetMetadata(), taxNumber);

            var response = await SendRequestAsync("queryTaxpayer", request);
            if (response.IsSuccessStatusCode)
            {
                var successResult = XmlManipulator.Deserialize<Dto.QueryTaxpayerResponse>(await response.Content.ReadAsStringAsync());
                
                if (successResult.IsValidTaxPayer)
                {
                    return new ResponseResult<TaxPayerData>(successResult: TaxPayerData.Map(successResult));
                }
                else
                {
                    return new ResponseResult<TaxPayerData>(errorResult: new ErrorResult("Invalid tax payer.", ResultErrorCode.InvalidTaxPayer));
                }
            }
            else
            {
                var errorResult = XmlManipulator.Deserialize<Dto.GeneralErrorResponse>(await response.Content.ReadAsStringAsync());
                return new ResponseResult<TaxPayerData>(errorResult: ErrorResult.Map(errorResult));
            }
        }

        private Dto.RequestMetadata GetMetadata(string additionalSignatureData = null)
        {
            return new Dto.RequestMetadata(TechnicalUser, SoftwareIdentification, additionalSignatureData);
        }

        private async Task<HttpResponseMessage> SendRequestAsync<TRequest>(string endpoint, TRequest request)
            where TRequest : class
        {
            var content = new StringContent(XmlManipulator.Serialize(request), Encoding.UTF8, "application/xml");
            var uri = new Uri(ServiceInfo.BaseUrls[Environment], $"{ServiceInfo.RelativeServiceUrl}{endpoint}");
            return await HttpClient.PostAsync(uri, content);
        }
    }
}