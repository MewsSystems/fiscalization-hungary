namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class CurrencyCode : ValidatedString
    {
        private static readonly string regexValidation = "[A-Z]{3}";

        public CurrencyCode(string value)
            : base(value, 3, 3, regexValidation)
        {
        }

        public static bool IsValid(string value)
        {
            return IsValid(value, 3, 3, regexValidation);
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
