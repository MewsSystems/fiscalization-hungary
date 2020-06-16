﻿using Mews.Fiscalization.Hungary.Models;
using System.Collections.Generic;
using System.Linq;

namespace Mews.Fiscalization.Hungary
{
    internal static class RequestMapper
    {
        internal static Dto.InvoiceData MapInvoice(Invoice invoice)
        {
            var supplierInfo = invoice.SupplierInfo;
            var customerInfo = invoice.CustomerInfo;
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
                                    supplierName = supplierInfo.Name,
                                    supplierAddress = MapAddress(supplierInfo.Address),
                                    supplierTaxNumber = MapTaxNumber(supplierInfo)
                                },
                                customerInfo = new Dto.CustomerInfoType
                                {
                                    customerName = customerInfo.Name,
                                    customerAddress = MapAddress(customerInfo.Address),
                                    customerTaxNumber = MapTaxNumber(customerInfo)
                                },
                            },
                            invoiceSummary = new Dto.SummaryType
                            {
                                summaryGrossData = new Dto.SummaryGrossDataType
                                {
                                    invoiceGrossAmount = invoice.Amount.Gross,
                                    invoiceGrossAmountHUF = invoice.AmountHUF.Gross
                                },
                                Items = new Dto.SummaryNormalType[]
                                {
                                    MapTaxSummary(invoice)
                                }
                            }
                        }
                    }
                }
            };
        }

        internal static Dto.SummaryNormalType MapTaxSummary(Invoice invoice)
        {
            return new Dto.SummaryNormalType
            {
                invoiceNetAmount = invoice.Amount.Net,
                invoiceNetAmountHUF = invoice.AmountHUF.Net,
                invoiceVatAmount = invoice.Amount.Tax,
                invoiceVatAmountHUF = invoice.AmountHUF.Tax,
                summaryByVatRate = invoice.TaxSummary.Select(s => MapSummaryByVatRate(s)).ToArray()
            };
        }

        internal static Dto.SummaryByVatRateType MapSummaryByVatRate(TaxSummaryItem taxSummary)
        {
            return new Dto.SummaryByVatRateType
            {
                vatRate = new Dto.VatRateType
                {
                    Item = taxSummary.TaxRatePercentage,
                    ItemElementName = Dto.ItemChoiceType1.vatPercentage
                },
                vatRateNetData = new Dto.VatRateNetDataType
                {
                    vatRateNetAmount = taxSummary.Amount.Net,
                    vatRateNetAmountHUF = taxSummary.AmountHUF.Net
                },
                vatRateVatData = new Dto.VatRateVatDataType
                {
                    vatRateVatAmount = taxSummary.Amount.Tax,
                    vatRateVatAmountHUF = taxSummary.AmountHUF.Tax
                }
            };
        }

        internal static Dto.TaxNumberType MapTaxNumber(Info info)
        {
            return new Dto.TaxNumberType
            {
                taxpayerId = info.TaxpayerId,
                vatCode = info.VatCode
            };
        }

        internal static Dto.AddressType MapAddress(SimpleAddress address)
        {
            return new Dto.AddressType
            {
                Item = new Dto.SimpleAddressType
                {
                    additionalAddressDetail = address.AddtionalAddressDetail,
                    city = address.City,
                    countryCode = address.CountryCode,
                    postalCode = address.PostalCode,
                    region = address.Region
                }
            };
        }


        internal static Dto.LineAmountsNormalType MapLineAmounts(Item item)
        {
            return new Dto.LineAmountsNormalType
            {
                lineGrossAmountData = new Dto.LineGrossAmountDataType
                {
                    lineGrossAmountNormal = item.Amounts.Amount.Gross,
                    lineGrossAmountNormalHUF = item.Amounts.AmountHUF.Gross
                },
                lineNetAmountData = new Dto.LineNetAmountDataType
                {
                    lineNetAmount = item.Amounts.Amount.Net,
                    lineNetAmountHUF = item.Amounts.AmountHUF.Net
                },
                lineVatRate = new Dto.VatRateType
                {
                    Item = item.Amounts.TaxRatePercentage,
                    ItemElementName = Dto.ItemChoiceType1.vatPercentage
                }
            };
        }

        internal static IEnumerable<Dto.LineType> MapItems(IEnumerable<Item> items)
        {
            return items.Select((i, index) => new Dto.LineType
            {
                lineNumber = (index + 1).ToString(),
                lineDescription = i.Description,
                quantity = i.Quantity,
                unitOfMeasureOwn = i.MeasurementUnit.ToString(),
                unitPrice = i.UnitAmount,
                quantitySpecified = true,
                unitOfMeasureSpecified = true,
                unitPriceSpecified = true,
                depositIndicator = i.IsDeposit,
                Item = MapLineAmounts(i),
                aggregateInvoiceLineData = new Dto.AggregateInvoiceLineDataType
                {
                    lineDeliveryDate = i.ConsumptionDate
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
