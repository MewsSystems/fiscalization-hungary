using System;
using System.Collections.Generic;
using System.Text;

namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class Invoice
    {
        public Invoice(
            Info supplierInfo,
            Info customerInfo,
            IEnumerable<Item> items,
            IEnumerable<TaxSummary> summaries,
            DateTime deliveryDate,
            DateTime paymentDate,
            string currencyCode,
            bool isSelfBilling = false,
            bool isCashAccounting = false)
        {
            SupplierInfo = supplierInfo;
            CustomerInfo = customerInfo;
            Items = items;
            Summaries = summaries;
            DeliveryDate = deliveryDate;
            PaymentDate = paymentDate;
            CurrencyCode = currencyCode;
            IsSelfBilling = isSelfBilling;
            IsCashAccounting = isCashAccounting;
        }

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
