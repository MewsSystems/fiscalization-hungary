using Mews.Fiscalization.Core.Model;

namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class InvoiceNumber : LimitedString
    {
        private static readonly StringLimitation Limitation = new StringLimitation(maxLength: 50, pattern: ".*[^\\s].*", allowEmptyOrWhiteSpace: false);

        public InvoiceNumber(string value)
            : base(value, Limitation)
        {
        }

        public static bool IsValid(string value)
        {
            return IsValid(value, Limitation);
        }
    }
}
