using Mews.Fiscalization.Core.Model;

namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class Description : LimitedString
    {
        private static readonly StringLimitation Limitation = new StringLimitation(maxLength: 512, pattern: ".*[^\\s].*", allowEmptyOrWhiteSpace: false);

        public Description(string value)
            : base(value, Limitation)
        {
        }

        public static bool IsValid(string value)
        {
            return IsValid(value, Limitation);
        }
    }
}
