using Mews.Fiscalization.Core.Model;

namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class City : LimitedString
    {
        private static readonly StringLimitation Limitation = new StringLimitation(maxLength: 255, pattern: ".*[^\\s].*", allowEmptyOrWhiteSpace: false);

        public City(string value)
            : base(value, Limitation)
        {
        }

        public static bool IsValid(string value)
        {
            return IsValid(value, Limitation);
        }
    }
}
