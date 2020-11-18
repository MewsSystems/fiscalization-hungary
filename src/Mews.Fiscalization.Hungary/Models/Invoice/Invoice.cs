using System;
using System.Collections.Generic;
using System.Linq;
using Mews.Fiscalization.Core.Model;

namespace Mews.Fiscalization.Hungary.Models
{
    public class Invoice
    {
        public Invoice(
            InvoiceNumber number,
            DateTime issueDate,
            DateTime paymentDate,
            SupplierInfo supplierInfo,
            CustomerInfo customerInfo,
            CurrencyCode currencyCode,
            ISequentialEnumerable<InvoiceItem> items,
            bool isSelfBilling = false,
            bool isCashAccounting = false)
        {
            Number = number;
            IssueDate = issueDate;
            PaymentDate = paymentDate;
            SupplierInfo = supplierInfo;
            CustomerInfo = customerInfo;
            CurrencyCode = currencyCode;
            Items = items;
            DeliveryDate = Items.Max(i => i.Value.ConsumptionDate);
            ExchangeRate = GetExchangeRate(items);
            TaxSummary = GetTaxSummary(items);
            IsSelfBilling = isSelfBilling;
            IsCashAccounting = isCashAccounting;

            CheckConsistency(this);
        }

        public InvoiceNumber Number { get; }

        public DateTime DeliveryDate { get; }

        public DateTime IssueDate { get; }

        public DateTime PaymentDate { get; }

        public SupplierInfo SupplierInfo { get; }

        public CustomerInfo CustomerInfo { get; }

        public CurrencyCode CurrencyCode { get; }

        public ExchangeRate ExchangeRate { get; }

        public List<TaxSummaryItem> TaxSummary { get; }

        public ISequentialEnumerable<InvoiceItem> Items { get; }

        public bool IsSelfBilling { get; }

        public bool IsCashAccounting { get; }

        private ExchangeRate GetExchangeRate(ISequentialEnumerable<InvoiceItem> indexedItems)
        {
            var totalGrossHuf = indexedItems.Values.Sum(i => Math.Abs(i.TotalAmounts.AmountHUF.Gross.Value));
            var totalGross = indexedItems.Values.Sum(i => Math.Abs(i.TotalAmounts.Amount.Gross.Value));
            if (totalGross != 0)
            {
                return ExchangeRate.Rounded(totalGrossHuf / totalGross);
            }

            return new ExchangeRate(1);
        }

        private List<TaxSummaryItem> GetTaxSummary(ISequentialEnumerable<InvoiceItem> indexedItems)
        {
            var itemsByTaxRate = indexedItems.Values.GroupBy(i => i.TotalAmounts.TaxRatePercentage);
            var taxSummaryItems = itemsByTaxRate.Select(g => new TaxSummaryItem(
                taxRatePercentage: g.Key,
                amount: Amount.Sum(g.Select(i => i.TotalAmounts.Amount)),
                amountHUF: Amount.Sum(g.Select(i => i.TotalAmounts.AmountHUF))
            ));
            return taxSummaryItems.AsList();
        }

        private static void CheckConsistency(Invoice invoice)
        {
            var nonDefaultCurrency = !invoice.CurrencyCode.Equals(TaxationInfo.DefaultCurrencyCode);
            var hasRequiredTaxRates = nonDefaultCurrency.Implies(() => invoice.Items.All(i => i.Value.ExchangeRate != null));
            if (!hasRequiredTaxRates)
            {
                throw new InvalidOperationException("Exchange rate needs to be specified for all items.");
            }
        }
    }
}