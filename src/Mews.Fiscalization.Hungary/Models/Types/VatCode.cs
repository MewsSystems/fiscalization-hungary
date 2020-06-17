namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class VatCode
    {
        public VatCode(string value) //[1-5]{1}
        {
            Value = value;
        }

        public string Value { get; }
    }
}
