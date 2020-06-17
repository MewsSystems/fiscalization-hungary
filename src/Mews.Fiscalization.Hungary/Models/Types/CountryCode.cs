namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class CountryCode : LimitedString2
    {
        public CountryCode(string value) // [A-Z]{2}
            : base(value)
        {
        }
    }
}
