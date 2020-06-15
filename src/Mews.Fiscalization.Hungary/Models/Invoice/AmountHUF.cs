namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class AmountHUF
    {
        public AmountHUF(decimal netAmountHUF, decimal grossAmountHUF, decimal vatAmount)
        {
            NetAmountHUF = netAmountHUF;
            GrossAmountHUF = grossAmountHUF;
            VatAmount = vatAmount;
        }

        public decimal NetAmountHUF { get; }

        public decimal GrossAmountHUF { get; }

        public decimal VatAmount { get; }
    }
}
