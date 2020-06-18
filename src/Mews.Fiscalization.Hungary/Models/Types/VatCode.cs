using Mews.Fiscalization.Hungary.Utils;

namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class VatCode : ValidatedString
    {
        private static string regexValidation = "[1-5]{1}";

        public VatCode(string value)
            : base(value, 1, 1, regexValidation)
        {
        }

        public static bool IsValid(string value)
        {
            return ValidatedString.IsValid(value, 1, 1, regexValidation);
        }
    }
}
