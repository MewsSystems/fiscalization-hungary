using Mews.Fiscalization.Core.Model;

namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class CountryCode : LimitedString
    {
        private static readonly StringLimitation Limitation = new StringLimitation(pattern: "[A-Z]{2}", allowEmptyOrWhiteSpace: false);

        public CountryCode(string value)
            : base(value, Limitation)
        {
        }

        public static bool IsValid(string value)
        {
            return IsValid(value, Limitation);
        }
    }
}
