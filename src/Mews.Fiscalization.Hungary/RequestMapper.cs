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
                                Items = MapSummary(invoice).ToArray()
                            }
                        }
                    }
                }
            };
        }

        internal static IEnumerable<Dto.SummaryNormalType> MapSummary(Invoice invoice)
        {
            return invoice.Summaries.Select(s => new Dto.SummaryNormalType
            {
                invoiceNetAmount = s.Amount.NetAmount,
                invoiceNetAmountHUF = s.AmountHUF.NetAmountHUF,
                invoiceVatAmount = s.Amount.VatAmount,
                invoiceVatAmountHUF = s.AmountHUF.VatAmount,
                summaryByVatRate = MapSummaryByVatRate(s.Items).ToArray()
            });
        }

        internal static IEnumerable<Dto.SummaryByVatRateType> MapSummaryByVatRate(IEnumerable<TaxSummaryItem> items)
        {
            return items.Select(i => new Dto.SummaryByVatRateType
            {
                vatRate = new Dto.VatRateType
                {
                    Item = i.Percentage,
                    ItemElementName = Dto.ItemChoiceType1.vatPercentage
                },
                vatRateGrossData = new Dto.VatRateGrossDataType
                {
                    vatRateGrossAmount = i.Amount.GrossAmount,
                    vatRateGrossAmountHUF = i.AmountHUF.GrossAmountHUF
                },
                vatRateNetData = new Dto.VatRateNetDataType
                {
                    vatRateNetAmount = i.Amount.NetAmount,
                    vatRateNetAmountHUF = i.AmountHUF.NetAmountHUF
                },
                vatRateVatData = new Dto.VatRateVatDataType
                {
                    vatRateVatAmount = i.Amount.VatAmount,
                    vatRateVatAmountHUF = i.AmountHUF.VatAmount
                }
            });
        }

        internal static IEnumerable<Dto.LineType> MapItems(IEnumerable<Item> items)
        {
            return items.Select(i => new Dto.LineType
            {
                lineNumber = i.Number,
                lineDescription = i.Description,
                quantity = i.Quantity,
                unitOfMeasureOwn = i.MeasurementUnit.ToString(),
                unitPrice = i.NetUnitPrice,
                unitOfMeasureSpecified = true,
                unitPriceSpecified = true,
                quantitySpecified = true,
                depositIndicator = i.IsDeposit,
                aggregateInvoiceLineData = new Dto.AggregateInvoiceLineDataType
                {
                    lineDeliveryDate = i.ConsumptionDate
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
            });
        }
    }
}
