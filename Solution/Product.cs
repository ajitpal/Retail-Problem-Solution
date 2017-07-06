using System.Collections.Generic;

namespace Solution
{
    public class BillItems
    {
        public IList<Product> Products { get; set; }

        public decimal BillTotal
        {
            get
            {
                decimal total = 0.0m;
                foreach (Product product in Products)
                {
                    total += (product.Quantity * product.Price);
                }
                return total;
            }
        }

    }
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public ProductType ProductType { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

    public enum ProductType
    {
        Perishable, Clothing, Footwear, Toiletries, Cosmetics, Medicines, Stationery,
        Grocery, Automobiles, Appliances, Electronics, Furniture, SportingGoods
    }
}