using System;
using Mews.Fiscalization.Core.Model;

namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class ExchangeRate : LimitedDecimal
    {
        private static readonly int MaxDecimalPlaces = 6;
        private static readonly DecimalLimitation Limitation = new DecimalLimitation(min: 0, max: 100_000_000, maxDecimalPlaces: MaxDecimalPlaces, minIsAllowed: false, maxIsAllowed: false);

        public ExchangeRate(decimal value)
            : base(value, Limitation)
        {
        }

        public static ExchangeRate Rounded(decimal value)
        {
            return new ExchangeRate(Decimal.Round(value, MaxDecimalPlaces));
        }

        public static bool IsValid(decimal value)
        {
            return IsValid(value, Limitation);
        }
    }
}