using Mews.Fiscalization.Hungary.Models;
using Mews.Fiscalization.Hungary.Models.TaxPayer;
using Mews.Fiscalization.Hungary.Utils;
using System.Collections.Generic;
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

        internal static IEnumerable<Dto.LineType> MapItems(IEnumerable<Item> items)
        {
            return items.Select(i => new Dto.LineType
            {
                lineNumber = i.Number,
                lineDescription = i.Description,
                lineExpressionIndicator = false,
                quantity = i.Quantity,
                unitPrice = i.UnitPrice,
                Item = new Dto.LineAmountsSimplifiedType
                {
                    lineGrossAmountSimplified = i.GrossAmount,
                    lineGrossAmountSimplifiedHUF = i.GrossAmountHUF
                },
                lineDiscountData = new Dto.DiscountDataType
                {
                    discountDescription = i.DiscountDescription,
                    discountValue = i.DiscountValue
                },
                productCodes = new Dto.ProductCodeType[]
                {
                    new Dto.ProductCodeType
                    {
                        productCodeCategory = (Dto.ProductCodeCategoryType)i.ProductCodeCategory,
                        ItemElementName = (Dto.ItemChoiceType)i.ProductCodeChoiceType,
                        Item = i.ProductCode
                    }
                },
            });
        }

        internal static Dto.InvoiceData Map(Invoice invoice)
        {
            var companyInfo = invoice.CompanyInfo;
            var customerInfo = invoice.CustomerInfo;
            var customerAddress = invoice.CustomerInfo.Address;
            var companyAddress = companyInfo.Address;
            return new Dto.InvoiceData
            {
                invoiceIssueDate = invoice.IssueDate,
                invoiceNumber = invoice.Number,
                invoiceMain = new Dto.InvoiceMainType
                {
                    Items = new object[]
                    {
                        new Dto.InvoiceType
                        {
                            invoiceLines = MapItems(invoice.Items).ToArray(),
                            invoiceHead = new Dto.InvoiceHeadType
                            {
                                invoiceDetail = new Dto.InvoiceDetailType
                                {
                                    currencyCode = invoice.CurrencyCode,
                                    exchangeRate = invoice.ExchangeRate,
                                    invoiceAppearance = (Dto.InvoiceAppearanceType)invoice.AppearanceType,
                                    invoiceCategory = (Dto.InvoiceCategoryType)invoice.CategoryType,
                                    invoiceDeliveryDate = invoice.DeliveryDate,
                                    paymentDate = invoice.PaymentDate
                                },
                                supplierInfo = new Dto.SupplierInfoType
                                {
                                    supplierAddress = new Dto.AddressType
                                    {
                                        Item = new Dto.SimpleAddressType
                                        {
                                            additionalAddressDetail = companyAddress.AddtionalAddressDetail,
                                            city = companyAddress.City,
                                            countryCode = companyAddress.CountryCode,
                                            postalCode = companyAddress.PostalCode,
                                            region = companyAddress.Region
                                        }
                                    },
                                    supplierName = companyInfo.Name,
                                    supplierTaxNumber = new Dto.TaxNumberType
                                    {
                                        taxpayerId = companyInfo.TaxpayerId,
                                        vatCode = companyInfo.VatCode
                                    }
                                },
                                customerInfo = new Dto.CustomerInfoType
                                {
                                    customerAddress = new Dto.AddressType
                                    {
                                        Item = new Dto.SimpleAddressType
                                        {
                                            additionalAddressDetail = customerAddress.AddtionalAddressDetail,
                                            city = customerAddress.City,
                                            countryCode = customerAddress.CountryCode,
                                            postalCode = customerAddress.PostalCode,
                                            region = customerAddress.Region
                                        }
                                    },
                                    customerName = customerInfo.Name,
                                    customerTaxNumber = new Dto.TaxNumberType
                                    {
                                        taxpayerId = customerInfo.TaxpayerId,
                                        vatCode = customerInfo.VatCode
                                    }
                                },
                            },
                            invoiceSummary = new Dto.SummaryType
                            {
                                summaryGrossData = new Dto.SummaryGrossDataType
                                {
                                    invoiceGrossAmount = invoice.GrossAmount,
                                    invoiceGrossAmountHUF = invoice.GrossAmountHUF
                                },
                                Items = new Dto.SummarySimplifiedType[]
                                {
                                    new Dto.SummarySimplifiedType
                                    {
                                        vatContent = invoice.VatContent,
                                        vatContentGrossAmount = invoice.ContentGrossAmount,
                                        vatContentGrossAmountHUF = invoice.ContentGrossAmountHUF
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}