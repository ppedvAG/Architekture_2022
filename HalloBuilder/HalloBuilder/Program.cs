// See https://aka.ms/new-console-template for more information
using HalloBuilder;

Console.WriteLine("Hello, World!");

var meinSchrank = new Schrank.Builder()
    .Türen(12)
    .Oberfläche(Oberfläche.Lackiert)
    .Build();
