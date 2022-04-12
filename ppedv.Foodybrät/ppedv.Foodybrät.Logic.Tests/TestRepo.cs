using ppedv.Foodybrät.Contracts;
using ppedv.Foodybrät.Model;
using System.Linq;

namespace ppedv.Foodybrät.Logic.Tests
{
    public class TestRepo : IRepository
    {
        public void Add<T>(T entity) where T : Model.Entity
        {
            throw new System.NotImplementedException();
        }

        public void ClearData()
        {
            throw new System.NotImplementedException();
        }

        public void Delete<T>(T entity) where T : Model.Entity
        {
            throw new System.NotImplementedException();
        }

        public T GetById<T>(int id) where T : Model.Entity
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<T> Query<T>() where T : Model.Entity
        {
            if (typeof(T) == typeof(Order))
            {
                var c1 = new Customer() { Name = "Wilma" };
                var order1 = new Order();
                order1.Items.Add(new OrderItem() { Amount = 1, Food = new Food() { Price = 2.00m } });
                order1.Customer = c1;

                var c2 = new Customer() { Name = "Fred" };
                var order2 = new Order();
                order2.Items.Add(new OrderItem() { Amount = 1, Food = new Food() { Price = 3.00m } });
                order2.Customer = c2;

                return new[] { order1, order2 }.Cast<T>().AsQueryable();
            }

            throw new System.NotImplementedException();
        }

        public void SaveAll()
        {
            throw new System.NotImplementedException();
        }

        public void Update<T>(T entity) where T : Model.Entity
        {
            throw new System.NotImplementedException();
        }
    }
}