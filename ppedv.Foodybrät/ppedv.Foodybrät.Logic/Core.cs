using Bogus;
using Bogus.DataSets;
using ppedv.Foodybrät.Contracts;
using ppedv.Foodybrät.Model;

namespace ppedv.Foodybrät.Logic
{
    public class Core
    {
        public IUnitOfWork UnitOfWork { get; init; }

        public Core(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }


        public void ClearAllDataAndFillWithDemoData()
        {
            UnitOfWork.ClearData();

            int seed = 4;
            var ran = new Random(seed);
            var custFaker = new Faker<Customer>("de");
            custFaker.UseSeed(seed);
            custFaker.RuleFor(x => x.Name, x => x.Name.FullName());
            custFaker.RuleFor(x => x.Address, x => new Address("de").FullAddress());
            custFaker.RuleFor(x => x.Phone, x => x.Phone.PhoneNumber());

            var ordFaker = new Faker<Order>("de");
            ordFaker.UseSeed(4);
            ordFaker.RuleFor(x => x.OrderDate, x => x.Date.Past());

            var foodFaker = new Faker<Food>("de");
            foodFaker.UseSeed(4);
            foodFaker.RuleFor(x => x.Description, x => $"{x.Commerce.Color()} {x.Commerce.Product()}");
            foodFaker.RuleFor(x => x.Price, x => x.Random.Decimal(1, 20));
            foodFaker.RuleFor(x => x.Kcal, x => x.Random.Int(100, 1000));
            foodFaker.RuleFor(x => x.Vegetarian, x => x.Random.Bool());
            foodFaker.RuleFor(x => x.Vegan, x => x.Random.Bool());
            var foods = foodFaker.Generate(20);
            foods.ForEach(x => UnitOfWork.FoodRepository.Add(x));

            var ordItemFaker = new Faker<OrderItem>("de");
            ordItemFaker.UseSeed(4);
            ordItemFaker.RuleFor(x => x.Amount, x => x.Random.Int(1, 5));
            ordItemFaker.RuleFor(x => x.Food, x => x.PickRandom(foods));

            foreach (var c in custFaker.Generate(100))
            {
                UnitOfWork.CustomerRepository.Add(c);

                for (int i = 0; i < ran.Next(1, 5); i++)
                {
                    var order = ordFaker.Generate();
                    c.Orders.Add(order);
                    for (int j = 0; j < ran.Next(1,4); j++)
                    {
                        var item = ordItemFaker.Generate();
                        order.Items.Add(item);
                    }
                }
            }
            UnitOfWork.SaveAll();
        }



        public Customer? GetCustomersWithMostyValuableOrder()
        {
            return UnitOfWork.GetRepo<Order>().Query()
                             .OrderByDescending(x => x.Items.Sum(y => y.Food.Price * y.Amount))
                             .FirstOrDefault().Customer;
        }

        public bool IsOrderVegan(Order order)
        {
            throw new NotImplementedException();
        }
    }
}