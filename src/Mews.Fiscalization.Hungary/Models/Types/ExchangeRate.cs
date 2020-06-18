using Mews.Fiscalization.Hungary.Utils;

namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class ExchangeRate
    {
        public ExchangeRate(decimal value)
        {
            Check.Digits(value, maxdigitCount: 1);
            Check.Precision(value, maxPrecision: 4);
            Check.InRange(value, 0, 1);
            Value = value;
        }

        public decimal Value { get; }
    }
}