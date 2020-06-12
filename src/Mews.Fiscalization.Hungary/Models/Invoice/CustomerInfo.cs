namespace Mews.Fiscalization.Hungary.Models
{
    public class CustomerInfo
    {
        public CustomerInfo(string taxpayerId, string vatCode, string name, SimpleAddress address)
        {
            TaxpayerId = taxpayerId;
            VatCode = vatCode;
            Name = name;
            Address = address;
        }

        public string TaxpayerId { get; }

        public string VatCode { get; }

        public string Name { get; }

        public SimpleAddress Address { get; }
    }
}
