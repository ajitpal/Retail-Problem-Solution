using Solution;

namespace Solution1.Solution2.Rule
{
    public class AffiliateDiscountRule : IPriceDiscountRule
    {
        public bool IsMandatory
        {
            get  { return false; }
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
            return ((user != null ? (UserType.Affiliate == user.UserType ? 0.10m : 0m) : 0m));
        }
    }
}
