using Mews.Fiscalization.Core.Model;

namespace Mews.Fiscalization.Hungary.Models
{
   public sealed class SigningKey : LimitedString
    {
        private static readonly StringLimitation Limitation = new StringLimitation(pattern: "^[0-9A-Za-z]{2}[-]{1}[0-9A-Za-z]{4}[-]{1}[0-9A-Za-z]{24}$", allowEmptyOrWhiteSpace: false);

        public SigningKey(string value)
            : base(value, Limitation)
        {
        }

        public static bool IsValid(string value)
        {
            return IsValid(value, Limitation);
        }
    }
}
