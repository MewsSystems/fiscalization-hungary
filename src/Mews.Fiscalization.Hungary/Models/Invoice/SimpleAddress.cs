using Mews.Fiscalization.Core.Model;

namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class SimpleAddress
    {
        public SimpleAddress(City city, CountryCode countryCode, AdditionalAddressDetail additionalAddressDetail, PostalCode postalCode, Region region = null)
        {
            City = Check.IsNotNull(city, nameof(city));
            CountryCode = Check.IsNotNull(countryCode, nameof(countryCode));
            AddtionalAddressDetail = Check.IsNotNull(additionalAddressDetail, nameof(additionalAddressDetail));
            PostalCode = Check.IsNotNull(postalCode, nameof(postalCode));
            Region = region;
        }

        public City City { get; }

        public CountryCode CountryCode { get; }

        public AdditionalAddressDetail AddtionalAddressDetail { get; }

        public PostalCode PostalCode { get; }

        public Region Region { get; }
    }
}