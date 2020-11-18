using Mews.Fiscalization.Core.Model;

namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class Login : LimitedString
    {
        private static readonly StringLimitation Limitation = new StringLimitation(maxLength: 15, pattern: "^[0-9A-Za-z]{15}$", allowEmptyOrWhiteSpace: false);

        public Login(string value)
            : base(value, Limitation)
        {
        }

        public static bool IsValid(string value)
        {
            return IsValid(value, Limitation);
        }
    }
}
