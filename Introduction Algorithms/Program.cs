
using BenchmarkDotNet.Running;
using Introduction_Algorithms;
using System.Text;

Console.WriteLine("Start");

BenchmarkRunner.Run<TestUnit>();

//var t = new TestUnit();
//t.FillStringContainers();
//t.IsExistsInMassive("asd");
//t.IsExistsInHashSet("asd");