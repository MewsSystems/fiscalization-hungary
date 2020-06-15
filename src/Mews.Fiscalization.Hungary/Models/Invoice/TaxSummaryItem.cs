namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class TaxSummaryItem
    {
        public TaxSummaryItem(decimal percentage, Amount amount, AmountHUF amountHUF)
        {
            Percentage = percentage;
            Amount = amount;
            AmountHUF = amountHUF;
        }

        public decimal Percentage { get; }

        public Amount Amount { get; }

        public AmountHUF AmountHUF { get; }
    }
}
