using FuncSharp;
using Mews.Fiscalization.Core.Model;

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
            return ValidationExtensions.ValidateString(value, 1, 50, ".*[^\\s].*").Map(v => new InvoiceNumber(v));
        }
    }
}
