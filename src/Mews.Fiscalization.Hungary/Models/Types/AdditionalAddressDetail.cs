namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class AdditionalAddressDetail : ValidatedString
    {
        private static readonly string regexValidation = ".*[^\\s].*";

        public AdditionalAddressDetail(string value)
            : base(value, 1, 255, regexValidation)
        {
        }
    }
}
