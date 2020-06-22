using System;
using System.Collections.Generic;
using Mews.Fiscalization.Hungary.Models;
using Mews.Fiscalization.Hungary.Models.TaxPayer;
using Mews.Fiscalization.Hungary.Utils;
using System.Linq;

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
            if (response.taxpayerValidity)
            {
                var addressItem = response.taxpayerData.taxpayerAddressList.First();
                var taxPayerData = response.taxpayerData;
                var taxNumberDetail = taxPayerData.taxNumberDetail;
                return new ResponseResult<TaxPayerData>(successResult: new TaxPayerData(
                    id: taxNumberDetail.taxpayerId,
                    name: taxPayerData.taxpayerName,
                    address: MapAddress(addressItem),
                    vatCode: taxNumberDetail.vatCode,
                    infoDate: response.infoDate
                ));
            }
            else
            {
                return new ResponseResult<TaxPayerData>(errorResult: new ErrorResult(ResultErrorCode.InvalidTaxPayer));
            }
        }

        internal static ResponseResult<TransactionStatus> MapTransactionStatus(Dto.QueryTransactionStatusResponse response)
        {
            var result = response.processingResults;
            if (result?.processingResult == null)
            {
                return new ResponseResult<TransactionStatus>(errorResult: new ErrorResult(ResultErrorCode.InvalidId));
            }

            return new ResponseResult<TransactionStatus>(
                successResult: new TransactionStatus(
                    invoiceStatuses: result.processingResult.Select(r => InvoiceStatus.Map(r))
                )
            );
        }

        internal static ResponseResult<string> MapInvoices(Dto.ManageInvoiceResponse response)
        {
            return new ResponseResult<string>(successResult: response.transactionId);
        }

        private static Address MapAddress(Dto.TaxpayerAddressItemType addressItem)
        {
            var address = addressItem.taxpayerAddress;
            return new Address(
                countryCode: address.countryCode,
                postalCode: address.postalCode,
                city: address.city,
                streetName: address.streetName,
                number: address.number,
                floor: address.floor,
                door: address.door,
                type: MapAddressType(addressItem.taxpayerAddressType, nameof(addressItem.taxpayerAddress))
            );
        }

        private static AddressType MapAddressType(Dto.TaxpayerAddressTypeType type, string parameterName)
        {
            switch (type)
            {
                case Dto.TaxpayerAddressTypeType.HQ:
                    return AddressType.HQ;
                case Dto.TaxpayerAddressTypeType.SITE:
                    return AddressType.SITE;
                case Dto.TaxpayerAddressTypeType.BRANCH:
                    return AddressType.BRANCH;
                default:
                    throw new ArgumentOutOfRangeException(parameterName, type, "Unknown address type");
            }
        }
    }
}