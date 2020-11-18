using System;

namespace Mews.Fiscalization.Hungary.Utils
{
    internal static class Check
    {
        public static void Digits(decimal value, int maxdigitCount)
        {
            if (!value.HasFewerDigitsThan(maxdigitCount))
            {
                throw new ArgumentOutOfRangeException($"Value cannot have more than {maxdigitCount} digits.");
            }
        }

        public static void Precision(decimal value, int maxPrecision)
        {
            if (!value.PrecisionSmallerThanOrEqualTo(maxPrecision))
            {
                throw new ArgumentOutOfRangeException($"Precision cannot be higher than {maxPrecision}.");
            }
        }
    }
}
