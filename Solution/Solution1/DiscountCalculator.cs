using Solution1;
using System;

namespace Solution.Solution1
{
    public class DiscountCalculator : ICalculatePrice
    {
        public decimal CalculateFinalPrice(StoreUser user, BillItems items)
        {
            decimal percentageTotalDiscount = 0m, itemTotal = 0m;
            decimal discountRate = GetDiscountRate(user);
            if (discountRate > 0)
            {
                foreach (var item in items.Products)
                {
                    if (item.ProductType != ProductType.Grocery)
                        itemTotal += (item.Quantity * item.Price);
                }
                percentageTotalDiscount = (itemTotal * discountRate);
            }
            decimal fixedDiscount = Math.Floor(items.BillTotal / 100) * 5m;
            return items.BillTotal - (percentageTotalDiscount + fixedDiscount);
        }
        private decimal GetDiscountRate(StoreUser user)
        {
            decimal discount = 0m;
            switch (user.UserType)
            {
                case UserType.Employee:
                    discount = .30m;
                    break;
                case UserType.Affiliate:
                    discount = .10m;
                    break;
                case UserType.Customer:
                    DateTime date = DateTime.Now;
                    if (user.FirstPurchaseDate.HasValue)
                    {
                        if (user.FirstPurchaseDate.Value < date.AddYears(-2))
                            discount = .05m;
                    }
                    break;
                default:
                    break;
            }
            return discount;
        }

    }
}