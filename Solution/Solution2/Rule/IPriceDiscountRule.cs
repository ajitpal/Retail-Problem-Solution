 namespace Solution.Solution2.Rule
{
    public interface IPriceDiscountRule
    {
        /// <summary>
        /// Function to get applicable discount 
        /// </summary>
        /// <param name="user">Currenr User</param>
        /// <param name="billItemList">Item List of Bill</param>
        /// <returns>Applicable discount on the bill items</returns>
        decimal GetApplicableDiscount(StoreUser user, BillItems items);

        bool IsMandatory { get; }
        bool IsFixed { get; }
    }
}
