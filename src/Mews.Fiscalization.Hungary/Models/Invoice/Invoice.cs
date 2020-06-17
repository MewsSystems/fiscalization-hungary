using System;
using System.Collections.Generic;
using System.Linq;

namespace Mews.Fiscalization.Hungary.Models
{
    public class Invoice
    {
        public Invoice(
            InvoiceNumber number,
            DateTime issueDate,
            Info supplierInfo,
            Info customerInfo,
            IEnumerable<Item> items,
            Amount amount,
            Amount amountHUF,
            DateTime deliveryDate,
            DateTime paymentDate,
            string currencyCode,
            decimal exchangeRate,
            bool isSelfBilling = false,
            bool isCashAccounting = false)
        {
            Number = number;
            IssueDate = issueDate;
            SupplierInfo = supplierInfo;
            CustomerInfo = customerInfo;
            Items = items;
            Amount = amount;
            AmountHUF = amountHUF;
            DeliveryDate = deliveryDate;
            PaymentDate = paymentDate;
            CurrencyCode = currencyCode;
            ExchangeRate = exchangeRate;
            IsSelfBilling = isSelfBilling;
            IsCashAccounting = isCashAccounting;
            TaxSummary = items.GroupBy(i => i.Amounts.TaxRatePercentage).Select(g => new TaxSummaryItem(
                taxRatePercentage: g.Key,
                amount: Amount.Sum(g.Select(i => i.Amounts.Amount)),
                amountHUF: Amount.Sum(g.Select(i => i.Amounts.AmountHUF))
            ));
        }

        public InvoiceNumber Number { get; }

        public DateTime IssueDate { get; }

        public Info SupplierInfo { get; }

        public Info CustomerInfo { get; }

        public IEnumerable<Item> Items { get; }

        public IEnumerable<TaxSummaryItem> TaxSummary { get; }

        public Amount Amount { get; }

        public Amount AmountHUF { get; }

        public DateTime DeliveryDate { get; }

        public DateTime PaymentDate { get; }

        public string CurrencyCode { get; }

        public decimal ExchangeRate { get; }

        public bool IsSelfBilling { get; }

        public bool IsCashAccounting { get; }
    }
}
