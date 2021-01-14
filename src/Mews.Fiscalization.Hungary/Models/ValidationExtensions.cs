using FuncSharp;
using Mews.Fiscalization.Core.Model;
using System;
using System.Text.RegularExpressions;

namespace Mews.Fiscalization.Hungary.Models
{
    internal static class ValidationExtensions
    {
        internal static ITry<T, INonEmptyEnumerable<Error>> ValidateString<T>(string value, int min, int max, Regex regex, Func<string, T> mapper)
        {
            return StringValidations.LengthInRange(value, min, max).FlatMap(v =>
            {
                var validatedValue = StringValidations.RegexMatch(v, regex);
                return validatedValue.Map(d => mapper(d));
            });
        }
    }
}
