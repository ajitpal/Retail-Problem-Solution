using System;
using Solution;

namespace Solution1.Solution2.Rule
{
    public class FixedDiscountRule : IPriceDiscountRule
    {
        public bool IsMandatory
        {
            get { return true; }
        }
        public bool IsFixed
        {
            get
            {
                return true;
            }
        }
        public decimal GetApplicableDiscount(StoreUser user, BillItems items)
        {
            return (null != items ? Math.Floor(items.BillTotal / 100m) * 5m : 0m);
        }
    }
}
