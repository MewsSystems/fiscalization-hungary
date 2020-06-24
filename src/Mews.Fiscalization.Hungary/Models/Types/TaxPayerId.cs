namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class TaxPayerId : ValidatedString
    {
        public static readonly string regexValidation = "^[0-9]{8}$";

        public TaxPayerId(string value)
            :base(value, 8, 8, regexValidation)
        {
        }

        public static bool IsValid(string value)
        {
            return IsValid(value, 8, 8, regexValidation);
        }
    }
}
