using Mews.Fiscalization.Hungary.Models;
using Mews.Fiscalization.Hungary.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mews.Fiscalization.Hungary
{
    internal static class RequestCreator
    {
        internal static Dto.TokenExchangeRequest CreateTokenExchangeRequest(TechnicalUser user, SoftwareIdentification software)
        {
            return CreateRequest<Dto.TokenExchangeRequest>(user, software);
        }

        internal static Dto.QueryTaxpayerRequest CreateQueryTaxpayerRequest(TechnicalUser user, SoftwareIdentification software, string taxNumber)
        {
            var request = CreateRequest<Dto.QueryTaxpayerRequest>(user, software);
            request.taxNumber = taxNumber;
            return request;
        }

        internal static Dto.ManageInvoiceRequest CreateManageInvoicesRequest(TechnicalUser user, SoftwareIdentification software, ExchangeToken token, IEnumerable<Invoice> invoiceData)
        {
            var operationTypes = invoiceData.Select((invoice, idx) => new Dto.InvoiceOperationType
            {
                index = idx + 1,
                invoiceData = Encoding.UTF8.GetBytes(XmlManipulator.Serialize(RequestMapper.MapInvoice(invoice))),
                invoiceOperation = Dto.ManageInvoiceOperationType.CREATE
            });
            var additionalSignatureData = operationTypes.Select(t => $"{t.invoiceOperation}{Convert.ToBase64String(t.invoiceData)}");
            var encodedAddtionalSignatureData = Sha512.GetSha3Hash(string.Join("", additionalSignatureData));

            var request = CreateRequest<Dto.ManageInvoiceRequest>(user, software, encodedAddtionalSignatureData);
            request.exchangeToken = Encoding.UTF8.GetString(token.Value);
            request.invoiceOperations = new Dto.InvoiceOperationListType
            {
                compressedContent = false,
                invoiceOperation = operationTypes.ToArray()
            };

            return request;
        }

        private static T CreateRequest<T>(TechnicalUser user, SoftwareIdentification software, string additionalSignatureData = null)
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
                    login = user.Login,
                    passwordHash = user.PasswordHash,
                    taxNumber = user.TaxNumber,
                    requestSignature = GetRequestSignature(user, requestId, timestamp, additionalSignatureData)
                },
                software = new Dto.SoftwareType
                {
                    softwareId = software.Id,
                    softwareName = software.Name,
                    softwareOperation = (Dto.SoftwareOperationType)software.Type,
                    softwareMainVersion = software.MainVersion,
                    softwareDevName = software.DeveloperName,
                    softwareDevContact = software.DeveloperContact,
                    softwareDevCountryCode = software.DeveloperCountry,
                    softwareDevTaxNumber = software.DeveloperTaxNumber
                }
            };
        }

        private static string GetRequestSignature(TechnicalUser user, string requestId, DateTime timestamp, string additionalSignatureData = null)
        {
            var formattedTimestamp = timestamp.ToString("yyyyMMddHHmmss");
            var signatureData = $"{requestId}{formattedTimestamp}{user.XmlSigningKey}{additionalSignatureData}";
            return Sha512.GetSha3Hash(signatureData);
        }
    }
}