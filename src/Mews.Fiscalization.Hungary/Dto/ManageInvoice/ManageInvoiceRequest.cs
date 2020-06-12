using System.Collections.Generic;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Hungary.Dto
{
    [XmlRoot(ElementName = "ManageInvoiceRequest", Namespace = "http://schemas.nav.gov.hu/OSA/2.0/api")]
    public class ManageInvoiceRequest : Request
    {
        [XmlElement(ElementName = "exchangeToken", Namespace = "http://schemas.nav.gov.hu/OSA/2.0/api")]
        public string ExchangeToken { get; set; }

        [XmlElement(ElementName = "invoiceOperations", Namespace = "http://schemas.nav.gov.hu/OSA/2.0/api")]
        public InvoiceOperations InvoiceOperations { get; set; }
    }

    [XmlRoot(ElementName = "invoiceOperations", Namespace = "http://schemas.nav.gov.hu/OSA/2.0/api")]
    public class InvoiceOperations
    {
        [XmlElement(ElementName = "compressedContent", Namespace = "http://schemas.nav.gov.hu/OSA/2.0/api")]
        public bool CompressedContent { get; set; }

        [XmlElement(ElementName = "invoiceOperation", Namespace = "http://schemas.nav.gov.hu/OSA/2.0/api")]
        public List<InvoiceOperation> Items { get; set; }
    }

    [XmlRoot(ElementName = "invoiceOperation", Namespace = "http://schemas.nav.gov.hu/OSA/2.0/api")]
    public class InvoiceOperation
    {
        [XmlElement(ElementName = "index", Namespace = "http://schemas.nav.gov.hu/OSA/2.0/api")]
        public string Index { get; set; }

        [XmlElement(ElementName = "invoiceOperation", Namespace = "http://schemas.nav.gov.hu/OSA/2.0/api")]
        public InvoiceOperationType InvoiceOperationType { get; set; }

        [XmlElement(ElementName = "invoiceData", Namespace = "http://schemas.nav.gov.hu/OSA/2.0/api")]
        public string InvoiceData { get; set; }
    }

    public enum InvoiceOperationType
    {
        [XmlEnum("CREATE")]
        Create,
        [XmlEnum("MODIFY")]
        Modify,
        [XmlEnum("STORNO")]
        Storno
    }
}
