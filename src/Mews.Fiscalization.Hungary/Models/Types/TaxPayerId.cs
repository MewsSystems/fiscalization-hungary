using Mews.Fiscalization.Hungary.Utils;

namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class TaxPayerId : ValidatedString
    {
        private static string regexValidation = "[0-9]{8}";

        public TaxPayerId(string value)
            :base(value, 8, 8, regexValidation)
        {
        }

        public static bool IsValid(string value)
        {
            return ValidatedString.IsValid(value, 8, 8, regexValidation);
        }
    }
}
