namespace Mews.Fiscalization.Hungary.Models
{
    public class InvoiceDetail
    {
        public InvoiceDetail(
            string number,
            ProductCodeCategory productCodeCategory,
            ItemChoiceType productCodeChoiceType,
            bool expressionIndicator,
            LineIndicatorType indicatorType,
            string description,
            string productCode,
            decimal quantity,
            MeasurementUnitType measurementUnitType,
            decimal unitPrice,
            decimal netAmount,
            decimal netAmountHUF,
            decimal vatPercentage,
            decimal vatAmount,
            decimal vatAmountHUF,
            decimal grossAmountNormal,
            decimal grossAmountNormalHUF,
            string discountDescription,
            decimal discountValue)
        {
            Number = number;
            ProductCodeCategory = productCodeCategory;
            ProductCodeChoiceType = productCodeChoiceType;
            ExpressionIndicator = expressionIndicator;
            IndicatorType = indicatorType;
            Description = description;
            ProductCode = productCode;
            Quantity = quantity;
            MeasurementUnitType = measurementUnitType;
            UnitPrice = unitPrice;
            NetAmount = netAmount;
            NetAmountHUF = netAmountHUF;
            VatPercentage = vatPercentage;
            VatAmount = vatAmount;
            VatAmountHUF = vatAmountHUF;
            GrossAmount = grossAmountNormal;
            GrossAmountHUF = grossAmountNormalHUF;
            DiscountDescription = discountDescription;
            DiscountValue = discountValue;
        }

        public string Number { get; }

        public ProductCodeCategory ProductCodeCategory { get; }

        public ItemChoiceType ProductCodeChoiceType { get; }

        public bool ExpressionIndicator { get; }

        public LineIndicatorType IndicatorType { get; }

        public string Description { get; }

        public string ProductCode { get; }

        public decimal Quantity { get; }

        public MeasurementUnitType MeasurementUnitType { get; }

        public decimal UnitPrice { get; }

        public decimal NetAmount { get; }

        public decimal NetAmountHUF { get; }

        public decimal VatPercentage { get; }

        public decimal VatAmount { get; }

        public decimal VatAmountHUF { get; }

        public decimal GrossAmount { get; }

        public decimal GrossAmountHUF { get; }

        public string DiscountDescription { get; }

        public decimal DiscountValue { get; }
    }
}
