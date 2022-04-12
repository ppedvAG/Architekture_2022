using ppedv.Foodybrät.Logic;
using ppedv.Foodybrät.Model;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine("*** Foodybrät 7000 v1.0 ***");

var core = new Core();
//core.ClearAllDataAndFillWithDemoData();
foreach (var c in core.Repository.Query<Customer>().ToList())
{
    Console.WriteLine($"{c.Name} {c.Address} {c.Phone}");
    foreach (var ord in c.Orders.ToList())
    {
        Console.WriteLine($"\t{ord.OrderDate:d}");
        foreach (var item in ord.Items)
        {
            Console.WriteLine($"\t\t {item.Amount}x {item.Food.Description} {item.Food.Price:c}");
        }
    }
}

//Console.WriteLine($"€€€: {core.GetCustomersWithMostyValuableOrder()?.Name}");
