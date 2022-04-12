using ppedv.Foodybrät.Logic;
using ppedv.Foodybrät.Model;

Console.WriteLine("*** Foodybrät 7000 v1.0 ***");

var core = new Core();

foreach (var c in core.Repository.Query<Customer>())
{
    Console.WriteLine($"{c.Name} {c.Address} {c.Phone}");
}

Console.WriteLine($"€€€: {core.GetCustomersWithMostyValuableOrder()?.Name}");
