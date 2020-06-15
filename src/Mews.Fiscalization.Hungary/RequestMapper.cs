using Mews.Fiscalization.Hungary.Models;
using System.Collections.Generic;
using System.Linq;

namespace Mews.Fiscalization.Hungary
{
    internal static class RequestMapper
    {
        internal static Dto.InvoiceData MapInvoice(Invoice invoice)
        {
            var companyInfo = invoice.SupplierInfo;
            var customerInfo = invoice.CustomerInfo;
            var customerAddress = invoice.CustomerInfo.Address;
            var companyAddress = companyInfo.Address;
            return new Dto.InvoiceData
            {
                invoiceIssueDate = invoice.IssueDate,
                invoiceNumber = invoice.Number,
                invoiceMain = new Dto.InvoiceMainType
                {
                    Items = new Dto.InvoiceType[]
                    {
                        new Dto.InvoiceType
                        {
                            invoiceLines = MapItems(invoice.Items).ToArray(),
                            invoiceHead = new Dto.InvoiceHeadType
                            {
                                invoiceDetail = new Dto.InvoiceDetailType
                                {
                                    currencyCode = invoice.CurrencyCode,
                                    invoiceAppearance = Dto.InvoiceAppearanceType.ELECTRONIC,
                                    invoiceCategory = Dto.InvoiceCategoryType.AGGREGATE,
                                    invoiceDeliveryDate = invoice.DeliveryDate,
                                    paymentDate = invoice.PaymentDate,
                                    selfBillingIndicator = invoice.IsSelfBilling,
                                    cashAccountingIndicator = invoice.IsCashAccounting
                                },
                                supplierInfo = new Dto.SupplierInfoType
                                {
                                    supplierName = companyInfo.Name,
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
                                Items = new Dto.SummaryNormalType[]
                                {
                                    new Dto.SummaryNormalType
                                    {
                                        invoiceNetAmount = invoice.NetAmount,
                                        invoiceNetAmountHUF = invoice.NetAmountHUF,
                                        invoiceVatAmount = invoice.VatAmount,
                                        invoiceVatAmountHUF = invoice.VatAmountHUF,
                                        summaryByVatRate = new Dto.SummaryByVatRateType[]
                                        {
                                            new Dto.SummaryByVatRateType
                                            {
                                                vatRate = new Dto.VatRateType
                                                {
                                                    Item = invoice.VatPercentage,
                                                    ItemElementName = Dto.ItemChoiceType1.vatPercentage
                                                },
                                                vatRateNetData = new Dto.VatRateNetDataType
                                                {
                                                    vatRateNetAmount = invoice.VatRateNetAmount,
                                                    vatRateNetAmountHUF = invoice.VatRateNetAmountHUF
                                                },
                                                vatRateVatData = new Dto.VatRateVatDataType
                                                {
                                                    vatRateVatAmount = invoice.VatRateVatAmount,
                                                    vatRateVatAmountHUF = invoice.VatRateVatAmountHUF
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }

        internal static IEnumerable<Dto.LineType> MapItems(IEnumerable<Item> items)
        {
            return items.Select(i =>
            {
                var line = new Dto.LineType
                {
                    lineNumber = i.Number,
                    lineDescription = i.Description,
                    quantity = i.Quantity,
                    unitOfMeasureOwn = "Nights",
                    unitPrice = i.NetUnitPrice,
                    unitOfMeasureSpecified = true,
                    unitPriceSpecified = true,
                    depositIndicator = i.IsDeposit,
                    aggregateInvoiceLineData = new Dto.AggregateInvoiceLineDataType
                    {
                        lineDeliveryDate = i.ConsumptionDate,
                        lineExchangeRateSpecified = false
                    },
                    Item = new Dto.LineAmountsNormalType
                    {
                        lineGrossAmountData = new Dto.LineGrossAmountDataType
                        {
                            lineGrossAmountNormal = i.GrossAmount,
                            lineGrossAmountNormalHUF = i.GrossAmountHUF
                        },
                        lineNetAmountData = new Dto.LineNetAmountDataType
                        {
                            lineNetAmount = i.NetAmount,
                            lineNetAmountHUF = i.NetAmountHUF
                        },
                        lineVatRate = new Dto.VatRateType
                        {
                            Item = i.VatPercentage,
                            ItemElementName = Dto.ItemChoiceType1.vatPercentage
                        }
                    },
                    productCodes = new Dto.ProductCodeType[]
                    {
                        new Dto.ProductCodeType
                        {
                            productCodeCategory = (Dto.ProductCodeCategoryType)i.ProductCodeCategory,
                            ItemElementName = (Dto.ItemChoiceType)i.ProductCodeChoiceType,
                            Item = i.ProductCode
                        }
                    }
                };

                if (i.DiscountDescription != null)
                {
                    line.lineDiscountData.discountDescription = i.DiscountDescription;
                }
                if (i.DiscountValue.HasValue)
                {
                    line.lineDiscountData.discountValue = i.DiscountValue.Value;
                }

                return line;
            });
        }
    }
}
