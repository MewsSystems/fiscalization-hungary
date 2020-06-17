namespace Mews.Fiscalization.Hungary.Models
{
    public class LimitedString1to255 : LimitedString
    {
        public LimitedString1to255(string value)
            : base(value, 1, 255)
        {
        }
    }
}
