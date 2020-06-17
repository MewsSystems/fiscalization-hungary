namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class InvoiceNumber : LimitedString1to50
    {
        public InvoiceNumber(string value) // .*[^\s].*
            : base(value)
        {
        }
    }
}
