namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class AmountType
    {
        public AmountType(decimal value)
        {
            // total digits: 18
            // fraction digits: 2
            // NOT NULL
            Value = value;
        }

        public decimal Value { get; }
    }
}
