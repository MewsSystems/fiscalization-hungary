using System;
using System.Collections.Generic;

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
    }
}
