using System;

namespace Mews.Fiscalization.Hungary.Utils
{
    internal static class Extensions
    {
        public static bool HasFewerDigitsThan(this decimal value, int maxDigitCount)
        {
            return value < (decimal)Math.Pow(10, maxDigitCount);
        }

        public static bool PrecisionSmallerThanOrEqualTo(this decimal value, int maxPrecision)
        {
            var minAllowedFraction = (decimal)Math.Pow(10, -1 * maxPrecision);
            return value % minAllowedFraction == 0;
        }
    }
}
