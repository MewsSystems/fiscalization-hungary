namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class CustomerInfo : Info
    {
        public CustomerInfo(TaxPayerId taxpayerId, Name name, SimpleAddress address)
            : base(taxpayerId, name, address)
        {
        }
    }
}
