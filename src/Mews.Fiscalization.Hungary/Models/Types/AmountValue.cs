namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class AmountValue
    {
        public AmountValue(decimal value)
        {
            // total digits: 18
            // fraction digits: 2
            // NOT NULL
            Value = value;
        }

        public decimal Value { get; }
    }
}
