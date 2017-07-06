using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.UnitTest.MockData
{
    public class FakeDataGenerator
    {
        internal static BillItems Generate5BillItems()
        {
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
            
            return items;
        }
        internal static BillItems Generate3BillItems()
        {
            BillItems items = new BillItems
            {
                Products = new List<Product>
                {
                    new Product { ProductType = ProductType.Automobiles, Price=10, Quantity =2 },
                    new Product { ProductType = ProductType.Clothing, Price=20, Quantity =2 },
                    new Product { ProductType = ProductType.Grocery, Price=10, Quantity =2 },
                    
                }

            };
            
             return items;
        }
    }
}
