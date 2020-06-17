namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class Quantity
    {
        public Quantity(int value)
        {
            // A QuantityType element may contain up to 22 digits, of which up to 6 can be to the right of the decimal point.Its value can be negative.
            Value = value;
        }

        public int Value { get; }

        public static bool IsValid(int value)
        {
            return true;
        }
    }
}
