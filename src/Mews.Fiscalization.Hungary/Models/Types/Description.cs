using FuncSharp;
using Mews.Fiscalization.Core.Model;
using System.Text.RegularExpressions;

namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class Description
    {
        private Description(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static ITry<Description, INonEmptyEnumerable<Error>> Create(string value)
        {
            return ValidationExtensions.ValidateString(value, 1, 512, new Regex(".*[^\\s].*"), v => new Description(v));
        }
    }
}
