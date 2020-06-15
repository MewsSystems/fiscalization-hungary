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
            IEnumerable<TaxSummary> taxSummaries,
            DateTime deliveryDate,
            DateTime paymentDate,
            string currencyCode,
            bool isSelfBilling = false,
            bool isCashAccounting = false)
        {
            Number = number;
            IssueDate = issueDate;
            SupplierInfo = supplierInfo;
            CustomerInfo = customerInfo;
            Items = items;
            Summaries = taxSummaries;
            DeliveryDate = deliveryDate;
            PaymentDate = paymentDate;
            CurrencyCode = currencyCode;
            IsSelfBilling = isSelfBilling;
            IsCashAccounting = isCashAccounting;
        }

        public string Number { get; }

        public DateTime IssueDate { get; }

        public Info SupplierInfo { get; }

        public Info CustomerInfo { get; }

        public IEnumerable<Item> Items { get; }

        public IEnumerable<TaxSummary> Summaries { get; }

        public DateTime DeliveryDate { get; }

        public DateTime PaymentDate { get; }

        public string CurrencyCode { get; }

        public bool IsSelfBilling { get; }

        public bool IsCashAccounting { get; }
    }
}
