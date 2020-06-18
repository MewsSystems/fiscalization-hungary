namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class Description : ValidatedString
    {
        private static readonly string regexValidation = ".*[^\\s].*";

        public Description(string value)
            : base(value, 1, 512, regexValidation)
        {
        }
    }
}
