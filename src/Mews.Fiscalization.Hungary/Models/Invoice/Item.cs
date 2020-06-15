using System;

namespace Mews.Fiscalization.Hungary.Models
{
    public class Item
    {
        public Item(
            string number,
            ProductCodeCategory productCodeCategory,
            ItemChoiceType productCodeChoiceType,
            DateTime consumptionDate,
            string description,
            string productCode,
            MeasurementUnit measurementUnit,
            Amount amount,
            Amount amountHUF,
            decimal taxPercentage,
            decimal quantity,
            decimal netUnitPrice,
            bool isDeposit = false)
        {
            Number = number;
            ProductCodeCategory = productCodeCategory;
            ProductCodeChoiceType = productCodeChoiceType;
            ConsumptionDate = consumptionDate;
            Description = description;
            ProductCode = productCode;
            MeasurementUnit = measurementUnit;
            Amount = amount;
            AmountHUF = amountHUF;
            TaxPercentage = taxPercentage;
            Quantity = quantity;
            NetUnitPrice = netUnitPrice;
            IsDeposit = isDeposit;
        }

        public string Number { get; }

        public ProductCodeCategory ProductCodeCategory { get; }

        public ItemChoiceType ProductCodeChoiceType { get; }

        public DateTime ConsumptionDate { get; }

        public string Description { get; }

        public string ProductCode { get; }

        public MeasurementUnit MeasurementUnit { get; }

        public Amount Amount { get; }

        public Amount AmountHUF { get; }

        public decimal TaxPercentage { get; }

        public decimal Quantity { get; }

        public decimal NetUnitPrice { get; }

        public bool IsDeposit { get; }
    }
}
