using System.Text.RegularExpressions;

namespace Mews.Fiscalization.Hungary.Utils
{
    public static class Validations
    {
        public static readonly Regex SigningKeyRegex = new Regex("^[0-9A-Za-z]{2}[-]{1}[0-9A-Za-z]{4}[-]{1}[0-9A-Za-z]{24}$");
        public static readonly Regex UsernameRegex = new Regex("^[0-9A-Za-z]{14}$");
        public static readonly Regex TaxIdentifierRegex = new Regex("^[0-9]{8}$");
    }
}
