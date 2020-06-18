using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

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
            throw new NotImplementedException()
            return value != null;
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
