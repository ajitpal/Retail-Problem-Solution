using Solution.Solution2;
using System;
using System.Collections.Generic;

namespace Solution
{
    class Program
    {
        static void Main(string[] args)
        {
            ICalculatePrice _calculator = new PriceCalculatorViaDI();
            var currentUser = new StoreUser
            {
                UserType = UserType.Employee
            };

            BillItems items = new BillItems
            {
                Products = new List<Product>
                {
                    new Product { ProductType = ProductType.Automobiles, Price=10, Quantity =2 },
                    new Product { ProductType = ProductType.Clothing, Price=20, Quantity =2 },
                    new Product { ProductType = ProductType.Grocery, Price=10, Quantity =2 },
                    new Product { ProductType = ProductType.Appliances, Price=20, Quantity =2 },
                    new Product { ProductType = ProductType.Electronics, Price=20, Quantity =2 },
                }

            };
            decimal expectedDiscount = 47m;
            decimal expectedTotal = items.BillTotal - expectedDiscount;
            decimal actualTotal = _calculator.CalculateFinalPrice(currentUser, items);
            Console.WriteLine(string.Format("Expected Total : {0} Actual Total {1}", expectedTotal, actualTotal));
            Console.ReadLine();
        }
    }
}
