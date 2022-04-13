using ppedv.Foodybrät.Model;

namespace ppedv.Foodybrät.Contracts
{
    public interface IFoodRepository : IRepository<Food>
    {
        IEnumerable<Food> GetAllVeganFood();
    }
}