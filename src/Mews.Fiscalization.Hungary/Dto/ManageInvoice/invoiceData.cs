namespace Mews.Fiscalization.Hungary.Dto
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data", IsNullable = false)]
    public partial class InvoiceData : InvoiceDataType
    {
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public partial class InvoiceDataType
    {

        private string invoiceNumberField;

        private System.DateTime invoiceIssueDateField;

        private InvoiceMainType invoiceMainField;

        /// <remarks/>
        public string invoiceNumber
        {
            get
            {
                return this.invoiceNumberField;
            }
            set
            {
                this.invoiceNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime invoiceIssueDate
        {
            get
            {
                return this.invoiceIssueDateField;
            }
            set
            {
                this.invoiceIssueDateField = value;
            }
        }

        /// <remarks/>
        public InvoiceMainType invoiceMain
        {
            get
            {
                return this.invoiceMainField;
            }
            set
            {
                this.invoiceMainField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public partial class InvoiceMainType
    {

        private object[] itemsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("batchInvoice", typeof(BatchInvoiceType))]
        [System.Xml.Serialization.XmlElementAttribute("invoice", typeof(InvoiceType))]
        public object[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public partial class BatchInvoiceType
    {

        private int batchIndexField;

        private InvoiceType invoiceField;

        /// <remarks/>
        public int batchIndex
        {
            get
            {
                return this.batchIndexField;
            }
            set
            {
                this.batchIndexField = value;
            }
        }

        /// <remarks/>
        public InvoiceType invoice
        {
            get
            {
                return this.invoiceField;
            }
            set
            {
                this.invoiceField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public partial class InvoiceType
    {

        private InvoiceReferenceType invoiceReferenceField;

        private InvoiceHeadType invoiceHeadField;

        private LineType[] invoiceLinesField;

        private ProductFeeSummaryType[] productFeeSummaryField;

        private SummaryType invoiceSummaryField;

        /// <remarks/>
        public InvoiceReferenceType invoiceReference
        {
            get
            {
                return this.invoiceReferenceField;
            }
            set
            {
                this.invoiceReferenceField = value;
            }
        }

        /// <remarks/>
        public InvoiceHeadType invoiceHead
        {
            get
            {
                return this.invoiceHeadField;
            }
            set
            {
                this.invoiceHeadField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("line", IsNullable = false)]
        public LineType[] invoiceLines
        {
            get
            {
                return this.invoiceLinesField;
            }
            set
            {
                this.invoiceLinesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("productFeeSummary")]
        public ProductFeeSummaryType[] productFeeSummary
        {
            get
            {
                return this.productFeeSummaryField;
            }
            set
            {
                this.productFeeSummaryField = value;
            }
        }

        /// <remarks/>
        public SummaryType invoiceSummary
        {
            get
            {
                return this.invoiceSummaryField;
            }
            set
            {
                this.invoiceSummaryField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public partial class InvoiceReferenceType
    {

        private string originalInvoiceNumberField;

        private bool modifyWithoutMasterField;

        private int modificationIndexField;

        public InvoiceReferenceType()
        {
            this.modifyWithoutMasterField = false;
        }

        /// <remarks/>
        public string originalInvoiceNumber
        {
            get
            {
                return this.originalInvoiceNumberField;
            }
            set
            {
                this.originalInvoiceNumberField = value;
            }
        }

        /// <remarks/>
        public bool modifyWithoutMaster
        {
            get
            {
                return this.modifyWithoutMasterField;
            }
            set
            {
                this.modifyWithoutMasterField = value;
            }
        }

        /// <remarks/>
        public int modificationIndex
        {
            get
            {
                return this.modificationIndexField;
            }
            set
            {
                this.modificationIndexField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public partial class SummaryGrossDataType
    {

        private decimal invoiceGrossAmountField;

        private decimal invoiceGrossAmountHUFField;

        /// <remarks/>
        public decimal invoiceGrossAmount
        {
            get
            {
                return this.invoiceGrossAmountField;
            }
            set
            {
                this.invoiceGrossAmountField = value;
            }
        }

        /// <remarks/>
        public decimal invoiceGrossAmountHUF
        {
            get
            {
                return this.invoiceGrossAmountHUFField;
            }
            set
            {
                this.invoiceGrossAmountHUFField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public partial class SummarySimplifiedType
    {

        private decimal vatContentField;

        private decimal vatContentGrossAmountField;

        private decimal vatContentGrossAmountHUFField;

        /// <remarks/>
        public decimal vatContent
        {
            get
            {
                return this.vatContentField;
            }
            set
            {
                this.vatContentField = value;
            }
        }

        /// <remarks/>
        public decimal vatContentGrossAmount
        {
            get
            {
                return this.vatContentGrossAmountField;
            }
            set
            {
                this.vatContentGrossAmountField = value;
            }
        }

        /// <remarks/>
        public decimal vatContentGrossAmountHUF
        {
            get
            {
                return this.vatContentGrossAmountHUFField;
            }
            set
            {
                this.vatContentGrossAmountHUFField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public partial class VatRateGrossDataType
    {

        private decimal vatRateGrossAmountField;

        private decimal vatRateGrossAmountHUFField;

        /// <remarks/>
        public decimal vatRateGrossAmount
        {
            get
            {
                return this.vatRateGrossAmountField;
            }
            set
            {
                this.vatRateGrossAmountField = value;
            }
        }

        /// <remarks/>
        public decimal vatRateGrossAmountHUF
        {
            get
            {
                return this.vatRateGrossAmountHUFField;
            }
            set
            {
                this.vatRateGrossAmountHUFField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public partial class VatRateVatDataType
    {

        private decimal vatRateVatAmountField;

        private decimal vatRateVatAmountHUFField;

        /// <remarks/>
        public decimal vatRateVatAmount
        {
            get
            {
                return this.vatRateVatAmountField;
            }
            set
            {
                this.vatRateVatAmountField = value;
            }
        }

        /// <remarks/>
        public decimal vatRateVatAmountHUF
        {
            get
            {
                return this.vatRateVatAmountHUFField;
            }
            set
            {
                this.vatRateVatAmountHUFField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public partial class VatRateNetDataType
    {

        private decimal vatRateNetAmountField;

        private decimal vatRateNetAmountHUFField;

        /// <remarks/>
        public decimal vatRateNetAmount
        {
            get
            {
                return this.vatRateNetAmountField;
            }
            set
            {
                this.vatRateNetAmountField = value;
            }
        }

        /// <remarks/>
        public decimal vatRateNetAmountHUF
        {
            get
            {
                return this.vatRateNetAmountHUFField;
            }
            set
            {
                this.vatRateNetAmountHUFField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public partial class SummaryByVatRateType
    {

        private VatRateType vatRateField;

        private VatRateNetDataType vatRateNetDataField;

        private VatRateVatDataType vatRateVatDataField;

        private VatRateGrossDataType vatRateGrossDataField;

        /// <remarks/>
        public VatRateType vatRate
        {
            get
            {
                return this.vatRateField;
            }
            set
            {
                this.vatRateField = value;
            }
        }

        /// <remarks/>
        public VatRateNetDataType vatRateNetData
        {
            get
            {
                return this.vatRateNetDataField;
            }
            set
            {
                this.vatRateNetDataField = value;
            }
        }

        /// <remarks/>
        public VatRateVatDataType vatRateVatData
        {
            get
            {
                return this.vatRateVatDataField;
            }
            set
            {
                this.vatRateVatDataField = value;
            }
        }

        /// <remarks/>
        public VatRateGrossDataType vatRateGrossData
        {
            get
            {
                return this.vatRateGrossDataField;
            }
            set
            {
                this.vatRateGrossDataField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public partial class VatRateType
    {

        private object itemField;

        private ItemChoiceType1 itemElementNameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("marginSchemeNoVat", typeof(bool))]
        [System.Xml.Serialization.XmlElementAttribute("marginSchemeVat", typeof(bool))]
        [System.Xml.Serialization.XmlElementAttribute("vatDomesticReverseCharge", typeof(bool))]
        [System.Xml.Serialization.XmlElementAttribute("vatExemption", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("vatOutOfScope", typeof(bool))]
        [System.Xml.Serialization.XmlElementAttribute("vatPercentage", typeof(decimal))]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
        public object Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemChoiceType1 ItemElementName
        {
            get
            {
                return this.itemElementNameField;
            }
            set
            {
                this.itemElementNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data", IncludeInSchema = false)]
    public enum ItemChoiceType1
    {

        /// <remarks/>
        marginSchemeNoVat,

        /// <remarks/>
        marginSchemeVat,

        /// <remarks/>
        vatDomesticReverseCharge,

        /// <remarks/>
        vatExemption,

        /// <remarks/>
        vatOutOfScope,

        /// <remarks/>
        vatPercentage,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public partial class SummaryNormalType
    {

        private SummaryByVatRateType[] summaryByVatRateField;

        private decimal invoiceNetAmountField;

        private decimal invoiceNetAmountHUFField;

        private decimal invoiceVatAmountField;

        private decimal invoiceVatAmountHUFField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("summaryByVatRate")]
        public SummaryByVatRateType[] summaryByVatRate
        {
            get
            {
                return this.summaryByVatRateField;
            }
            set
            {
                this.summaryByVatRateField = value;
            }
        }

        /// <remarks/>
        public decimal invoiceNetAmount
        {
            get
            {
                return this.invoiceNetAmountField;
            }
            set
            {
                this.invoiceNetAmountField = value;
            }
        }

        /// <remarks/>
        public decimal invoiceNetAmountHUF
        {
            get
            {
                return this.invoiceNetAmountHUFField;
            }
            set
            {
                this.invoiceNetAmountHUFField = value;
            }
        }

        /// <remarks/>
        public decimal invoiceVatAmount
        {
            get
            {
                return this.invoiceVatAmountField;
            }
            set
            {
                this.invoiceVatAmountField = value;
            }
        }

        /// <remarks/>
        public decimal invoiceVatAmountHUF
        {
            get
            {
                return this.invoiceVatAmountHUFField;
            }
            set
            {
                this.invoiceVatAmountHUFField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public partial class SummaryType
    {

        private object[] itemsField;

        private SummaryGrossDataType summaryGrossDataField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("summaryNormal", typeof(SummaryNormalType))]
        [System.Xml.Serialization.XmlElementAttribute("summarySimplified", typeof(SummarySimplifiedType))]
        public object[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        /// <remarks/>
        public SummaryGrossDataType summaryGrossData
        {
            get
            {
                return this.summaryGrossDataField;
            }
            set
            {
                this.summaryGrossDataField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public partial class PaymentEvidenceDocumentDataType
    {

        private string evidenceDocumentNoField;

        private System.DateTime evidenceDocumentDateField;

        private string obligatedNameField;

        private AddressType obligatedAddressField;

        private TaxNumberType obligatedTaxNumberField;

        /// <remarks/>
        public string evidenceDocumentNo
        {
            get
            {
                return this.evidenceDocumentNoField;
            }
            set
            {
                this.evidenceDocumentNoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime evidenceDocumentDate
        {
            get
            {
                return this.evidenceDocumentDateField;
            }
            set
            {
                this.evidenceDocumentDateField = value;
            }
        }

        /// <remarks/>
        public string obligatedName
        {
            get
            {
                return this.obligatedNameField;
            }
            set
            {
                this.obligatedNameField = value;
            }
        }

        /// <remarks/>
        public AddressType obligatedAddress
        {
            get
            {
                return this.obligatedAddressField;
            }
            set
            {
                this.obligatedAddressField = value;
            }
        }

        /// <remarks/>
        public TaxNumberType obligatedTaxNumber
        {
            get
            {
                return this.obligatedTaxNumberField;
            }
            set
            {
                this.obligatedTaxNumberField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public partial class AddressType
    {

        private object itemField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("detailedAddress", typeof(DetailedAddressType))]
        [System.Xml.Serialization.XmlElementAttribute("simpleAddress", typeof(SimpleAddressType))]
        public object Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public partial class DetailedAddressType
    {

        private string countryCodeField;

        private string regionField;

        private string postalCodeField;

        private string cityField;

        private string streetNameField;

        private string publicPlaceCategoryField;

        private string numberField;

        private string buildingField;

        private string staircaseField;

        private string floorField;

        private string doorField;

        private string lotNumberField;

        public DetailedAddressType()
        {
            this.countryCodeField = "HU";
        }

        /// <remarks/>
        public string countryCode
        {
            get
            {
                return this.countryCodeField;
            }
            set
            {
                this.countryCodeField = value;
            }
        }

        /// <remarks/>
        public string region
        {
            get
            {
                return this.regionField;
            }
            set
            {
                this.regionField = value;
            }
        }

        /// <remarks/>
        public string postalCode
        {
            get
            {
                return this.postalCodeField;
            }
            set
            {
                this.postalCodeField = value;
            }
        }

        /// <remarks/>
        public string city
        {
            get
            {
                return this.cityField;
            }
            set
            {
                this.cityField = value;
            }
        }

        /// <remarks/>
        public string streetName
        {
            get
            {
                return this.streetNameField;
            }
            set
            {
                this.streetNameField = value;
            }
        }

        /// <remarks/>
        public string publicPlaceCategory
        {
            get
            {
                return this.publicPlaceCategoryField;
            }
            set
            {
                this.publicPlaceCategoryField = value;
            }
        }

        /// <remarks/>
        public string number
        {
            get
            {
                return this.numberField;
            }
            set
            {
                this.numberField = value;
            }
        }

        /// <remarks/>
        public string building
        {
            get
            {
                return this.buildingField;
            }
            set
            {
                this.buildingField = value;
            }
        }

        /// <remarks/>
        public string staircase
        {
            get
            {
                return this.staircaseField;
            }
            set
            {
                this.staircaseField = value;
            }
        }

        /// <remarks/>
        public string floor
        {
            get
            {
                return this.floorField;
            }
            set
            {
                this.floorField = value;
            }
        }

        /// <remarks/>
        public string door
        {
            get
            {
                return this.doorField;
            }
            set
            {
                this.doorField = value;
            }
        }

        /// <remarks/>
        public string lotNumber
        {
            get
            {
                return this.lotNumberField;
            }
            set
            {
                this.lotNumberField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public partial class SimpleAddressType
    {

        private string countryCodeField;

        private string regionField;

        private string postalCodeField;

        private string cityField;

        private string additionalAddressDetailField;

        public SimpleAddressType()
        {
            this.countryCodeField = "HU";
        }

        /// <remarks/>
        public string countryCode
        {
            get
            {
                return this.countryCodeField;
            }
            set
            {
                this.countryCodeField = value;
            }
        }

        /// <remarks/>
        public string region
        {
            get
            {
                return this.regionField;
            }
            set
            {
                this.regionField = value;
            }
        }

        /// <remarks/>
        public string postalCode
        {
            get
            {
                return this.postalCodeField;
            }
            set
            {
                this.postalCodeField = value;
            }
        }

        /// <remarks/>
        public string city
        {
            get
            {
                return this.cityField;
            }
            set
            {
                this.cityField = value;
            }
        }

        /// <remarks/>
        public string additionalAddressDetail
        {
            get
            {
                return this.additionalAddressDetailField;
            }
            set
            {
                this.additionalAddressDetailField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public partial class TaxNumberType
    {

        private string taxpayerIdField;

        private string vatCodeField;

        private string countyCodeField;

        /// <remarks/>
        public string taxpayerId
        {
            get
            {
                return this.taxpayerIdField;
            }
            set
            {
                this.taxpayerIdField = value;
            }
        }

        /// <remarks/>
        public string vatCode
        {
            get
            {
                return this.vatCodeField;
            }
            set
            {
                this.vatCodeField = value;
            }
        }

        /// <remarks/>
        public string countyCode
        {
            get
            {
                return this.countyCodeField;
            }
            set
            {
                this.countyCodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public partial class ProductFeeSummaryType
    {

        private ProductFeeOperationType productFeeOperationField;

        private ProductFeeDataType[] productFeeDataField;

        private decimal productChargeSumField;

        private PaymentEvidenceDocumentDataType paymentEvidenceDocumentDataField;

        /// <remarks/>
        public ProductFeeOperationType productFeeOperation
        {
            get
            {
                return this.productFeeOperationField;
            }
            set
            {
                this.productFeeOperationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("productFeeData")]
        public ProductFeeDataType[] productFeeData
        {
            get
            {
                return this.productFeeDataField;
            }
            set
            {
                this.productFeeDataField = value;
            }
        }

        /// <remarks/>
        public decimal productChargeSum
        {
            get
            {
                return this.productChargeSumField;
            }
            set
            {
                this.productChargeSumField = value;
            }
        }

        /// <remarks/>
        public PaymentEvidenceDocumentDataType paymentEvidenceDocumentData
        {
            get
            {
                return this.paymentEvidenceDocumentDataField;
            }
            set
            {
                this.paymentEvidenceDocumentDataField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public enum ProductFeeOperationType
    {

        /// <remarks/>
        REFUND,

        /// <remarks/>
        DEPOSIT,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public partial class ProductFeeDataType
    {

        private ProductCodeType productFeeCodeField;

        private decimal productFeeQuantityField;

        private ProductFeeMeasuringUnitType productFeeMeasuringUnitField;

        private decimal productFeeRateField;

        private decimal productFeeAmountField;

        /// <remarks/>
        public ProductCodeType productFeeCode
        {
            get
            {
                return this.productFeeCodeField;
            }
            set
            {
                this.productFeeCodeField = value;
            }
        }

        /// <remarks/>
        public decimal productFeeQuantity
        {
            get
            {
                return this.productFeeQuantityField;
            }
            set
            {
                this.productFeeQuantityField = value;
            }
        }

        /// <remarks/>
        public ProductFeeMeasuringUnitType productFeeMeasuringUnit
        {
            get
            {
                return this.productFeeMeasuringUnitField;
            }
            set
            {
                this.productFeeMeasuringUnitField = value;
            }
        }

        /// <remarks/>
        public decimal productFeeRate
        {
            get
            {
                return this.productFeeRateField;
            }
            set
            {
                this.productFeeRateField = value;
            }
        }

        /// <remarks/>
        public decimal productFeeAmount
        {
            get
            {
                return this.productFeeAmountField;
            }
            set
            {
                this.productFeeAmountField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public partial class ProductCodeType
    {

        private ProductCodeCategoryType productCodeCategoryField;

        private string itemField;

        private ItemChoiceType itemElementNameField;

        /// <remarks/>
        public ProductCodeCategoryType productCodeCategory
        {
            get
            {
                return this.productCodeCategoryField;
            }
            set
            {
                this.productCodeCategoryField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("productCodeOwnValue", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("productCodeValue", typeof(string))]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
        public string Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemChoiceType ItemElementName
        {
            get
            {
                return this.itemElementNameField;
            }
            set
            {
                this.itemElementNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public enum ProductCodeCategoryType
    {

        /// <remarks/>
        VTSZ,

        /// <remarks/>
        SZJ,

        /// <remarks/>
        KN,

        /// <remarks/>
        AHK,

        /// <remarks/>
        CSK,

        /// <remarks/>
        KT,

        /// <remarks/>
        EJ,

        /// <remarks/>
        TESZOR,

        /// <remarks/>
        OWN,

        /// <remarks/>
        OTHER,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data", IncludeInSchema = false)]
    public enum ItemChoiceType
    {

        /// <remarks/>
        productCodeOwnValue,

        /// <remarks/>
        productCodeValue,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public enum ProductFeeMeasuringUnitType
    {

        /// <remarks/>
        DARAB,

        /// <remarks/>
        KG,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public partial class CustomerDeclarationType
    {

        private ProductStreamType productStreamField;

        private decimal productFeeWeightField;

        private bool productFeeWeightFieldSpecified;

        /// <remarks/>
        public ProductStreamType productStream
        {
            get
            {
                return this.productStreamField;
            }
            set
            {
                this.productStreamField = value;
            }
        }

        /// <remarks/>
        public decimal productFeeWeight
        {
            get
            {
                return this.productFeeWeightField;
            }
            set
            {
                this.productFeeWeightField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool productFeeWeightSpecified
        {
            get
            {
                return this.productFeeWeightFieldSpecified;
            }
            set
            {
                this.productFeeWeightFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public enum ProductStreamType
    {

        /// <remarks/>
        BATTERY,

        /// <remarks/>
        PACKAGING,

        /// <remarks/>
        OTHER_PETROL,

        /// <remarks/>
        ELECTRONIC,

        /// <remarks/>
        TIRE,

        /// <remarks/>
        COMMERCIAL,

        /// <remarks/>
        PLASTIC,

        /// <remarks/>
        OTHER_CHEMICAL,

        /// <remarks/>
        PAPER,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public partial class ProductFeeTakeoverDataType
    {

        private TakeoverType takeoverReasonField;

        private decimal takeoverAmountField;

        private bool takeoverAmountFieldSpecified;

        /// <remarks/>
        public TakeoverType takeoverReason
        {
            get
            {
                return this.takeoverReasonField;
            }
            set
            {
                this.takeoverReasonField = value;
            }
        }

        /// <remarks/>
        public decimal takeoverAmount
        {
            get
            {
                return this.takeoverAmountField;
            }
            set
            {
                this.takeoverAmountField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool takeoverAmountSpecified
        {
            get
            {
                return this.takeoverAmountFieldSpecified;
            }
            set
            {
                this.takeoverAmountFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public enum TakeoverType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("01")]
        Item01,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("02_aa")]
        Item02_aa,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("02_ab")]
        Item02_ab,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("02_b")]
        Item02_b,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("02_c")]
        Item02_c,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("02_d")]
        Item02_d,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("02_ea")]
        Item02_ea,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("02_eb")]
        Item02_eb,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("02_fa")]
        Item02_fa,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("02_fb")]
        Item02_fb,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("02_ga")]
        Item02_ga,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("02_gb")]
        Item02_gb,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public partial class ProductFeeClauseType
    {

        private object itemField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("customerDeclaration", typeof(CustomerDeclarationType))]
        [System.Xml.Serialization.XmlElementAttribute("productFeeTakeoverData", typeof(ProductFeeTakeoverDataType))]
        public object Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public partial class DieselOilPurchaseType
    {

        private SimpleAddressType purchaseLocationField;

        private System.DateTime purchaseDateField;

        private string vehicleRegistrationNumberField;

        private decimal dieselOilQuantityField;

        private bool dieselOilQuantityFieldSpecified;

        /// <remarks/>
        public SimpleAddressType purchaseLocation
        {
            get
            {
                return this.purchaseLocationField;
            }
            set
            {
                this.purchaseLocationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime purchaseDate
        {
            get
            {
                return this.purchaseDateField;
            }
            set
            {
                this.purchaseDateField = value;
            }
        }

        /// <remarks/>
        public string vehicleRegistrationNumber
        {
            get
            {
                return this.vehicleRegistrationNumberField;
            }
            set
            {
                this.vehicleRegistrationNumberField = value;
            }
        }

        /// <remarks/>
        public decimal dieselOilQuantity
        {
            get
            {
                return this.dieselOilQuantityField;
            }
            set
            {
                this.dieselOilQuantityField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool dieselOilQuantitySpecified
        {
            get
            {
                return this.dieselOilQuantityFieldSpecified;
            }
            set
            {
                this.dieselOilQuantityFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public partial class AircraftType
    {

        private decimal takeOffWeightField;

        private bool airCargoField;

        private decimal operationHoursField;

        public AircraftType()
        {
            this.airCargoField = false;
        }

        /// <remarks/>
        public decimal takeOffWeight
        {
            get
            {
                return this.takeOffWeightField;
            }
            set
            {
                this.takeOffWeightField = value;
            }
        }

        /// <remarks/>
        public bool airCargo
        {
            get
            {
                return this.airCargoField;
            }
            set
            {
                this.airCargoField = value;
            }
        }

        /// <remarks/>
        public decimal operationHours
        {
            get
            {
                return this.operationHoursField;
            }
            set
            {
                this.operationHoursField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public partial class VesselType
    {

        private decimal lengthField;

        private bool activityReferredField;

        private decimal sailedHoursField;

        public VesselType()
        {
            this.activityReferredField = false;
        }

        /// <remarks/>
        public decimal length
        {
            get
            {
                return this.lengthField;
            }
            set
            {
                this.lengthField = value;
            }
        }

        /// <remarks/>
        public bool activityReferred
        {
            get
            {
                return this.activityReferredField;
            }
            set
            {
                this.activityReferredField = value;
            }
        }

        /// <remarks/>
        public decimal sailedHours
        {
            get
            {
                return this.sailedHoursField;
            }
            set
            {
                this.sailedHoursField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public partial class VehicleType
    {

        private decimal engineCapacityField;

        private decimal enginePowerField;

        private decimal kmsField;

        /// <remarks/>
        public decimal engineCapacity
        {
            get
            {
                return this.engineCapacityField;
            }
            set
            {
                this.engineCapacityField = value;
            }
        }

        /// <remarks/>
        public decimal enginePower
        {
            get
            {
                return this.enginePowerField;
            }
            set
            {
                this.enginePowerField = value;
            }
        }

        /// <remarks/>
        public decimal kms
        {
            get
            {
                return this.kmsField;
            }
            set
            {
                this.kmsField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public partial class NewTransportMeanType
    {

        private string brandField;

        private string serialNumField;

        private string engineNumField;

        private System.DateTime firstEntryIntoServiceField;

        private object itemField;

        /// <remarks/>
        public string brand
        {
            get
            {
                return this.brandField;
            }
            set
            {
                this.brandField = value;
            }
        }

        /// <remarks/>
        public string serialNum
        {
            get
            {
                return this.serialNumField;
            }
            set
            {
                this.serialNumField = value;
            }
        }

        /// <remarks/>
        public string engineNum
        {
            get
            {
                return this.engineNumField;
            }
            set
            {
                this.engineNumField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime firstEntryIntoService
        {
            get
            {
                return this.firstEntryIntoServiceField;
            }
            set
            {
                this.firstEntryIntoServiceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("aircraft", typeof(AircraftType))]
        [System.Xml.Serialization.XmlElementAttribute("vehicle", typeof(VehicleType))]
        [System.Xml.Serialization.XmlElementAttribute("vessel", typeof(VesselType))]
        public object Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public partial class AggregateInvoiceLineDataType
    {

        private decimal lineExchangeRateField;

        private bool lineExchangeRateFieldSpecified;

        private System.DateTime lineDeliveryDateField;

        /// <remarks/>
        public decimal lineExchangeRate
        {
            get
            {
                return this.lineExchangeRateField;
            }
            set
            {
                this.lineExchangeRateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool lineExchangeRateSpecified
        {
            get
            {
                return this.lineExchangeRateFieldSpecified;
            }
            set
            {
                this.lineExchangeRateFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime lineDeliveryDate
        {
            get
            {
                return this.lineDeliveryDateField;
            }
            set
            {
                this.lineDeliveryDateField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public partial class LineAmountsSimplifiedType
    {

        private decimal lineVatContentField;

        private bool lineVatContentFieldSpecified;

        private decimal lineGrossAmountSimplifiedField;

        private decimal lineGrossAmountSimplifiedHUFField;

        /// <remarks/>
        public decimal lineVatContent
        {
            get
            {
                return this.lineVatContentField;
            }
            set
            {
                this.lineVatContentField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool lineVatContentSpecified
        {
            get
            {
                return this.lineVatContentFieldSpecified;
            }
            set
            {
                this.lineVatContentFieldSpecified = value;
            }
        }

        /// <remarks/>
        public decimal lineGrossAmountSimplified
        {
            get
            {
                return this.lineGrossAmountSimplifiedField;
            }
            set
            {
                this.lineGrossAmountSimplifiedField = value;
            }
        }

        /// <remarks/>
        public decimal lineGrossAmountSimplifiedHUF
        {
            get
            {
                return this.lineGrossAmountSimplifiedHUFField;
            }
            set
            {
                this.lineGrossAmountSimplifiedHUFField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public partial class LineGrossAmountDataType
    {

        private decimal lineGrossAmountNormalField;

        private decimal lineGrossAmountNormalHUFField;

        /// <remarks/>
        public decimal lineGrossAmountNormal
        {
            get
            {
                return this.lineGrossAmountNormalField;
            }
            set
            {
                this.lineGrossAmountNormalField = value;
            }
        }

        /// <remarks/>
        public decimal lineGrossAmountNormalHUF
        {
            get
            {
                return this.lineGrossAmountNormalHUFField;
            }
            set
            {
                this.lineGrossAmountNormalHUFField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public partial class LineVatDataType
    {

        private decimal lineVatAmountField;

        private decimal lineVatAmountHUFField;

        /// <remarks/>
        public decimal lineVatAmount
        {
            get
            {
                return this.lineVatAmountField;
            }
            set
            {
                this.lineVatAmountField = value;
            }
        }

        /// <remarks/>
        public decimal lineVatAmountHUF
        {
            get
            {
                return this.lineVatAmountHUFField;
            }
            set
            {
                this.lineVatAmountHUFField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public partial class LineNetAmountDataType
    {

        private decimal lineNetAmountField;

        private decimal lineNetAmountHUFField;

        /// <remarks/>
        public decimal lineNetAmount
        {
            get
            {
                return this.lineNetAmountField;
            }
            set
            {
                this.lineNetAmountField = value;
            }
        }

        /// <remarks/>
        public decimal lineNetAmountHUF
        {
            get
            {
                return this.lineNetAmountHUFField;
            }
            set
            {
                this.lineNetAmountHUFField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public partial class LineAmountsNormalType
    {

        private LineNetAmountDataType lineNetAmountDataField;

        private VatRateType lineVatRateField;

        private LineVatDataType lineVatDataField;

        private LineGrossAmountDataType lineGrossAmountDataField;

        /// <remarks/>
        public LineNetAmountDataType lineNetAmountData
        {
            get
            {
                return this.lineNetAmountDataField;
            }
            set
            {
                this.lineNetAmountDataField = value;
            }
        }

        /// <remarks/>
        public VatRateType lineVatRate
        {
            get
            {
                return this.lineVatRateField;
            }
            set
            {
                this.lineVatRateField = value;
            }
        }

        /// <remarks/>
        public LineVatDataType lineVatData
        {
            get
            {
                return this.lineVatDataField;
            }
            set
            {
                this.lineVatDataField = value;
            }
        }

        /// <remarks/>
        public LineGrossAmountDataType lineGrossAmountData
        {
            get
            {
                return this.lineGrossAmountDataField;
            }
            set
            {
                this.lineGrossAmountDataField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public partial class DiscountDataType
    {

        private string discountDescriptionField;

        private decimal discountValueField;

        private bool discountValueFieldSpecified;

        private decimal discountRateField;

        private bool discountRateFieldSpecified;

        /// <remarks/>
        public string discountDescription
        {
            get
            {
                return this.discountDescriptionField;
            }
            set
            {
                this.discountDescriptionField = value;
            }
        }

        /// <remarks/>
        public decimal discountValue
        {
            get
            {
                return this.discountValueField;
            }
            set
            {
                this.discountValueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool discountValueSpecified
        {
            get
            {
                return this.discountValueFieldSpecified;
            }
            set
            {
                this.discountValueFieldSpecified = value;
            }
        }

        /// <remarks/>
        public decimal discountRate
        {
            get
            {
                return this.discountRateField;
            }
            set
            {
                this.discountRateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool discountRateSpecified
        {
            get
            {
                return this.discountRateFieldSpecified;
            }
            set
            {
                this.discountRateFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public partial class LineModificationReferenceType
    {

        private string lineNumberReferenceField;

        private LineOperationType lineOperationField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger")]
        public string lineNumberReference
        {
            get
            {
                return this.lineNumberReferenceField;
            }
            set
            {
                this.lineNumberReferenceField = value;
            }
        }

        /// <remarks/>
        public LineOperationType lineOperation
        {
            get
            {
                return this.lineOperationField;
            }
            set
            {
                this.lineOperationField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public enum LineOperationType
    {

        /// <remarks/>
        CREATE,

        /// <remarks/>
        MODIFY,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public partial class LineType
    {

        private string lineNumberField;

        private LineModificationReferenceType lineModificationReferenceField;

        private string[] referencesToOtherLinesField;

        private bool advanceIndicatorField;

        private ProductCodeType[] productCodesField;

        private bool lineExpressionIndicatorField;

        private LineNatureIndicatorType lineNatureIndicatorField;

        private bool lineNatureIndicatorFieldSpecified;

        private string lineDescriptionField;

        private decimal quantityField;

        private bool quantityFieldSpecified;

        private UnitOfMeasureType unitOfMeasureField;

        private bool unitOfMeasureFieldSpecified;

        private string unitOfMeasureOwnField;

        private decimal unitPriceField;

        private bool unitPriceFieldSpecified;

        private decimal unitPriceHUFField;

        private bool unitPriceHUFFieldSpecified;

        private DiscountDataType lineDiscountDataField;

        private object itemField;

        private bool intermediatedServiceField;

        private AggregateInvoiceLineDataType aggregateInvoiceLineDataField;

        private NewTransportMeanType newTransportMeanField;

        private bool depositIndicatorField;

        private MarginSchemeType marginSchemeIndicatorField;

        private bool marginSchemeIndicatorFieldSpecified;

        private string[] ekaerIdsField;

        private bool obligatedForProductFeeField;

        private decimal gPCExciseField;

        private bool gPCExciseFieldSpecified;

        private DieselOilPurchaseType dieselOilPurchaseField;

        private bool netaDeclarationField;

        private ProductFeeClauseType productFeeClauseField;

        private ProductFeeDataType[] lineProductFeeContentField;

        private AdditionalDataType[] additionalLineDataField;

        public LineType()
        {
            this.advanceIndicatorField = false;
            this.lineExpressionIndicatorField = false;
            this.intermediatedServiceField = false;
            this.depositIndicatorField = false;
            this.obligatedForProductFeeField = false;
            this.netaDeclarationField = false;
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger")]
        public string lineNumber
        {
            get
            {
                return this.lineNumberField;
            }
            set
            {
                this.lineNumberField = value;
            }
        }

        /// <remarks/>
        public LineModificationReferenceType lineModificationReference
        {
            get
            {
                return this.lineModificationReferenceField;
            }
            set
            {
                this.lineModificationReferenceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("referenceToOtherLine", DataType = "nonNegativeInteger", IsNullable = false)]
        public string[] referencesToOtherLines
        {
            get
            {
                return this.referencesToOtherLinesField;
            }
            set
            {
                this.referencesToOtherLinesField = value;
            }
        }

        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool advanceIndicator
        {
            get
            {
                return this.advanceIndicatorField;
            }
            set
            {
                this.advanceIndicatorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("productCode", IsNullable = false)]
        public ProductCodeType[] productCodes
        {
            get
            {
                return this.productCodesField;
            }
            set
            {
                this.productCodesField = value;
            }
        }

        /// <remarks/>
        public bool lineExpressionIndicator
        {
            get
            {
                return this.lineExpressionIndicatorField;
            }
            set
            {
                this.lineExpressionIndicatorField = value;
            }
        }

        /// <remarks/>
        public LineNatureIndicatorType lineNatureIndicator
        {
            get
            {
                return this.lineNatureIndicatorField;
            }
            set
            {
                this.lineNatureIndicatorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool lineNatureIndicatorSpecified
        {
            get
            {
                return this.lineNatureIndicatorFieldSpecified;
            }
            set
            {
                this.lineNatureIndicatorFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string lineDescription
        {
            get
            {
                return this.lineDescriptionField;
            }
            set
            {
                this.lineDescriptionField = value;
            }
        }

        /// <remarks/>
        public decimal quantity
        {
            get
            {
                return this.quantityField;
            }
            set
            {
                this.quantityField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool quantitySpecified
        {
            get
            {
                return this.quantityFieldSpecified;
            }
            set
            {
                this.quantityFieldSpecified = value;
            }
        }

        /// <remarks/>
        public UnitOfMeasureType unitOfMeasure
        {
            get
            {
                return this.unitOfMeasureField;
            }
            set
            {
                this.unitOfMeasureField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool unitOfMeasureSpecified
        {
            get
            {
                return this.unitOfMeasureFieldSpecified;
            }
            set
            {
                this.unitOfMeasureFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string unitOfMeasureOwn
        {
            get
            {
                return this.unitOfMeasureOwnField;
            }
            set
            {
                this.unitOfMeasureOwnField = value;
            }
        }

        /// <remarks/>
        public decimal unitPrice
        {
            get
            {
                return this.unitPriceField;
            }
            set
            {
                this.unitPriceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool unitPriceSpecified
        {
            get
            {
                return this.unitPriceFieldSpecified;
            }
            set
            {
                this.unitPriceFieldSpecified = value;
            }
        }

        /// <remarks/>
        public decimal unitPriceHUF
        {
            get
            {
                return this.unitPriceHUFField;
            }
            set
            {
                this.unitPriceHUFField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool unitPriceHUFSpecified
        {
            get
            {
                return this.unitPriceHUFFieldSpecified;
            }
            set
            {
                this.unitPriceHUFFieldSpecified = value;
            }
        }

        /// <remarks/>
        public DiscountDataType lineDiscountData
        {
            get
            {
                return this.lineDiscountDataField;
            }
            set
            {
                this.lineDiscountDataField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("lineAmountsNormal", typeof(LineAmountsNormalType))]
        [System.Xml.Serialization.XmlElementAttribute("lineAmountsSimplified", typeof(LineAmountsSimplifiedType))]
        public object Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }

        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool intermediatedService
        {
            get
            {
                return this.intermediatedServiceField;
            }
            set
            {
                this.intermediatedServiceField = value;
            }
        }

        /// <remarks/>
        public AggregateInvoiceLineDataType aggregateInvoiceLineData
        {
            get
            {
                return this.aggregateInvoiceLineDataField;
            }
            set
            {
                this.aggregateInvoiceLineDataField = value;
            }
        }

        /// <remarks/>
        public NewTransportMeanType newTransportMean
        {
            get
            {
                return this.newTransportMeanField;
            }
            set
            {
                this.newTransportMeanField = value;
            }
        }

        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool depositIndicator
        {
            get
            {
                return this.depositIndicatorField;
            }
            set
            {
                this.depositIndicatorField = value;
            }
        }

        /// <remarks/>
        public MarginSchemeType marginSchemeIndicator
        {
            get
            {
                return this.marginSchemeIndicatorField;
            }
            set
            {
                this.marginSchemeIndicatorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool marginSchemeIndicatorSpecified
        {
            get
            {
                return this.marginSchemeIndicatorFieldSpecified;
            }
            set
            {
                this.marginSchemeIndicatorFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ekaerId", IsNullable = false)]
        public string[] ekaerIds
        {
            get
            {
                return this.ekaerIdsField;
            }
            set
            {
                this.ekaerIdsField = value;
            }
        }

        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool obligatedForProductFee
        {
            get
            {
                return this.obligatedForProductFeeField;
            }
            set
            {
                this.obligatedForProductFeeField = value;
            }
        }

        /// <remarks/>
        public decimal GPCExcise
        {
            get
            {
                return this.gPCExciseField;
            }
            set
            {
                this.gPCExciseField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool GPCExciseSpecified
        {
            get
            {
                return this.gPCExciseFieldSpecified;
            }
            set
            {
                this.gPCExciseFieldSpecified = value;
            }
        }

        /// <remarks/>
        public DieselOilPurchaseType dieselOilPurchase
        {
            get
            {
                return this.dieselOilPurchaseField;
            }
            set
            {
                this.dieselOilPurchaseField = value;
            }
        }

        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool netaDeclaration
        {
            get
            {
                return this.netaDeclarationField;
            }
            set
            {
                this.netaDeclarationField = value;
            }
        }

        /// <remarks/>
        public ProductFeeClauseType productFeeClause
        {
            get
            {
                return this.productFeeClauseField;
            }
            set
            {
                this.productFeeClauseField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("lineProductFeeContent")]
        public ProductFeeDataType[] lineProductFeeContent
        {
            get
            {
                return this.lineProductFeeContentField;
            }
            set
            {
                this.lineProductFeeContentField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("additionalLineData")]
        public AdditionalDataType[] additionalLineData
        {
            get
            {
                return this.additionalLineDataField;
            }
            set
            {
                this.additionalLineDataField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public enum LineNatureIndicatorType
    {

        /// <remarks/>
        PRODUCT,

        /// <remarks/>
        SERVICE,

        /// <remarks/>
        OTHER,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public enum UnitOfMeasureType
    {

        /// <remarks/>
        PIECE,

        /// <remarks/>
        KILOGRAM,

        /// <remarks/>
        TON,

        /// <remarks/>
        KWH,

        /// <remarks/>
        DAY,

        /// <remarks/>
        HOUR,

        /// <remarks/>
        MINUTE,

        /// <remarks/>
        MONTH,

        /// <remarks/>
        LITER,

        /// <remarks/>
        KILOMETER,

        /// <remarks/>
        CUBIC_METER,

        /// <remarks/>
        METER,

        /// <remarks/>
        LINEAR_METER,

        /// <remarks/>
        CARTON,

        /// <remarks/>
        PACK,

        /// <remarks/>
        OWN,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public enum MarginSchemeType
    {

        /// <remarks/>
        TRAVEL_AGENCY,

        /// <remarks/>
        SECOND_HAND,

        /// <remarks/>
        ARTWORK,

        /// <remarks/>
        ANTIQUES,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public partial class AdditionalDataType
    {

        private string dataNameField;

        private string dataDescriptionField;

        private string dataValueField;

        /// <remarks/>
        public string dataName
        {
            get
            {
                return this.dataNameField;
            }
            set
            {
                this.dataNameField = value;
            }
        }

        /// <remarks/>
        public string dataDescription
        {
            get
            {
                return this.dataDescriptionField;
            }
            set
            {
                this.dataDescriptionField = value;
            }
        }

        /// <remarks/>
        public string dataValue
        {
            get
            {
                return this.dataValueField;
            }
            set
            {
                this.dataValueField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public partial class InvoiceDetailType
    {

        private InvoiceCategoryType invoiceCategoryField;

        private System.DateTime invoiceDeliveryDateField;

        private System.DateTime invoiceDeliveryPeriodStartField;

        private bool invoiceDeliveryPeriodStartFieldSpecified;

        private System.DateTime invoiceDeliveryPeriodEndField;

        private bool invoiceDeliveryPeriodEndFieldSpecified;

        private System.DateTime invoiceAccountingDeliveryDateField;

        private bool invoiceAccountingDeliveryDateFieldSpecified;

        private bool periodicalSettlementField;

        private bool smallBusinessIndicatorField;

        private string currencyCodeField;

        private decimal exchangeRateField;

        private bool selfBillingIndicatorField;

        private PaymentMethodType paymentMethodField;

        private bool paymentMethodFieldSpecified;

        private System.DateTime paymentDateField;

        private bool paymentDateFieldSpecified;

        private bool cashAccountingIndicatorField;

        private InvoiceAppearanceType invoiceAppearanceField;

        private string electronicInvoiceHashField;

        private AdditionalDataType[] additionalInvoiceDataField;

        public InvoiceDetailType()
        {
            this.periodicalSettlementField = false;
            this.smallBusinessIndicatorField = false;
            this.selfBillingIndicatorField = false;
            this.cashAccountingIndicatorField = false;
        }

        /// <remarks/>
        public InvoiceCategoryType invoiceCategory
        {
            get
            {
                return this.invoiceCategoryField;
            }
            set
            {
                this.invoiceCategoryField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime invoiceDeliveryDate
        {
            get
            {
                return this.invoiceDeliveryDateField;
            }
            set
            {
                this.invoiceDeliveryDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime invoiceDeliveryPeriodStart
        {
            get
            {
                return this.invoiceDeliveryPeriodStartField;
            }
            set
            {
                this.invoiceDeliveryPeriodStartField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool invoiceDeliveryPeriodStartSpecified
        {
            get
            {
                return this.invoiceDeliveryPeriodStartFieldSpecified;
            }
            set
            {
                this.invoiceDeliveryPeriodStartFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime invoiceDeliveryPeriodEnd
        {
            get
            {
                return this.invoiceDeliveryPeriodEndField;
            }
            set
            {
                this.invoiceDeliveryPeriodEndField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool invoiceDeliveryPeriodEndSpecified
        {
            get
            {
                return this.invoiceDeliveryPeriodEndFieldSpecified;
            }
            set
            {
                this.invoiceDeliveryPeriodEndFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime invoiceAccountingDeliveryDate
        {
            get
            {
                return this.invoiceAccountingDeliveryDateField;
            }
            set
            {
                this.invoiceAccountingDeliveryDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool invoiceAccountingDeliveryDateSpecified
        {
            get
            {
                return this.invoiceAccountingDeliveryDateFieldSpecified;
            }
            set
            {
                this.invoiceAccountingDeliveryDateFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool periodicalSettlement
        {
            get
            {
                return this.periodicalSettlementField;
            }
            set
            {
                this.periodicalSettlementField = value;
            }
        }

        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool smallBusinessIndicator
        {
            get
            {
                return this.smallBusinessIndicatorField;
            }
            set
            {
                this.smallBusinessIndicatorField = value;
            }
        }

        /// <remarks/>
        public string currencyCode
        {
            get
            {
                return this.currencyCodeField;
            }
            set
            {
                this.currencyCodeField = value;
            }
        }

        /// <remarks/>
        public decimal exchangeRate
        {
            get
            {
                return this.exchangeRateField;
            }
            set
            {
                this.exchangeRateField = value;
            }
        }

        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool selfBillingIndicator
        {
            get
            {
                return this.selfBillingIndicatorField;
            }
            set
            {
                this.selfBillingIndicatorField = value;
            }
        }

        /// <remarks/>
        public PaymentMethodType paymentMethod
        {
            get
            {
                return this.paymentMethodField;
            }
            set
            {
                this.paymentMethodField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool paymentMethodSpecified
        {
            get
            {
                return this.paymentMethodFieldSpecified;
            }
            set
            {
                this.paymentMethodFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime paymentDate
        {
            get
            {
                return this.paymentDateField;
            }
            set
            {
                this.paymentDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool paymentDateSpecified
        {
            get
            {
                return this.paymentDateFieldSpecified;
            }
            set
            {
                this.paymentDateFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool cashAccountingIndicator
        {
            get
            {
                return this.cashAccountingIndicatorField;
            }
            set
            {
                this.cashAccountingIndicatorField = value;
            }
        }

        /// <remarks/>
        public InvoiceAppearanceType invoiceAppearance
        {
            get
            {
                return this.invoiceAppearanceField;
            }
            set
            {
                this.invoiceAppearanceField = value;
            }
        }

        /// <remarks/>
        public string electronicInvoiceHash
        {
            get
            {
                return this.electronicInvoiceHashField;
            }
            set
            {
                this.electronicInvoiceHashField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("additionalInvoiceData")]
        public AdditionalDataType[] additionalInvoiceData
        {
            get
            {
                return this.additionalInvoiceDataField;
            }
            set
            {
                this.additionalInvoiceDataField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public enum InvoiceCategoryType
    {

        /// <remarks/>
        NORMAL,

        /// <remarks/>
        SIMPLIFIED,

        /// <remarks/>
        AGGREGATE,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public enum PaymentMethodType
    {

        /// <remarks/>
        TRANSFER,

        /// <remarks/>
        CASH,

        /// <remarks/>
        CARD,

        /// <remarks/>
        VOUCHER,

        /// <remarks/>
        OTHER,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public enum InvoiceAppearanceType
    {

        /// <remarks/>
        PAPER,

        /// <remarks/>
        ELECTRONIC,

        /// <remarks/>
        EDI,

        /// <remarks/>
        UNKNOWN,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public partial class FiscalRepresentativeType
    {

        private TaxNumberType fiscalRepresentativeTaxNumberField;

        private string fiscalRepresentativeNameField;

        private AddressType fiscalRepresentativeAddressField;

        private string fiscalRepresentativeBankAccountNumberField;

        /// <remarks/>
        public TaxNumberType fiscalRepresentativeTaxNumber
        {
            get
            {
                return this.fiscalRepresentativeTaxNumberField;
            }
            set
            {
                this.fiscalRepresentativeTaxNumberField = value;
            }
        }

        /// <remarks/>
        public string fiscalRepresentativeName
        {
            get
            {
                return this.fiscalRepresentativeNameField;
            }
            set
            {
                this.fiscalRepresentativeNameField = value;
            }
        }

        /// <remarks/>
        public AddressType fiscalRepresentativeAddress
        {
            get
            {
                return this.fiscalRepresentativeAddressField;
            }
            set
            {
                this.fiscalRepresentativeAddressField = value;
            }
        }

        /// <remarks/>
        public string fiscalRepresentativeBankAccountNumber
        {
            get
            {
                return this.fiscalRepresentativeBankAccountNumberField;
            }
            set
            {
                this.fiscalRepresentativeBankAccountNumberField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public partial class CustomerInfoType
    {

        private TaxNumberType customerTaxNumberField;

        private TaxNumberType groupMemberTaxNumberField;

        private string communityVatNumberField;

        private string thirdStateTaxIdField;

        private string customerNameField;

        private AddressType customerAddressField;

        private string customerBankAccountNumberField;

        /// <remarks/>
        public TaxNumberType customerTaxNumber
        {
            get
            {
                return this.customerTaxNumberField;
            }
            set
            {
                this.customerTaxNumberField = value;
            }
        }

        /// <remarks/>
        public TaxNumberType groupMemberTaxNumber
        {
            get
            {
                return this.groupMemberTaxNumberField;
            }
            set
            {
                this.groupMemberTaxNumberField = value;
            }
        }

        /// <remarks/>
        public string communityVatNumber
        {
            get
            {
                return this.communityVatNumberField;
            }
            set
            {
                this.communityVatNumberField = value;
            }
        }

        /// <remarks/>
        public string thirdStateTaxId
        {
            get
            {
                return this.thirdStateTaxIdField;
            }
            set
            {
                this.thirdStateTaxIdField = value;
            }
        }

        /// <remarks/>
        public string customerName
        {
            get
            {
                return this.customerNameField;
            }
            set
            {
                this.customerNameField = value;
            }
        }

        /// <remarks/>
        public AddressType customerAddress
        {
            get
            {
                return this.customerAddressField;
            }
            set
            {
                this.customerAddressField = value;
            }
        }

        /// <remarks/>
        public string customerBankAccountNumber
        {
            get
            {
                return this.customerBankAccountNumberField;
            }
            set
            {
                this.customerBankAccountNumberField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public partial class SupplierInfoType
    {

        private TaxNumberType supplierTaxNumberField;

        private TaxNumberType groupMemberTaxNumberField;

        private string communityVatNumberField;

        private string supplierNameField;

        private AddressType supplierAddressField;

        private string supplierBankAccountNumberField;

        private bool individualExemptionField;

        private string exciseLicenceNumField;

        public SupplierInfoType()
        {
            this.individualExemptionField = false;
        }

        /// <remarks/>
        public TaxNumberType supplierTaxNumber
        {
            get
            {
                return this.supplierTaxNumberField;
            }
            set
            {
                this.supplierTaxNumberField = value;
            }
        }

        /// <remarks/>
        public TaxNumberType groupMemberTaxNumber
        {
            get
            {
                return this.groupMemberTaxNumberField;
            }
            set
            {
                this.groupMemberTaxNumberField = value;
            }
        }

        /// <remarks/>
        public string communityVatNumber
        {
            get
            {
                return this.communityVatNumberField;
            }
            set
            {
                this.communityVatNumberField = value;
            }
        }

        /// <remarks/>
        public string supplierName
        {
            get
            {
                return this.supplierNameField;
            }
            set
            {
                this.supplierNameField = value;
            }
        }

        /// <remarks/>
        public AddressType supplierAddress
        {
            get
            {
                return this.supplierAddressField;
            }
            set
            {
                this.supplierAddressField = value;
            }
        }

        /// <remarks/>
        public string supplierBankAccountNumber
        {
            get
            {
                return this.supplierBankAccountNumberField;
            }
            set
            {
                this.supplierBankAccountNumberField = value;
            }
        }

        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool individualExemption
        {
            get
            {
                return this.individualExemptionField;
            }
            set
            {
                this.individualExemptionField = value;
            }
        }

        /// <remarks/>
        public string exciseLicenceNum
        {
            get
            {
                return this.exciseLicenceNumField;
            }
            set
            {
                this.exciseLicenceNumField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.nav.gov.hu/OSA/2.0/data")]
    public partial class InvoiceHeadType
    {

        private SupplierInfoType supplierInfoField;

        private CustomerInfoType customerInfoField;

        private FiscalRepresentativeType fiscalRepresentativeInfoField;

        private InvoiceDetailType invoiceDetailField;

        /// <remarks/>
        public SupplierInfoType supplierInfo
        {
            get
            {
                return this.supplierInfoField;
            }
            set
            {
                this.supplierInfoField = value;
            }
        }

        /// <remarks/>
        public CustomerInfoType customerInfo
        {
            get
            {
                return this.customerInfoField;
            }
            set
            {
                this.customerInfoField = value;
            }
        }

        /// <remarks/>
        public FiscalRepresentativeType fiscalRepresentativeInfo
        {
            get
            {
                return this.fiscalRepresentativeInfoField;
            }
            set
            {
                this.fiscalRepresentativeInfoField = value;
            }
        }

        /// <remarks/>
        public InvoiceDetailType invoiceDetail
        {
            get
            {
                return this.invoiceDetailField;
            }
            set
            {
                this.invoiceDetailField = value;
            }
        }
    }
}
