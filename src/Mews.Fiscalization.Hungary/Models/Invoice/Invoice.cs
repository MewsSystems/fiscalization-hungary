using System;
using System.Collections.Generic;
using System.Linq;

namespace Mews.Fiscalization.Hungary.Models
{
    public class Invoice
    {
        public Invoice(string number,
            DateTime issueDate,
            Info companyInfo,
            Info customerInfo,
            IEnumerable<Item> items,
            DateTime deliveryDate,
            DateTime paymentDate,
            AppearanceType appearanceType,
            CategoryType categoryType,
            string currencyCode,
            decimal exchangeRate,
            decimal grossAmount,
            decimal grossAmountHUF,
            decimal vatContent,
            decimal contentGrossAmount,
            decimal contentGrossAmountHUF)
        {
            Number = number;
            IssueDate = issueDate;
            CompanyInfo = companyInfo;
            CustomerInfo = customerInfo;
            Items = items;
            PaymentDate = paymentDate;
            DeliveryDate = deliveryDate;
            AppearanceType = appearanceType;
            CategoryType = categoryType;
            CurrencyCode = currencyCode;
            ExchangeRate = exchangeRate;
            GrossAmount = grossAmount;
            GrossAmountHUF = grossAmountHUF;
            VatContent = vatContent;
            ContentGrossAmount = contentGrossAmount;
            ContentGrossAmountHUF = contentGrossAmountHUF;
        }

        public string Number { get; }

        public DateTime IssueDate { get; }

        public Info CompanyInfo { get; }

        public Info CustomerInfo { get; }

        public IEnumerable<Item> Items { get; }

        public DateTime DeliveryDate { get; }

        public DateTime PaymentDate { get; }

        public AppearanceType AppearanceType { get; }

        public CategoryType CategoryType { get; }

        public string CurrencyCode { get; }

        public decimal ExchangeRate { get; }

        public decimal GrossAmount { get; }

        public decimal GrossAmountHUF { get; }

        public decimal VatContent { get; }

        public decimal ContentGrossAmount { get; }

        public decimal ContentGrossAmountHUF { get; }

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
                            invoiceLines = Item.Map(invoice.Items).ToArray(),
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
