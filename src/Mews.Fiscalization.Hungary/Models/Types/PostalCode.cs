namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class PostalCode : ValidatedString
    {
        private static readonly string regexValidation = "[A-Z0-9][A-Z0-9\\s\\-]{1,8}[A-Z0-9]";

        public PostalCode(string value = "0000")
            : base(value, regexValidation: regexValidation)
        {
        }

        public static bool IsValid(string value)
        {
            return IsValid(value, regexValidation: regexValidation);
        }
    }
}
