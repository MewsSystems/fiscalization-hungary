using Mews.Fiscalization.Core.Model;

namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class TaxPayerId : LimitedString
    {
        private static readonly StringLimitation Limitation = new StringLimitation(pattern: "^[0-9]{8}$", allowEmptyOrWhiteSpace: false);

        public TaxPayerId(string value)
            : base(value, Limitation)
        {
        }

        public static bool IsValid(string value)
        {
            return IsValid(value, Limitation);
        }
    }
}
