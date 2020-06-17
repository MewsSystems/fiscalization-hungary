namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class Region : LimitedString1to50
    {
        public Region(string value) // .*[^\s].* (can be null)
            : base(value)
        {
        }
    }
}
