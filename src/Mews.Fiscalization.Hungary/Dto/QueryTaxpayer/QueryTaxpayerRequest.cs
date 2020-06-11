using System.Xml.Serialization;

namespace Mews.Fiscalization.Hungary.Dto
{
    public sealed class QueryTaxpayerRequest : Request
    {
        public QueryTaxpayerRequest()
        {
        }

        public QueryTaxpayerRequest(RequestMetadata metadata, string taxNumber)
            : base(metadata)
        {
            TaxNumber = taxNumber;
        }

        [XmlElement("taxNumber")]
        public string TaxNumber { get; set; }
    }
}