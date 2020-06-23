using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Mews.Fiscalization.Hungary.Utils
{
    internal static class Extensions
    {
        public static IEnumerable<TSource> NullToEmpty<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null)
            {
                return Enumerable.Empty<TSource>();
            }

            return source;
        }

        public static bool HasFewerDigitsThan(this decimal value, int maxDigitCount)
        {
            return value < (decimal)Math.Pow(10, maxDigitCount);
        }

        public static bool PrecisionSmallerThanOrEqualTo(this decimal value, int maxPrecision)
        {
            var minAllowedFraction = (decimal)Math.Pow(10, -1 * maxPrecision);
            return value % minAllowedFraction == 0;
        }

        public static bool MatchesRegex(this string value, string regex)
        {
            return value != null && Regex.Match(value, regex).Success;
        }

        public static bool LengthIsInRange(this string value, int? minLength = null, int? maxLength = null)
        {
            var length = value.Length;
            var isShorterThanMinLength = minLength != null && length < minLength;
            var exceedsMaxLength = maxLength != null && length > maxLength;
            return !isShorterThanMinLength && !exceedsMaxLength;
        }

        public static decimal SafeDivision(this decimal numerator, decimal denominator)
        {
            return (denominator == 0) ? 0 : numerator / denominator;
        }

        public static List<TSource> AsList<TSource>(this IEnumerable<TSource> source)
        {
            return source as List<TSource> ?? source.ToList();
        }
    }
}
