using Mews.Fiscalization.Hungary.Utils;

namespace Mews.Fiscalization.Hungary.Models
{
    public class Info
    {
        public Info(TaxPayerId taxpayerId, Name name, SimpleAddress address)
        {
            TaxpayerId = Check.NotNull(taxpayerId, nameof(taxpayerId));
            Name = Check.NotNull(name, nameof(name));
            Address = Check.NotNull(address, nameof(address));
        }

        public TaxPayerId TaxpayerId { get; }

        public Name Name { get; }

        public SimpleAddress Address { get; }
    }
}
