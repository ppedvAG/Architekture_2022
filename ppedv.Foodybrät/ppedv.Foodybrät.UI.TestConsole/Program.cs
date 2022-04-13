using Autofac;
using ppedv.Foodybrät.Contracts;
using ppedv.Foodybrät.Logic;
using ppedv.Foodybrät.Model;
using System.Reflection;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine("*** Foodybrät 7000 v1.0 ***");

//DI 

//DI per projekt refernez + instanzierung 
//var core = new Core(new ppedv.Foodybrät.Data.EfCore.EfUnitOfWork());

//DI manuell per Hand -> Dependency Probleme: -> EfCore package auch in UI
//var path = @"C:\Users\Fred\source\repos\Architekture_2022\ppedv.Foodybrät\ppedv.Foodybrät.Data.EfCore\bin\Debug\net6.0\ppedv.Foodybrät.Data.EfCore.dll";
//var ass = Assembly.LoadFrom(path);
//var uowType = ass.GetTypes().FirstOrDefault(x => x.GetInterfaces().Contains(typeof(IUnitOfWork)));
//var uow = (IUnitOfWork)Activator.CreateInstance(uowType);
//var core = new Core(uow);

//DI per AutoFac
var builder = new ContainerBuilder();
builder.RegisterType<ppedv.Foodybrät.Data.EfCore.EfUnitOfWork>().AsImplementedInterfaces();
var container = builder.Build();

var core = new Core(container.Resolve<IUnitOfWork>());

//core.ClearAllDataAndFillWithDemoData();
foreach (var c in core.UnitOfWork.CustomerRepository.Query().ToList())
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
