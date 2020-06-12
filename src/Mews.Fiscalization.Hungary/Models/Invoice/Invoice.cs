using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Mews.Fiscalization.Hungary.Models
{
    public class Invoice
    {
        public Invoice(string number,
            DateTime issueDate,
            CompanyInfo companyInfo,
            CustomerInfo customerInfo,
            IEnumerable<InvoiceDetail> details,
            IEnumerable<VatRate> vatRates,
            DateTime deliveryDate,
            DateTime paymentDate,
            AppearanceType appearanceType,
            CategoryType categoryType,
            string currencyCode,
            decimal exchangeRate,
            decimal netAmount,
            decimal netAmountHUF,
            decimal vatAmount,
            decimal vatAmountHUF,
            decimal grossAmount,
            decimal grossAmountHUF,
            decimal contentGrossAmount,
            decimal contentGrossAmountHUF)
        {
            Number = number;
            IssueDate = issueDate;
            CompanyInfo = companyInfo;
            CustomerInfo = customerInfo;
            Lines = details;
            VatRates = vatRates;
            PaymentDate = paymentDate;
            DeliveryDate = deliveryDate;
            AppearanceType = appearanceType;
            CategoryType = categoryType;
            CurrencyCode = currencyCode;
            ExchangeRate = exchangeRate;
            NetAmount = netAmount;
            NetAmountHUF = netAmountHUF;
            VatAmount = vatAmount;
            VatAmountHUF = vatAmountHUF;
            GrossAmount = grossAmount;
            GrossAmountHUF = grossAmountHUF;
            ContentGrossAmount = contentGrossAmount;
            ContentGrossAmountHUF = contentGrossAmountHUF;
        }

        public string Number { get; }

        public DateTime IssueDate { get; }

        public CompanyInfo CompanyInfo { get; }

        public CustomerInfo CustomerInfo { get; }

        public IEnumerable<InvoiceDetail> Lines { get; }

        public IEnumerable<VatRate> VatRates { get; } // TODO: Usages

        public DateTime DeliveryDate { get; }

        public DateTime PaymentDate { get; }

        public AppearanceType AppearanceType { get; }

        public CategoryType CategoryType { get; }

        public string CurrencyCode { get; }

        public decimal ExchangeRate { get; }

        public decimal NetAmount { get; } // TODO: Usages here and below

        public decimal NetAmountHUF { get; }

        public decimal VatAmount { get; }

        public decimal VatAmountHUF { get; }

        public decimal GrossAmount { get; }

        public decimal GrossAmountHUF { get; }

        public decimal ContentGrossAmount { get; }

        public decimal ContentGrossAmountHUF { get; }


        internal static IEnumerable<Dto.LineType> MapLines(IEnumerable<InvoiceDetail> details)
        {
            return details.Select(d => new Dto.LineType
            {
                Item = new Dto.LineAmountsSimplifiedType
                {
                    lineGrossAmountSimplified = d.GrossAmount,
                    lineGrossAmountSimplifiedHUF = d.GrossAmountHUF
                },
                lineDescription = d.Description,
                lineDiscountData = new Dto.DiscountDataType
                {
                    discountDescription = d.DiscountDescription,
                    discountValue = d.DiscountValue
                },
                lineExpressionIndicator = d.ExpressionIndicator,
                lineNatureIndicator = (Dto.LineNatureIndicatorType)d.IndicatorType,
                lineNumber = d.Number,
                productCodes = new Dto.ProductCodeType[]
                {
                    new Dto.ProductCodeType
                    {
                        productCodeCategory = (Dto.ProductCodeCategoryType)d.ProductCodeCategory,
                        ItemElementName = (Dto.ItemChoiceType)d.ProductCodeChoiceType,
                        Item = d.ProductCode
                    }
                },
                quantity = d.Quantity,
                unitOfMeasure = (Dto.UnitOfMeasureType)d.MeasurementUnitType,
                unitPrice = d.UnitPrice
            });
        }

        internal static Dto.InvoiceData Map(Invoice invoice)
        {
            var companyInfo = invoice.CompanyInfo;
            var customerInfo = invoice.CustomerInfo;
            var customerAddress = invoice.CustomerInfo.Address;
            var companyAddress = companyInfo.Address;
            var lines = invoice.Lines;
            return new Dto.InvoiceData
            {
                invoiceIssueDate = invoice.IssueDate,
                invoiceMain = new Dto.InvoiceMainType
                {
                    Items = new object[]
                    {
                        new Dto.InvoiceType
                        {
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
                                supplierInfo = new Dto.SupplierInfoType // Extract the same logic from customerSuplier and companySuplier
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
                                customerInfo = new Dto.CustomerInfoType // TODO: Remove maybe? (its optional).
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
                                }
                            },
                            invoiceLines = MapLines(lines).ToArray(),
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
                                        vatContentGrossAmount = invoice.ContentGrossAmount,
                                        vatContentGrossAmountHUF = invoice.ContentGrossAmountHUF
                                    }
                                }
                            }
                        }
                    }
                },
                invoiceNumber = invoice.Number
            };
        }
    }
}
