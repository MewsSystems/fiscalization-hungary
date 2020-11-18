using Mews.Fiscalization.Core.Model;

namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class CurrencyCode : LimitedString
    {
        private static readonly StringLimitation Limitation = new StringLimitation(pattern: "[A-Z]{3}", allowEmptyOrWhiteSpace: false);

        public CurrencyCode(string value)
            : base(value, Limitation)
        {
        }

        public static bool IsValid(string value)
        {
            return IsValid(value, Limitation);
        }

        public override bool Equals(object other)
        {
            return other is CurrencyCode otherCurrencyCode && otherCurrencyCode.Value == Value;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
