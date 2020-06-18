using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
    }
}
