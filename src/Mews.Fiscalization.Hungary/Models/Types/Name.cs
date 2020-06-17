namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class Name : LimitedString1to512
    {
        public Name(string value) // .*[^\s].*
            : base(value)
        {
        }
    }
}
