using ppedv.Foodybrät.Contracts;
using ppedv.Foodybrät.Model;
using System.Linq;

namespace ppedv.Foodybrät.Logic.Tests
{

    public class TestUnitOfWork : IUnitOfWork
    {
        public IFoodRepository FoodRepository => throw new System.NotImplementedException();

        public IRepository<Customer> CustomerRepository => throw new System.NotImplementedException();

        public void ClearData()
        {
            throw new System.NotImplementedException();
        }

        public IRepository<T> GetRepo<T>() where T : Entity
        {
            if (typeof(T) == typeof(Order))
                return new TestOrderRepo() as IRepository<T>;

            throw new System.NotImplementedException();
        }

        public void SaveAll()
        {
            throw new System.NotImplementedException();
        }
    }

    public class TestOrderRepo : IRepository<Order>
    {
        public void Add(Order entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Order entity)
        {
            throw new System.NotImplementedException();
        }

        public Order GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Order> Query()
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
        }

        public void Update(Order entity)
        {
            throw new System.NotImplementedException();
        }
    }
   
}