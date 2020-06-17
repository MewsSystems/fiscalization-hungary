namespace Mews.Fiscalization.Hungary.Models
{
    public class Info
    {
        public Info(TaxPayerId taxpayerId, VatCode vatCode, Name name, SimpleAddress address)
        {
            TaxpayerId = taxpayerId;
            VatCode = vatCode;
            Name = name;
            Address = address;
        }

        public TaxPayerId TaxpayerId { get; }

        public VatCode VatCode { get; }

        public Name Name { get; }

        public SimpleAddress Address { get; }
    }
}
