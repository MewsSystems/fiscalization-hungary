namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class Region : ValidatedString
    {
        private static string regexValidation = ".*[^\\s].*";

        public Region(string value)
            : base(value, 1, 50, regexValidation)
        {
        }
    }
}
