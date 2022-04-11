// See https://aka.ms/new-console-template for more information
using HalloDekorator;

var meinePizza = new Käse(new Käse(new Pizza()));
Console.WriteLine($"Pizza: {meinePizza.Beschreibung} {meinePizza.Preis:c}");

var frühstück = new Salami(new Ei(new Brot()));
Console.WriteLine($"Brot: {frühstück.Beschreibung} {frühstück.Preis:c}");



