using Mews.Fiscalization.Hungary.Models;
using Mews.Fiscalization.Hungary.Models.TaxPayer;
using Mews.Fiscalization.Hungary.Utils;

namespace Mews.Fiscalization.Hungary
{
    internal static class ModelMapper
    {
        internal static ResponseResult<ExchangeToken> MapExchangeToken(Dto.TokenExchangeResponse response, TechnicalUser user)
        {
            var decryptedToken = Aes.Decrypt(user.EncryptionKey, response.encodedExchangeToken);
            return new ResponseResult<ExchangeToken>(successResult: new ExchangeToken(
                value: decryptedToken,
                validFrom: response.tokenValidityFrom,
                validTo: response.tokenValidityTo
            ));
        }

        internal static ResponseResult<TaxPayerData> MapTaxPayerData(Dto.QueryTaxpayerResponse response)
        {
            if (response.taxpayerValidity) // TODO - it's nullable
            {
                return new ResponseResult<TaxPayerData>(successResult: TaxPayerData.Map(response));
            }
            else
            {
                return new ResponseResult<TaxPayerData>(errorResult: new ErrorResult("Invalid tax payer.", ResultErrorCode.InvalidTaxPayer));
            }
        }

        internal static ResponseResult<string> MapInvoices(Dto.ManageInvoiceResponse response)
        {
            return new ResponseResult<string>(successResult: response.transactionId);
        }
    }
}