using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solution.UnitTest.MockData; 

namespace Solution.UnitTest
{
    [TestClass]
    public abstract class DiscountBaseTests<T>
        where T : ICalculatePrice, new()
    {
        private ICalculatePrice _calculator;
        [TestInitialize]
        public void SetUp()
        {
            _calculator = new T();
        }
        [TestMethod]
        public void Employee_Gets_30_Percent_Discount_Amount_Total()
        {

            var currentUser = new StoreUser
            {
                UserType = UserType.Employee
            };
            BillItems items = FakeDataGenerator.Generate5BillItems();
            decimal expectedDiscount = 47m;
            decimal expectedTotal = items.BillTotal - expectedDiscount;
            decimal actualTotal = _calculator.CalculateFinalPrice(currentUser, items);
            Assert.AreEqual(expectedTotal, actualTotal, "Actual and expected Total amount are same.");
        }

        [TestMethod]
        public void Affiliate_Gets_10_Percent_Discount()
        {
            var currentUser = new StoreUser
            {
                UserType = UserType.Affiliate
            };

            BillItems items = FakeDataGenerator.Generate5BillItems();
            decimal expectedDiscount = 19m;
            decimal expectedTotal = items.BillTotal - expectedDiscount;
            decimal actualTotal = _calculator.CalculateFinalPrice(currentUser, items);
            Assert.AreEqual(expectedTotal, actualTotal, "Actual and expected Total amount are same.");
        }

        [TestMethod]
        public void Old_Customer_Gets_5_Percent_Discount()
        {
            var currentUser = new StoreUser
            {
                UserType = UserType.Customer,
                FirstPurchaseDate = DateTime.Now.AddDays(-2).AddYears(-2)
            };
            BillItems items = FakeDataGenerator.Generate5BillItems();
            decimal expectedDiscount = 12m;
            decimal expectedTotal = items.BillTotal - expectedDiscount;
            decimal actualTotal = _calculator.CalculateFinalPrice(currentUser, items);
            Assert.AreEqual(expectedTotal, actualTotal, "Actual and expected Total amount are same.");
        }

        [TestMethod]
        public void New_Customer_Did_Not_Gets_5_Percent_Discount()
        {
            var currentUser = new StoreUser
            {
                UserType = UserType.Customer,
                FirstPurchaseDate = DateTime.Now
            };
            BillItems items = FakeDataGenerator.Generate5BillItems();
            decimal expectedDiscount = 5m;
            decimal expectedTotal = items.BillTotal - expectedDiscount;
            decimal actualTotal = _calculator.CalculateFinalPrice(currentUser, items);
            Assert.AreEqual(expectedTotal, actualTotal, "Actual and expected Total amount are same.");
        }

        [TestMethod]
        public void New_Customer_with_less_than_100_total_Gets_0_Percent_Discount()
        {
            var currentUser = new StoreUser
            {
                UserType = UserType.Customer,
                FirstPurchaseDate = DateTime.Now
            };

            BillItems items = FakeDataGenerator.Generate3BillItems();
            decimal expectedDiscount = 0m;
            decimal expectedTotal = items.BillTotal - expectedDiscount;
            decimal actualTotal = _calculator.CalculateFinalPrice(currentUser, items);
            Assert.AreEqual(expectedTotal, actualTotal, "Actual and expected Total amount are same.");
        }
    }
}
