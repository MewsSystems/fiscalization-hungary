using Mews.Fiscalization.Core.Model;
using System.Collections.Generic;

namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class TransactionStatus
    {
        public TransactionStatus(IEnumerable<IndexedItem<InvoiceStatus>> invoiceStatuses)
        {
            InvoiceStatuses = invoiceStatuses.AsList();
        }

        public List<IndexedItem<InvoiceStatus>> InvoiceStatuses { get; }
    }
}