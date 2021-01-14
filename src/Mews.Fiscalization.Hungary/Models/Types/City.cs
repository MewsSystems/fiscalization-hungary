using FuncSharp;
using Mews.Fiscalization.Core.Model;
using System.Text.RegularExpressions;

namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class City
    {
        private City(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static ITry<City, INonEmptyEnumerable<Error>> Create(string value)
        {
            return ValidationExtensions.ValidateString(value, 1, 255, new Regex(".*[^\\s].*"), v => new City(v));
        }
    }
}
