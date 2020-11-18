using Mews.Fiscalization.Core.Model;

namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class Name : LimitedString
    {
        private static readonly StringLimitation Limitation = new StringLimitation(maxLength: 512, pattern: ".*[^\\s].*", allowEmptyOrWhiteSpace: false);

        public Name(string value)
            : base(value, Limitation)
        {
        }

        public static bool IsValid(string value)
        {
            return IsValid(value, Limitation);
        }
    }
}
