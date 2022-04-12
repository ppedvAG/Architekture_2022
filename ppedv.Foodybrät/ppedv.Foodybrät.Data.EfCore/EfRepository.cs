using ppedv.Foodybrät.Contracts;
using ppedv.Foodybrät.Model;
using System.Collections.Generic;
using System.Linq;

namespace ppedv.Foodybrät.Data.EfCore
{
    public class EfRepository : IRepository
    {

        EfContext _efContext = new EfContext();

        public void Add<T>(T entity) where T : Entity
        {
            //if (typeof(T) == typeof(Food))
            //    _efContext.Food.Add(entity as Food);

            _efContext.Set<T>().Add(entity);
            //_efContext.Add(entity);
        }

        public void Delete<T>(T entity) where T : Entity
        {
            _efContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> Query<T>() where T : Entity
        {
            return _efContext.Set<T>();
        }

        public T GetById<T>(int id) where T : Entity
        {
            return _efContext.Set<T>().Find(id);
        }

        public void SaveAll()
        {
            _efContext.SaveChanges();
        }

        public void Update<T>(T entity) where T : Entity
        {
            _efContext.Set<T>().Update(entity);
        }

        public void ClearData()
        {
            _efContext.Database.EnsureDeleted();
            _efContext.Database.EnsureCreated();
        }
    }
}
