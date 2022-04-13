using ppedv.Foodybrät.Contracts;
using ppedv.Foodybrät.Model;
using System.Linq;

namespace ppedv.Foodybrät.Data.EfCore
{

    public class EfRepository<T> : IRepository<T> where T : Entity
    {
        protected readonly EfContext _efContext;

        public EfRepository(EfContext efContext)
        {
            _efContext = efContext;
        }

        public void Add(T entity)
        {
            //if (typeof(T) == typeof(Food))
            //    _efContext.Food.Add(entity as Food);

            _efContext.Set<T>().Add(entity);
            //_efContext.Add(entity);
        }

        public void Delete(T entity)
        {
            _efContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> Query()
        {
            return _efContext.Set<T>();
        }

        public T GetById(int id)
        {
            return _efContext.Set<T>().Find(id);
        }
        public void Update(T entity)
        {
            _efContext.Set<T>().Update(entity);
        }
    }
}
