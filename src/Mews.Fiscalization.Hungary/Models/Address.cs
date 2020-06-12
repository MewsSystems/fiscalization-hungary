using System;
using System.Security.Cryptography;
using Mews.Fiscalization.Hungary.Dto;

namespace Mews.Fiscalization.Hungary.Models
{
    public class Address
    {
        internal Address(
            string countryCode,
            string postalCode,
            string city,
            string streetName,
            string number,
            string floor,
            string door,
            AddressType type)
        {
            CountryCode = countryCode;
            PostalCode = postalCode;
            City = city;
            StreetName = streetName;
            Number = number;
            Floor = floor;
            Door = door;
            Type = type;
        }

        public string CountryCode { get; }

        public string PostalCode { get; }

        public string City { get; }

        public string StreetName { get; }

        public string Number { get; }

        public string Floor { get; }

        public string Door { get; }

        public AddressType Type { get; }

        internal static Address Map(Dto.TaxpayerAddressItemType addressItem)
        {
            var address = addressItem.taxpayerAddress;
            return new Address(
                countryCode: address.countryCode,
                postalCode: address.postalCode,
                city: address.city,
                streetName: address.streetName,
                number: address.number,
                floor: address.floor,
                door: address.door,
                type: GetAddressType(addressItem.taxpayerAddressType)
            );
        }

        private static AddressType GetAddressType(Dto.TaxpayerAddressTypeType type)
        {
            switch (type)
            {
                case TaxpayerAddressTypeType.HQ:
                    return AddressType.HQ;
                case TaxpayerAddressTypeType.SITE:
                    return AddressType.SITE;
                case TaxpayerAddressTypeType.BRANCH:
                    return AddressType.BRANCH;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}
