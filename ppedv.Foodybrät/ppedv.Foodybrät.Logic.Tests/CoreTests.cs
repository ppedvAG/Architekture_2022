using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ppedv.Foodybrät.Contracts;
using ppedv.Foodybrät.Model;
using System.Linq;

namespace ppedv.Foodybrät.Logic.Tests
{
    [TestClass]
    public class CoreTests
    {
        [TestMethod]
        public void GetCustomersWithMostyValuableOrder_Fred_has_most_expensive_order_TESTREPO()
        {
            var core = new Core(new TestRepo());

            var result = core.GetCustomersWithMostyValuableOrder();

            Assert.AreEqual("Fred", result.Name);
        }

        [TestMethod]
        public void GetCustomersWithMostyValuableOrder_Fred_has_most_expensive_order()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(x => x.Query<Order>()).Returns(() =>
            {
                var c1 = new Customer() { Name = "Wilma" };
                var order1 = new Order();
                order1.Items.Add(new OrderItem() { Amount = 1, Food = new Food() { Price = 2.00m } });
                order1.Customer = c1;

                var c2 = new Customer() { Name = "Fred" };
                var order2 = new Order();
                order2.Items.Add(new OrderItem() { Amount = 1, Food = new Food() { Price = 3.00m } });
                order2.Customer = c2;

                return new[] { order1, order2 }.AsQueryable();
            });

            var core = new Core(mock.Object);

            var result = core.GetCustomersWithMostyValuableOrder();

            Assert.AreEqual("Fred", result.Name);
        }

    }
}