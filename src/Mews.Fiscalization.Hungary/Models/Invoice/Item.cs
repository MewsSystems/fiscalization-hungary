using System;
using System.Collections;
using System.Collections.Generic;

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
            decimal quantity,
            decimal netUnitPrice,
            decimal grossAmount,
            decimal grossAmountHUF,
            decimal netAmount,
            decimal netAmountHUF,
            decimal vatPercentage,
            bool isDeposit = false)
        {
            Number = number;
            ProductCodeCategory = productCodeCategory;
            ProductCodeChoiceType = productCodeChoiceType;
            ConsumptionDate = consumptionDate;
            Description = description;
            ProductCode = productCode;
            MeasurementUnit = measurementUnit;
            Quantity = quantity;
            NetUnitPrice = netUnitPrice;
            GrossAmount = grossAmount;
            GrossAmountHUF = grossAmountHUF;
            NetAmount = netAmount;
            NetAmountHUF = netAmountHUF;
            VatPercentage = vatPercentage;
            IsDeposit = isDeposit;
        }

        public string Number { get; }

        public ProductCodeCategory ProductCodeCategory { get; }

        public ItemChoiceType ProductCodeChoiceType { get; }

        public DateTime ConsumptionDate { get; }

        public string Description { get; }

        public string ProductCode { get; }

        public MeasurementUnit MeasurementUnit { get; }

        public decimal Quantity { get; }

        public decimal NetUnitPrice { get; }

        public decimal GrossAmount { get; }

        public decimal GrossAmountHUF { get; }

        public decimal NetAmount { get; }

        public decimal NetAmountHUF { get; }

        public decimal VatPercentage { get; }

        public bool IsDeposit { get; }
    }
}
