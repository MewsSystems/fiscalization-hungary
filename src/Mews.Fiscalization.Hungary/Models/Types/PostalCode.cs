namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class PostalCode
    {
        public PostalCode(string value = "0000") // [A-Z0-9][A-Z0-9\s\-]{1,8}[A-Z0-9] and not null
        {
            Value = value;
        }

        public string Value { get; }
    }
}
