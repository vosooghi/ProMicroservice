// See https://aka.ms/new-console-template for more information
using System.Diagnostics.Metrics;

Meter s_meter = new Meter("SampleObserver", "1.0.0");
Counter<int> counter = s_meter.CreateCounter<int>("myCounter");
for (int i = 0; i < 1000; i++)
{
    counter.Add(i);
    Console.WriteLine($"{i}");
    Thread.Sleep(2000);
}
