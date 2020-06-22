using Mews.Fiscalization.Hungary.Utils;

namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class SupplierInfo : Info
    {
        public SupplierInfo(TaxPayerId taxpayerId, Name name, SimpleAddress address, VatCode vatCode)
            : base(taxpayerId, name, address)
        {
            VatCode = Check.NotNull(vatCode, nameof(vatCode));
        }

        public VatCode VatCode { get; }
    }
}
