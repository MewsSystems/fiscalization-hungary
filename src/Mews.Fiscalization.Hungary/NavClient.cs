using Mews.Fiscalization.Hungary.Models;
using Mews.Fiscalization.Hungary.Models.TaxPayer;
using Mews.Fiscalization.Hungary.Utils;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Mews.Fiscalization.Hungary
{
    public sealed class NavClient
    {
        private TechnicalUser TechnicalUser { get; }

        private SoftwareIdentification SoftwareIdentification { get; }

        private static HttpClient HttpClient { get; }

        private Client Client { get; }

        static NavClient()
        {
            HttpClient = new HttpClient();
        }

        public NavClient(TechnicalUser technicalUser, SoftwareIdentification softwareIdentification, NavEnvironment environment)
        {
            TechnicalUser = technicalUser;
            SoftwareIdentification = softwareIdentification;
            Client = new Client(HttpClient, environment);
        }

        public async Task<ResponseResult<ExchangeToken>> GetExchangeTokenAsync()
        {
            var request = RequestCreator.CreateTokenExchangeRequest(TechnicalUser, SoftwareIdentification);
            return await Client.ProcessRequestAsync<Dto.TokenExchangeRequest, Dto.TokenExchangeResponse, ExchangeToken>(
                endpoint: "tokenExchange",
                request: request,
                successFunc: response => ModelMapper.MapExchangeToken(response, TechnicalUser)
            );
        }

        public async Task<ResponseResult<TaxPayerData>> GetTaxPayerDataAsync(string taxNumber)
        {
            var request = RequestCreator.CreateQueryTaxpayerRequest(TechnicalUser, SoftwareIdentification, taxNumber);
            return await Client.ProcessRequestAsync<Dto.QueryTaxpayerRequest, Dto.QueryTaxpayerResponse, TaxPayerData>(
                endpoint: "queryTaxpayer",
                request: request,
                successFunc: response => ModelMapper.MapTaxPayerData(response)
            );
        }

        public async Task<ResponseResult<string>> SendInvoicesAsync(ExchangeToken token, IEnumerable<Invoice> invoices)
        {
            var request = RequestCreator.CreateManageInvoicesRequest(TechnicalUser, SoftwareIdentification, token, invoices);
            return await Client.ProcessRequestAsync<Dto.ManageInvoiceRequest, Dto.ManageInvoiceResponse, string>(
                endpoint: "manageInvoice",
                request: request,
                successFunc: response => ModelMapper.MapInvoices(response)
            );
        }
    }
}