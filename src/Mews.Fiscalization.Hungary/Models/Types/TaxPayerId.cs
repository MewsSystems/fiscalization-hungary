namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class TaxPayerId
    {
        public TaxPayerId(string value) // [0-9]{8}
        {
            Value = value;
        }

        public string Value { get; }

        public static bool IsValid(string value)
        {
            return true;
        }
    }
}
