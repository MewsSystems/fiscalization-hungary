namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class AdditionalAddressDetail : LimitedString1to255
    {
        public AdditionalAddressDetail(string value) // .*[^\s].*
            : base(value)
        {
        }
    }
}
