namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class Description : LimitedString1to512
    {
        public Description(string value) // .*[^\s].*
            : base(value)
        {
        }
    }
}
