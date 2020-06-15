namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class Amount
    {
        public Amount(decimal net, decimal gross, decimal tax)
        {
            Net = net;
            Gross = gross;
            Tax = tax;
        }

        public decimal Net { get; }

        public decimal Gross { get; }

        public decimal Tax { get; }
    }
}
