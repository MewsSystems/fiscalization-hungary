namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class City : ValidatedString
    {
        private static string regexValidation = ".*[^\\s].*";

        public City(string value)
            : base(value, 1, 255, regexValidation)
        {
        }
    }
}
