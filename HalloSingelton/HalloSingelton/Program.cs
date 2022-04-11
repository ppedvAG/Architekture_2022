// See https://aka.ms/new-console-template for more information
using HalloSingelton;

Console.WriteLine("Hello, World!");

Parallel.For(0, 100, i => Logger.Instance.Info($"Hallo Logger #{i}"));

Logger.Instance.Info("Log test #2");