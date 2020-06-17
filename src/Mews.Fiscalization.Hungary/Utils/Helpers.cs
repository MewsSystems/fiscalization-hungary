﻿using System.Collections.Generic;
using System.Linq;

namespace Mews.Fiscalization.Hungary.Utils
{
    internal static class Helpers
    {
        public static IEnumerable<TSource> NullToEmpty<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null)
            {
                return Enumerable.Empty<TSource>();
            }

            return source;
        }
    }
}
