using System;

namespace Solution
{
    public class StoreUser
    {
        public string UserName { get; set; }
        public DateTime? FirstPurchaseDate { get; set; }
        public UserType UserType { get; set; }

    }

    public enum UserType
    {
        Employee,
        Affiliate,
        Customer
    }
}
