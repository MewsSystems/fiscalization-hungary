using FuncSharp;
using Mews.Fiscalization.Core.Model;
using System.Text.RegularExpressions;

namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class Name
    {
        private Name(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static ITry<Name, INonEmptyEnumerable<Error>> Create(string value)
        {
            return ValidationExtensions.ValidateString(value, 1, 512, new Regex(".*[^\\s].*"), v => new Name(v));
        }
    }
}
