namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class City : LimitedString1to255
    {
        public City(string value) // .*[^\s].*
            : base(value)
        {
        }
    }
}
