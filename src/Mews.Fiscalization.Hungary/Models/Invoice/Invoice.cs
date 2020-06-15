using System;
using System.Collections.Generic;

namespace Mews.Fiscalization.Hungary.Models
{
    public class Invoice
    {
        public Invoice(
            string number,
            DateTime issueDate,
            Info supplierInfo,
            Info customerInfo,
            IEnumerable<Item> items,
            DateTime deliveryDate,
            DateTime paymentDate,
            string currencyCode,
            decimal exchangeRate,
            decimal grossAmount,
            decimal grossAmountHUF,
            decimal netAmount,
            decimal netAmountHUF,
            decimal vatAmount,
            decimal vatAmountHUF,
            decimal vatPercentage,
            decimal vatRateNetAmount,
            decimal vatRateNetAmountHUF,
            decimal vatRateVatAmount,
            decimal vatRateVatAmountHUF,
            bool isSelfBilling = false,
            bool isCashAccounting = false)
        {
            Number = number;
            IssueDate = issueDate;
            SupplierInfo = supplierInfo;
            CustomerInfo = customerInfo;
            Items = items;
            DeliveryDate = deliveryDate;
            PaymentDate = paymentDate;
            CurrencyCode = currencyCode;
            ExchangeRate = exchangeRate;
            GrossAmount = grossAmount;
            GrossAmountHUF = grossAmountHUF;
            NetAmount = netAmount;
            NetAmountHUF = netAmountHUF;
            VatAmount = vatAmount;
            VatAmountHUF = vatAmountHUF;
            VatPercentage = vatPercentage;
            VatRateNetAmount = vatRateNetAmount;
            VatRateNetAmountHUF = vatRateNetAmountHUF;
            VatRateVatAmount = vatRateVatAmount;
            VatRateVatAmountHUF = vatRateVatAmountHUF;
            IsSelfBilling = isSelfBilling;
            IsCashAccounting = isCashAccounting;
        }

        public string Number { get; }

        public DateTime IssueDate { get; }

        public Info SupplierInfo { get; }

        public Info CustomerInfo { get; }

        public IEnumerable<Item> Items { get; }

        public DateTime DeliveryDate { get; }

        public DateTime PaymentDate { get; }

        public string CurrencyCode { get; }

        public decimal ExchangeRate { get; }

        public decimal GrossAmount { get; }

        public decimal GrossAmountHUF { get; }

        public decimal NetAmount { get; }

        public decimal NetAmountHUF { get; }

        public decimal VatAmount { get; }

        public decimal VatAmountHUF { get; }

        public decimal VatPercentage { get; }

        public decimal VatRateNetAmount { get; }

        public decimal VatRateNetAmountHUF { get; }

        public decimal VatRateVatAmount { get; }

        public decimal VatRateVatAmountHUF { get; }

        public bool IsSelfBilling { get; }

        public bool IsCashAccounting { get; }
    }
}
