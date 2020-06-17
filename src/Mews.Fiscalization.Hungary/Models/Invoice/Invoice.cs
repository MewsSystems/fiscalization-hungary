using Mews.Fiscalization.Hungary.Utils;
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
            CurrencyCode currencyCode,
            ExchangeRate exchangeRate,
            bool isSelfBilling = false,
            bool isCashAccounting = false)
        {
            Number = Check.NotNull(number, nameof(InvoiceNumber));
            IssueDate = issueDate;
            SupplierInfo = Check.NotNull(supplierInfo, nameof(supplierInfo));
            CustomerInfo = Check.NotNull(customerInfo, nameof(customerInfo));
            Items = Check.NotNull(items, nameof(items));
            Amount = Check.NotNull(amount, nameof(amount));
            AmountHUF = Check.NotNull(amountHUF, nameof(amountHUF));
            DeliveryDate = deliveryDate;
            PaymentDate = paymentDate;
            CurrencyCode = Check.NotNull(currencyCode, nameof(currencyCode));
            ExchangeRate = Check.NotNull(exchangeRate, nameof(exchangeRate));
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

        public CurrencyCode CurrencyCode { get; }

        public ExchangeRate ExchangeRate { get; }

        public bool IsSelfBilling { get; }

        public bool IsCashAccounting { get; }
    }
}
