namespace Mews.Fiscalization.Hungary.Models.Types
{
    public sealed class Login : ValidatedString
    {
        private static readonly string regexValidation = "^[0-9A-Za-z]{15}$";

        public Login(string value)
            : base(value, 15, 15, regexValidation)
        {
        }

        public static bool IsValid(string value)
        {
            return IsValid(value, 15, 15, regexValidation);
        }
    }
}
