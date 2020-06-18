namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class VatCode : ValidatedString
    {
        private static readonly string regexValidation = "[1-5]{1}";

        public VatCode(string value)
            : base(value, 1, 1, regexValidation)
        {
        }

        public static bool IsValid(string value)
        {
            return IsValid(value, 1, 1, regexValidation);
        }
    }
}
