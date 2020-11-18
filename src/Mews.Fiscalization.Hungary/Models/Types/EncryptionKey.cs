using Mews.Fiscalization.Core.Model;

namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class EncryptionKey : LimitedString
    {
        private static readonly StringLimitation Limitation = new StringLimitation(pattern: "^[0-9A-Za-z]{16}$", allowEmptyOrWhiteSpace: false);

        public EncryptionKey(string value)
            : base(value, Limitation)
        {
        }

        public static bool IsValid(string value)
        {
            return IsValid(value, Limitation);
        }
    }
}
