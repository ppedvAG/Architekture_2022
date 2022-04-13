using ppedv.Foodybrät.Contracts;
using ppedv.Foodybrät.Model;

namespace ppedv.Foodybrät.Data.EfCore
{
    public class EfUnitOfWork : IUnitOfWork
    {
        EfContext _efContext = new EfContext();


        public IFoodRepository FoodRepository => new EfFoodRepository(_efContext);


        public IRepository<Customer> CustomerRepository => new EfRepository<Customer>(_efContext);


        public void ClearData()
        {
            _efContext.Database.EnsureDeleted();
            _efContext.Database.EnsureCreated();
        }

        public IRepository<T> GetRepo<T>() where T : Entity
        {
            return new EfRepository<T>(_efContext);
        }

        public void SaveAll()
        {
            _efContext.SaveChanges();
        }
    }
}
