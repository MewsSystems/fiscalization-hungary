using System.Collections.Generic;
using System.Linq;

namespace Mews.Fiscalization.Hungary.Models
{
    public class Item
    {
        public Item(
            string number,
            ProductCodeCategory productCodeCategory,
            ItemChoiceType productCodeChoiceType,
            string description,
            string productCode,
            decimal quantity,
            decimal unitPrice,
            decimal grossAmountNormal,
            decimal grossAmountNormalHUF,
            string discountDescription,
            decimal discountValue)
        {
            Number = number;
            ProductCodeCategory = productCodeCategory;
            ProductCodeChoiceType = productCodeChoiceType;
            Description = description;
            ProductCode = productCode;
            Quantity = quantity;
            UnitPrice = unitPrice;
            GrossAmount = grossAmountNormal;
            GrossAmountHUF = grossAmountNormalHUF;
            DiscountDescription = discountDescription;
            DiscountValue = discountValue;
        }

        public string Number { get; }

        public ProductCodeCategory ProductCodeCategory { get; }

        public ItemChoiceType ProductCodeChoiceType { get; }

        public string Description { get; }

        public string ProductCode { get; }

        public decimal Quantity { get; }

        public decimal UnitPrice { get; }

        public decimal GrossAmount { get; }

        public decimal GrossAmountHUF { get; }

        public string DiscountDescription { get; }

        public decimal DiscountValue { get; }

        internal static IEnumerable<Dto.LineType> Map(IEnumerable<Item> items)
        {
            return items.Select(i => new Dto.LineType
            {
                lineNumber = i.Number,
                lineDescription = i.Description,
                lineExpressionIndicator = false,
                quantity = i.Quantity,
                unitPrice = i.UnitPrice,
                Item = new Dto.LineAmountsSimplifiedType
                {
                    lineGrossAmountSimplified = i.GrossAmount,
                    lineGrossAmountSimplifiedHUF = i.GrossAmountHUF
                },
                lineDiscountData = new Dto.DiscountDataType
                {
                    discountDescription = i.DiscountDescription,
                    discountValue = i.DiscountValue
                },
                productCodes = new Dto.ProductCodeType[]
                {
                    new Dto.ProductCodeType
                    {
                        productCodeCategory = (Dto.ProductCodeCategoryType)i.ProductCodeCategory,
                        ItemElementName = (Dto.ItemChoiceType)i.ProductCodeChoiceType,
                        Item = i.ProductCode
                    }
                },
            });
        }
    }
}
