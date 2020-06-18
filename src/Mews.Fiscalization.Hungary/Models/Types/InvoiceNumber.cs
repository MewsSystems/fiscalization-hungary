namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class InvoiceNumber : ValidatedString
    {
        private static string regexValidation = ".*[^\\s].*";

        public InvoiceNumber(string value)
            : base(value, 1, 50, regexValidation)
        {
        }

        public static bool IsValid(string value)
        {
            return ValidatedString.IsValid(value, 1, 50, regexValidation: regexValidation);
        }
    }
}
