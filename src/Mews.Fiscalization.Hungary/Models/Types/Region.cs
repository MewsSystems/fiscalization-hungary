using FuncSharp;
using Mews.Fiscalization.Core.Model;
using System.Text.RegularExpressions;

namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class Region
    {
        private Region(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static ITry<Region, INonEmptyEnumerable<Error>> Create(string value)
        {
            return ValidationExtensions.ValidateString(value, 0, 50, new Regex(".*[^\\s].*"), v => new Region(v));
        }
    }
}
