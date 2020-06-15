namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class Amount
    {
        public Amount(decimal netAmount, decimal grossAmount, decimal vatAmount)
        {
            NetAmount = netAmount;
            GrossAmount = grossAmount;
            VatAmount = vatAmount;
        }

        public decimal NetAmount { get; }

        public decimal GrossAmount { get; }

        public decimal VatAmount { get; }
    }
}
