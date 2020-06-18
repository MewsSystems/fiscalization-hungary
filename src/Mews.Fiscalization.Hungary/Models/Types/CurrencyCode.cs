namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class CurrencyCode : ValidatedString
    {
        private static string regexValidation = "[A-Z]{3}";

        public CurrencyCode(string value)
            : base(value, 3, 3, regexValidation)
        {
        }

        public static bool IsValid(string value)
        {
            return ValidatedString.IsValid(value, 3, 3, regexValidation);
        }
    }
}
