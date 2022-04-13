using ppedv.Foodybrät.Model;

namespace ppedv.Foodybrät.Contracts
{
    public interface IUnitOfWork
    {
        IFoodRepository FoodRepository { get; }
        IRepository<Customer> CustomerRepository { get; }

        //oder
        IRepository<T> GetRepo<T>() where T : Entity;   


        void SaveAll();
        void ClearData();
    }
}