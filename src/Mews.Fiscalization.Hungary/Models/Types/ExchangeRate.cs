namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class ExchangeRate
    {
        public ExchangeRate(decimal value)
        {
            // minInclusive value = "0"
            // maxInclusive value = "1"
            // totalDigits value = "5"
            // fractionDigits value = "4"
            // NOT NULL
            Value = value;
        }

        public decimal Value { get; }
    }
}
