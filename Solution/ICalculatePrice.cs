using Solution;

namespace Solution
{
    public interface ICalculatePrice
    {
        /// <summary>
        ///  Function to get final discount total of bill presented
        /// </summary>
        /// <param name="user">Currenr User</param>
        /// <param name="items">Item List of Bill</param>
        /// <returns>Final discounted total payable by customer</returns>
        decimal CalculateFinalPrice(StoreUser user, BillItems items);
    }
}
