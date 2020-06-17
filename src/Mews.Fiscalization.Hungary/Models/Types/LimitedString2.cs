namespace Mews.Fiscalization.Hungary.Models
{
    public class LimitedString2 : LimitedString
    {
        public LimitedString2(string value)
            : base(value, 2, 2)
        {
        }

        public static bool IsValid(string value)
        {
            return true;
        }
    }
}
