namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class SimpleAddress
    {
        public SimpleAddress(string city, string countryCode, string postalCode, string region, string addtionalAddressDetail)
        {
            City = city;
            CountryCode = countryCode;
            PostalCode = postalCode;
            Region = region;
            AddtionalAddressDetail = addtionalAddressDetail;
        }

        public string City { get; }
        public string CountryCode { get; }
        public string PostalCode { get; }
        public string Region { get; }
        public string AddtionalAddressDetail { get; }
    }
}