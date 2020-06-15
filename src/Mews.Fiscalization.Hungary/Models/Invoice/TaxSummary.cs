using System.Collections.Generic;

namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class TaxSummary
    {
        public TaxSummary(IEnumerable<TaxSummaryItem> items, Amount amount, AmountHUF amountHUF)
        {
            Items = items;
            Amount = amount;
            AmountHUF = amountHUF;
        }

        public IEnumerable<TaxSummaryItem> Items { get; }

        public Amount Amount { get; }

        public AmountHUF AmountHUF { get; }
    }
}
