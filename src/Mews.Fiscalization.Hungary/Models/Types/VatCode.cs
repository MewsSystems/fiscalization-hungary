using Mews.Fiscalization.Core.Model;

namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class VatCode : LimitedString
    {
        private static readonly StringLimitation Limitation = new StringLimitation(pattern: "[1-5]{1}", allowEmptyOrWhiteSpace: false);

        public VatCode(string value)
            : base(value, Limitation)
        {
        }

        public static bool IsValid(string value)
        {
            return IsValid(value, Limitation);
        }
    }
}
