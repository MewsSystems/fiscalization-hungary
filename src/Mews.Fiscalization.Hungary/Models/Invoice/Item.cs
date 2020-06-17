using Mews.Fiscalization.Hungary.Utils;
using System;

namespace Mews.Fiscalization.Hungary.Models
{
    public class Item
    {
        public Item(
            DateTime consumptionDate,
            ItemAmounts amounts,
            MeasurementUnit measurementUnit,
            Description description,
            int quantity,
            Amount unitAmount,
            bool isDeposit = false)
        {
            ConsumptionDate = consumptionDate;
            Amounts = Check.NotNull(amounts, nameof(amounts));
            MeasurementUnit = measurementUnit;
            Description = Check.NotNull(description, nameof(description));
            Quantity = quantity;
            UnitAmount = Check.NotNull(unitAmount, nameof(unitAmount));
            IsDeposit = isDeposit;
        }

        public DateTime ConsumptionDate { get; }
        
        public ItemAmounts Amounts { get; }

        public MeasurementUnit MeasurementUnit { get; }

        public Description Description { get; }

        public int Quantity { get; }

        public Amount UnitAmount { get; }

        public bool IsDeposit { get; }
    }
}
