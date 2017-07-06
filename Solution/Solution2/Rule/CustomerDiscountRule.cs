using System; 

namespace Solution.Solution2.Rule
{
    public class CustomerDiscountRule : IPriceDiscountRule
    {
        public int memberSinceinYrs { get; set; }
        public CustomerDiscountRule()
        {
            memberSinceinYrs = 2; //default
        }
        public CustomerDiscountRule(int memberSinceinYears)
        {
            memberSinceinYrs = memberSinceinYears;
        }

        public bool IsMandatory
        {
            get
            {
                return false;
            }
        }

        public bool IsFixed
        {
            get
            {
                return false;
            }
        }

        public decimal GetApplicableDiscount(StoreUser user, BillItems items)
        {
            if (null == user) return 0m;
            DateTime currentDate = DateTime.Now;
            if (user.FirstPurchaseDate.HasValue)
            {
                if (currentDate.AddYears(-1 * memberSinceinYrs) > user.FirstPurchaseDate.Value)
                    return 0.05m;
            }
            return 0m;
        }
    }
}
