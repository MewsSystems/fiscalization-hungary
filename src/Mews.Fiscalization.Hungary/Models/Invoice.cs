using System.Collections.Generic;
namespace Mews.Fiscalization.Hungary.Models
{
    public class SupplierTaxNumber
    {
        public string TaxpayerId { get; set; }
        public string VatCode { get; set; }
    }

    public class SimpleAddress
    {
        public string CountryCode { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string AdditionalDetail { get; set; }
    }

    public class SupplierAddress
    {
        public SimpleAddress DetailedAddress { get; set; }
    }

    public class SupplierInfo
    {
        public SupplierTaxNumber SupplierTaxNumber { get; set; }
        public string SupplierName { get; set; }
        public SupplierAddress SupplierAddress { get; set; }
    }

    public class CustomerTaxNumber
    {
        public string TaxpayerId { get; set; }
        public string VatCode { get; set; }
    }

    public class CustomerAddress
    {
        public SimpleAddress DetailedAddress { get; set; }
    }

    public class InvoiceDetail
    {
        public string InvoiceCategory { get; set; }
        public string InvoiceDeliveryDate { get; set; }
        public string CurrencyCode { get; set; }
        public string ExchangeRate { get; set; }
        public string PaymentDate { get; set; }
        public string InvoiceAppearance { get; set; }
        // public AdditionalInvoiceData AdditionalInvoiceData { get; set; }
    }

    public class InvoiceHead
    {
        public SupplierInfo SupplierInfo { get; set; }
        public InvoiceDetail InvoiceDetail { get; set; }
    }

    public class ProductCode
    {
        public string ProductCodeCategory { get; set; }
        public string ProductCodeValue { get; set; }
    }

    public class ProductCodes
    {
        public ProductCode ProductCode { get; set; }
    }

    public class LineNetAmountData
    {
        public string LineNetAmount { get; set; }
        public string LineNetAmountHUF { get; set; }
    }

    public class LineVatRate
    {
        public string VatPercentage { get; set; }
    }

    public class LineVatData
    {
        public string LineVatAmount { get; set; }
        public string LineVatAmountHUF { get; set; }
    }

    public class LineGrossAmountData
    {
        public string LineGrossAmountNormal { get; set; }
        public string LineGrossAmountNormalHUF { get; set; }
    }

    public class LineAmountsNormal
    {
        public LineNetAmountData LineNetAmountData { get; set; }
        public LineVatRate LineVatRate { get; set; }
        public LineVatData LineVatData { get; set; }
        public LineGrossAmountData LineGrossAmountData { get; set; }
    }

    public class Line
    {
        public string LineNumber { get; set; }
        public ProductCodes ProductCodes { get; set; }
        public string LineExpressionIndicator { get; set; }
        public string LineNatureIndicator { get; set; }
        public string LineDescription { get; set; }
        public string Quantity { get; set; }
        public string UnitOfMeasure { get; set; }
        public string UnitPrice { get; set; }
        public LineAmountsNormal LineAmountsNormal { get; set; }
        public LineDiscountData LineDiscountData { get; set; }
    }

    public class LineDiscountData
    {
        public string DiscountDescription { get; set; }
        public string DiscountValue { get; set; }
    }

    public class InvoiceLines
    {
        public List<Line> Line { get; set; }
    }

    public class VatRate
    {
        public string VatPercentage { get; set; }
    }

    public class VatRateNetData
    {
        public string VatRateNetAmount { get; set; }
        public string VatRateNetAmountHUF { get; set; }
    }

    public class VatRateVatData
    {
        public string VatRateVatAmount { get; set; }
        public string VatRateVatAmountHUF { get; set; }
    }

    public class VatRateGrossData
    {
        public string VatRateGrossAmount { get; set; }
        public string VatRateGrossAmountHUF { get; set; }
    }

    public class SummaryByVatRate
    {
        public VatRate VatRate { get; set; }
        public VatRateNetData VatRateNetData { get; set; }
        public VatRateVatData VatRateVatData { get; set; }
        public VatRateGrossData VatRateGrossData { get; set; }
    }

    public class SummaryNormal
    {
        public List<SummaryByVatRate> SummaryByVatRate { get; set; }
        public string InvoiceNetAmount { get; set; }
        public string InvoiceNetAmountHUF { get; set; }
        public string InvoiceVatAmount { get; set; }
        public string InvoiceVatAmountHUF { get; set; }
    }

    public class SummaryGrossData
    {
        public string InvoiceGrossAmount { get; set; }
        public string InvoiceGrossAmountHUF { get; set; }
    }

    public class InvoiceSummary
    {
        public SummaryNormal SummaryNormal { get; set; }
        public SummaryGrossData SummaryGrossData { get; set; }
    }

    public class Invoice
    {
        public InvoiceHead InvoiceHead { get; set; }
        public InvoiceLines InvoiceLines { get; set; }
        public InvoiceSummary InvoiceSummary { get; set; }
    }

    public class InvoiceMain
    {
        public Invoice Invoice { get; set; }
    }

    public class InvoiceData
    {
        public string InvoiceNumber { get; set; }
        public string InvoiceIssueDate { get; set; }
        public InvoiceMain InvoiceMain { get; set; }
        public string SchemaLocation { get; set; }
    }

}
