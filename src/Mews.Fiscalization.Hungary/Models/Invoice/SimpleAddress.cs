namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class SimpleAddress
    {
        public SimpleAddress(City city, CountryCode countryCode, AdditionalAddressDetail addtionalAddressDetail, PostalCode postalCode, Region region = null)
        {
            City = city;
            CountryCode = countryCode;
            AddtionalAddressDetail = addtionalAddressDetail;
            PostalCode = postalCode;
            Region = region;
        }

        public City City { get; }

        public CountryCode CountryCode { get; }

        public AdditionalAddressDetail AddtionalAddressDetail { get; }

        public PostalCode PostalCode { get; }

        public Region Region { get; }
    }
}