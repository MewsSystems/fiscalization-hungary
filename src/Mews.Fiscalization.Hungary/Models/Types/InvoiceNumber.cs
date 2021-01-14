using FuncSharp;
using Mews.Fiscalization.Core.Model;
using System.Text.RegularExpressions;

namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class InvoiceNumber
    {
        private InvoiceNumber(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static ITry<InvoiceNumber, INonEmptyEnumerable<Error>> Create(string value)
        {
            return ValidationExtensions.ValidateString(value, 1, 50, new Regex(".*[^\\s].*"), v => new InvoiceNumber(v));
        }
    }
}
