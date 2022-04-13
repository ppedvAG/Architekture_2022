using ppedv.Foodybrät.Contracts;
using ppedv.Foodybrät.Model;
using System.Collections.Generic;
using System.Linq;

namespace ppedv.Foodybrät.Data.EfCore
{
    public class EfFoodRepository : EfRepository<Food>, IFoodRepository
    {
        public EfFoodRepository(EfContext context) : base(context)
        { }

        public IEnumerable<Food> GetAllVeganFood()
        {
            return _efContext.Food.Where(x => x.Vegan);
        }
    }
}
