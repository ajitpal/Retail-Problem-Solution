using Solution.Solution2.Rule;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Solution2
{
    public class PriceCalculatorViaReflection : ICalculatePrice
    {
        IList<IPriceDiscountRule> discountRules;
        public PriceCalculatorViaReflection()
        {
            //Via Reflection
            var interfaceType = typeof(IPriceDiscountRule);
            var allRules = AppDomain.CurrentDomain.GetAssemblies()
              .SelectMany(x => x.GetTypes())
              .Where(x => interfaceType.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
              .Select(x => Activator.CreateInstance(x) as IPriceDiscountRule).ToList();
            discountRules = new List<IPriceDiscountRule>();
            foreach (IPriceDiscountRule rule in allRules)
            {
                string activeRules = ConfigurationManager.AppSettings["ActiveRules"];
                if (activeRules.Contains(rule.GetType().Name))
                    discountRules.Add(rule);
            }
        }
        public decimal CalculateFinalPrice(StoreUser user, BillItems items)
        {
            decimal discount = 0m;
            foreach (IPriceDiscountRule rule in discountRules.Where(o => o.IsMandatory == false))
                discount = Math.Max(discount, CalculateDiscount(user, items, rule));
            foreach (IPriceDiscountRule rule in discountRules.Where(o => o.IsMandatory == true))
                discount += CalculateDiscount(user, items, rule);
            return items.BillTotal - discount;
        }
        private decimal CalculateDiscount(StoreUser user, BillItems items, IPriceDiscountRule rule)
        {
            decimal discount = 0m;
            if (rule.IsFixed) // When discount is fixed 
                discount = rule.GetApplicableDiscount(user, items);
            else // when discount is in percentage
            {
                decimal itemTotal = 0m;
                decimal discountRate = rule.GetApplicableDiscount(user, items);
                foreach (Product product in items.Products)
                {
                    if (product.ProductType != ProductType.Grocery) //Percentage discount doesn't apply on grocery items
                        itemTotal += (product.Quantity * product.Price);
                }
                discount = itemTotal * discountRate;
            }
            return discount;
        }
    }
}
