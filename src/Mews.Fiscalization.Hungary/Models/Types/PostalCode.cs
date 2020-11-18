using Mews.Fiscalization.Core.Model;

namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class PostalCode : LimitedString
    {
        private static readonly StringLimitation Limitation = new StringLimitation(pattern: "[A-Z0-9][A-Z0-9\\s\\-]{1,8}[A-Z0-9]", allowEmptyOrWhiteSpace: false);

        public PostalCode(string value = "0000")
            : base(value, Limitation)
        {
        }

        public static bool IsValid(string value)
        {
            return IsValid(value, Limitation);
        }
    }
}
