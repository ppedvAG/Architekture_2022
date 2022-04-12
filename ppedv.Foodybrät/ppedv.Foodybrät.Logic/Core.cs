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

        public Customer? GetCustomersWithMostyValuableOrders()
        {
            return Repository.GetAll<Customer>()
                             .OrderBy(x => x.Orders.Select(y => y.Items)
                                                   .Sum(y => y.Sum(z => z.Amount * z.Food.Price)))
                             .FirstOrDefault();
        }

        public bool IsOrderVegan(Order order)
        {
            throw new NotImplementedException();
        }
    }
}