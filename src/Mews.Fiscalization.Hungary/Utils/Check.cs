using System;

namespace Mews.Fiscalization.Hungary.Utils
{
    internal static class Check
    {
        public static T NotNull<T>(T value, string name)
            where T : class
        {
            return value ?? throw new ArgumentNullException(name);
        }
    }
}
