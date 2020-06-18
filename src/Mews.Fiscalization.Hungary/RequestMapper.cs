using Mews.Fiscalization.Hungary.Models;
using System.Collections.Generic;
using System.Linq;

namespace Mews.Fiscalization.Hungary
{
    internal static class RequestMapper
    {
        internal static Dto.InvoiceData MapInvoice(Invoice invoice)
        {
            var invoiceAmount = Amount.Sum(invoice.Items.Select(i => i.Amounts.Amount));
            var invoiceAmountHUF = Amount.Sum(invoice.Items.Select(i => i.Amounts.AmountHUF));
            var supplierInfo = invoice.SupplierInfo;
            var customerInfo = invoice.CustomerInfo;
            return new Dto.InvoiceData
            {
                invoiceIssueDate = invoice.IssueDate,
                invoiceNumber = invoice.Number.Value,
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
                                    currencyCode = invoice.CurrencyCode.Value,
                                    invoiceAppearance = Dto.InvoiceAppearanceType.ELECTRONIC,
                                    invoiceCategory = Dto.InvoiceCategoryType.AGGREGATE,
                                    invoiceDeliveryDate = invoice.DeliveryDate,
                                    paymentDate = invoice.PaymentDate,
                                    selfBillingIndicator = invoice.IsSelfBilling,
                                    cashAccountingIndicator = invoice.IsCashAccounting
                                },
                                supplierInfo = new Dto.SupplierInfoType
                                {
                                    supplierName = supplierInfo.Name.Value,
                                    supplierAddress = MapAddress(supplierInfo.Address),
                                    supplierTaxNumber = MapTaxNumber(supplierInfo)
                                },
                                customerInfo = new Dto.CustomerInfoType
                                {
                                    customerName = customerInfo.Name.Value,
                                    customerAddress = MapAddress(customerInfo.Address),
                                    customerTaxNumber = MapTaxNumber(customerInfo)
                                },
                            },
                            invoiceSummary = new Dto.SummaryType
                            {
                                summaryGrossData = new Dto.SummaryGrossDataType
                                {
                                    invoiceGrossAmount = invoiceAmount.Gross.Value,
                                    invoiceGrossAmountHUF = invoiceAmountHUF.Gross.Value
                                },
                                Items = new Dto.SummaryNormalType[]
                                {
                                    MapTaxSummary(invoice, invoiceAmount, invoiceAmountHUF)
                                }
                            }
                        }
                    }
                }
            };
        }

        internal static Dto.SummaryNormalType MapTaxSummary(Invoice invoice, Amount amount, Amount amountHUF)
        {
            return new Dto.SummaryNormalType
            {
                invoiceNetAmount = amount.Net.Value,
                invoiceNetAmountHUF = amountHUF.Net.Value,
                invoiceVatAmount = amount.Tax.Value,
                invoiceVatAmountHUF = amountHUF.Tax.Value,
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
                    vatRateNetAmount = taxSummary.Amount.Net.Value,
                    vatRateNetAmountHUF = taxSummary.AmountHUF.Net.Value
                },
                vatRateVatData = new Dto.VatRateVatDataType
                {
                    vatRateVatAmount = taxSummary.Amount.Tax.Value,
                    vatRateVatAmountHUF = taxSummary.AmountHUF.Tax.Value
                }
            };
        }

        internal static Dto.TaxNumberType MapTaxNumber(Info info)
        {
            return new Dto.TaxNumberType
            {
                taxpayerId = info.TaxpayerId.Value,
                vatCode = info.VatCode.Value
            };
        }

        internal static Dto.AddressType MapAddress(SimpleAddress address)
        {
            return new Dto.AddressType
            {
                Item = new Dto.SimpleAddressType
                {
                    additionalAddressDetail = address.AddtionalAddressDetail.Value,
                    city = address.City.Value,
                    countryCode = address.CountryCode.Value,
                    postalCode = address.PostalCode.Value,
                    region = address.Region?.Value
                }
            };
        }


        internal static Dto.LineAmountsNormalType MapLineAmounts(Item item)
        {
            return new Dto.LineAmountsNormalType
            {
                lineGrossAmountData = new Dto.LineGrossAmountDataType
                {
                    lineGrossAmountNormal = item.Amounts.Amount.Gross.Value,
                    lineGrossAmountNormalHUF = item.Amounts.AmountHUF.Gross.Value
                },
                lineNetAmountData = new Dto.LineNetAmountDataType
                {
                    lineNetAmount = item.Amounts.Amount.Net.Value,
                    lineNetAmountHUF = item.Amounts.AmountHUF.Net.Value
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
                lineDescription = i.Description.Value,
                quantity = i.Quantity,
                unitOfMeasureOwn = i.MeasurementUnit.ToString(),
                unitPrice = i.UnitAmount.Net.Value,
                quantitySpecified = true,
                unitOfMeasureSpecified = true,
                unitPriceSpecified = true,
                depositIndicator = i.IsDeposit,
                Item = MapLineAmounts(i),
                aggregateInvoiceLineData = new Dto.AggregateInvoiceLineDataType
                {
                    lineExchangeRateSpecified = true,
                    lineExchangeRate = i.ExchangeRate?.Value ?? 0m,
                    lineDeliveryDate = i.ConsumptionDate
                }
            });
        }
    }
}
