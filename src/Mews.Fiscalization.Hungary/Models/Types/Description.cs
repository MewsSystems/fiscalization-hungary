namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class Description : ValidatedString
    {
        private static string regexValidation = ".*[^\\s].*";

        public Description(string value)
            : base(value, 1, 512, regexValidation)
        {
        }

        public static bool IsValid(string value)
        {
            return ValidatedString.IsValid(value, 1, 512, regexValidation: regexValidation);
        }
    }
}
