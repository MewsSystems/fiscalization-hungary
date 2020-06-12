using System;
using System.Linq;

namespace Mews.Fiscalization.Hungary.Models.TaxPayer
{
    public sealed class TaxPayerData
    {
        internal TaxPayerData(string id, string name, Address address, string vatCode, DateTime? infoDate = null)
        {
            Id = id;
            Name = name;
            Address = address;
            VatCode = vatCode;
            InfoDate = infoDate;
        }

        public string Id { get; }

        public string Name { get; }

        public Address Address { get; }

        public string VatCode { get; }


        public DateTime? InfoDate { get; }

        internal static TaxPayerData Map(Dto.QueryTaxpayerResponse response)
        {
            var addressItem = response.taxpayerData.taxpayerAddressList.First();
            var taxPayerData = response.taxpayerData;
            var taxNumberDetail = taxPayerData.taxNumberDetail;
            return new TaxPayerData(
                id: taxNumberDetail.taxpayerId,
                name: taxPayerData.taxpayerName,
                address: Address.Map(addressItem),
                vatCode: taxNumberDetail.vatCode,
                infoDate: response.infoDate
            );
        }
    }
}
