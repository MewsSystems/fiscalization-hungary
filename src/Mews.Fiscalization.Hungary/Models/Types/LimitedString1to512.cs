namespace Mews.Fiscalization.Hungary.Models
{
    public class LimitedString1to512 : LimitedString
    {
        public LimitedString1to512(string value)
            : base(value, 1, 512)
        {
        }

        public static bool IsValid(string value)
        {
            return true;
        }
    }
}
