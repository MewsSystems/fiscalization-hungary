using Mews.Fiscalization.Hungary.Utils;

namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class SimpleAddress
    {
        public SimpleAddress(City city, CountryCode countryCode, AdditionalAddressDetail additionalAddressDetail, PostalCode postalCode, Region region = null)
        {
            City = Check.NotNull(city, nameof(city));
            CountryCode = Check.NotNull(countryCode, nameof(countryCode));
            AddtionalAddressDetail = Check.NotNull(additionalAddressDetail, nameof(additionalAddressDetail));
            PostalCode = Check.NotNull(postalCode, nameof(postalCode));
            Region = region;
        }

        public City City { get; }

        public CountryCode CountryCode { get; }

        public AdditionalAddressDetail AddtionalAddressDetail { get; }

        public PostalCode PostalCode { get; }

        public Region Region { get; }
    }
}