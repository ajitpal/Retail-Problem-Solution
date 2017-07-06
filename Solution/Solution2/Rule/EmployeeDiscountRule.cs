namespace Solution.Solution2.Rule
{
    public class EmployeeDiscountRule : IPriceDiscountRule
    {
        public bool IsMandatory
        {
            get { return false; }
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
            return ((user != null ? (UserType.Employee == user.UserType ? 0.30m : 0m) : 0m));
        }
    }
}
