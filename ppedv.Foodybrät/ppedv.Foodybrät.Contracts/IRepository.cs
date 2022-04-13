using ppedv.Foodybrät.Model;

namespace ppedv.Foodybrät.Contracts
{
    public interface IRepository<T> where T : Entity
    {
        IQueryable<T> Query();

        T GetById(int id);

        void Add(T entity);

        void Delete(T entity);

        void Update(T entity);
    }
}