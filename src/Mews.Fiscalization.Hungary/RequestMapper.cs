using Mews.Fiscalization.Hungary.Models;
using System.Collections.Generic;
using System.Linq;

namespace Mews.Fiscalization.Hungary
{
    internal static class RequestMapper
    {
        internal static Dto.InvoiceData MapInvoiceData(InvoiceData data)
        {
            return new Dto.InvoiceData
            {
                invoiceIssueDate = data.IssueDate,
                invoiceNumber = data.Number,
                invoiceMain = new Dto.InvoiceMainType
                {
                    Items = MapInvoices(data.Invoices).ToArray()
                }
            };
        }

        internal static IEnumerable<Dto.InvoiceType> MapInvoices(IEnumerable<Invoice> invoices)
        {
            return invoices.Select(i => new Dto.InvoiceType
            {
                invoiceLines = MapItems(i.Items).ToArray(),
                invoiceHead = new Dto.InvoiceHeadType
                {
                    invoiceDetail = new Dto.InvoiceDetailType
                    {
                        currencyCode = i.CurrencyCode,
                        invoiceAppearance = Dto.InvoiceAppearanceType.ELECTRONIC,
                        invoiceCategory = Dto.InvoiceCategoryType.AGGREGATE,
                        invoiceDeliveryDate = i.DeliveryDate,
                        paymentDate = i.PaymentDate,
                        selfBillingIndicator = i.IsSelfBilling,
                        cashAccountingIndicator = i.IsCashAccounting
                    },
                    supplierInfo = new Dto.SupplierInfoType
                    {
                        supplierName = i.SupplierInfo.Name,
                        supplierAddress = new Dto.AddressType
                        {
                            Item = new Dto.SimpleAddressType
                            {
                                additionalAddressDetail = i.SupplierInfo.Address.AddtionalAddressDetail,
                                city = i.SupplierInfo.Address.City,
                                countryCode = i.SupplierInfo.Address.CountryCode,
                                postalCode = i.SupplierInfo.Address.PostalCode,
                                region = i.SupplierInfo.Address.Region
                            }
                        },
                        supplierTaxNumber = new Dto.TaxNumberType
                        {
                            taxpayerId = i.SupplierInfo.TaxpayerId,
                            vatCode = i.SupplierInfo.VatCode
                        }
                    },
                    customerInfo = new Dto.CustomerInfoType
                    {
                        customerAddress = new Dto.AddressType
                        {
                            Item = new Dto.SimpleAddressType
                            {
                                additionalAddressDetail = i.CustomerInfo.Address.AddtionalAddressDetail,
                                city = i.CustomerInfo.Address.City,
                                countryCode = i.CustomerInfo.Address.CountryCode,
                                postalCode = i.CustomerInfo.Address.PostalCode,
                                region = i.CustomerInfo.Address.Region
                            }
                        },
                        customerName = i.CustomerInfo.Name,
                        customerTaxNumber = new Dto.TaxNumberType
                        {
                            taxpayerId = i.CustomerInfo.TaxpayerId,
                            vatCode = i.CustomerInfo.VatCode
                        }
                    },
                },
                invoiceSummary = new Dto.SummaryType
                {
                    Items = MapSummary(i).ToArray()
                }
            });
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
                    Item = i.VatPercentage,
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
                        lineGrossAmountNormal = i.TaxItem.Amount.GrossAmount,
                        lineGrossAmountNormalHUF = i.TaxItem.AmountHUF.GrossAmountHUF
                    },
                    lineNetAmountData = new Dto.LineNetAmountDataType
                    {
                        lineNetAmount = i.TaxItem.Amount.NetAmount,
                        lineNetAmountHUF = i.TaxItem.AmountHUF.NetAmountHUF
                    },
                    lineVatRate = new Dto.VatRateType
                    {
                        Item = i.TaxItem.VatPercentage,
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
