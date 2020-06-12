namespace Mews.Fiscalization.Hungary.Models
{
    public class VatRate
    {
        public VatRate(string percentage, string netAmount, string netAmountHUF, string vatAmount, string vatAmountHUF, string grossAmount, string grossAmountHUF)
        {
            Percentage = percentage;
            NetAmount = netAmount;
            NetAmountHUF = netAmountHUF;
            VatAmount = vatAmount;
            VatAmountHUF = vatAmountHUF;
            GrossAmount = grossAmount;
            GrossAmountHUF = grossAmountHUF;
        }

        public string Percentage { get; }

        public string NetAmount { get; }

        public string NetAmountHUF { get; }

        public string VatAmount { get; }

        public string VatAmountHUF { get; }

        public string GrossAmount { get; }

        public string GrossAmountHUF { get; }
    }
}
