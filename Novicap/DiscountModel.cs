using System;
using System.Text;

namespace Novicap
{
    public interface IDiscountModel
    {
        decimal GetAmount(decimal actualPrice, int quantity);
    }

    public class Type1DiscountModel : IDiscountModel
    {
        public int ApplicableQuantity { get; set; }
        public int FreeQuantity { get; set; }

        public decimal GetAmount(decimal actualPrice, int quantity)
        {
            if (quantity < ApplicableQuantity)
            {
                return quantity * actualPrice;
            }

            var discountPrice = ((decimal)(ApplicableQuantity - FreeQuantity) / (decimal)ApplicableQuantity) * actualPrice;
            var remainingQuantity = (decimal)(quantity % ApplicableQuantity);

            return (decimal)(quantity - remainingQuantity) * discountPrice + (remainingQuantity * actualPrice);
        }
    }

    public class Type2DiscountModel : IDiscountModel
    {
        public int ApplicableQuantity { get; set; }
        public decimal NewPricePerPiece { get; set; }
        public decimal GetAmount(decimal actualPrice, int quantity)
        {
            decimal price = actualPrice;

            if (quantity >= ApplicableQuantity)
            {
                price = NewPricePerPiece;
            }

            return quantity * price;
        }
    }

    public enum DiscountType
    {
        None,
        Type1,
        Type2
    }
}
