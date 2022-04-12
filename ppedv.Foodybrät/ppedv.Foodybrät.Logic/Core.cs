using ppedv.Foodybrät.Contracts;
using ppedv.Foodybrät.Model;

namespace ppedv.Foodybrät.Logic
{
    public class Core
    {
        public IRepository Repository { get; init; }

        public Core() : this(new Data.EfCore.EfRepository())
        { }

        public Core(IRepository repository)
        {
            Repository = repository;
        }

        public Customer? GetCustomersWithMostyValuableOrder()
        {
            return Repository.Query<Order>()
                             .OrderBy(x => x.Items.Sum(y => y.Food.Price * y.Amount))
                             .FirstOrDefault().Customer;
        }

        public bool IsOrderVegan(Order order)
        {
            throw new NotImplementedException();
        }
    }
}