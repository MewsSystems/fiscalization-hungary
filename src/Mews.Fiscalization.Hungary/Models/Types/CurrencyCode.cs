namespace Mews.Fiscalization.Hungary.Models.Types
{
    public sealed class CurrencyCode
    {
        public CurrencyCode(string value) // [A-Z]{3} and NOT NULL
        {
            Value = value;
        }

        public string Value { get; }
    }
}
