namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class TaxSummaryItem
    {
        public TaxSummaryItem(decimal vatPercentage, Amount amount, Amount amountHUF)
        {
            VatPercentage = vatPercentage;
            Amount = amount;
            AmountHUF = amountHUF;
        }

        public decimal VatPercentage { get; }

        public Amount Amount { get; }

        public Amount AmountHUF { get; }
    }
}
