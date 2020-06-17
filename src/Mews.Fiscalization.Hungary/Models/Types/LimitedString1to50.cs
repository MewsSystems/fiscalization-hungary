namespace Mews.Fiscalization.Hungary.Models
{
    public class LimitedString1to50 : LimitedString
    {
        public LimitedString1to50(string value)
            : base(value, 1, 50)
        {
        }

        public static bool IsValid(string value)
        {
            return IsValid(value, minLength: 1, maxLength: 50);
        }
    }
}
