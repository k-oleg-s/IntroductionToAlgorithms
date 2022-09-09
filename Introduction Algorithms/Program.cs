
using BenchmarkDotNet.Running;
using Introduction_Algorithms;
using System.Text;

Console.WriteLine("Start");

//BenchmarkRunner.Run<TestUnit>();

//var t = new TestUnit();
//t.FillStringContainers();
//t.IsExistsInMassive("asd");
//t.IsExistsInHashSet("asd");



var t = new TreeNode();
t.Insert(50);

int x, y = -1;
for (int i = 0; i < 100; i++)
{
    x = new Random().Next(100);
    t.Insert(x);
    if (i == 39) y = x;
}

Console.WriteLine($" значение {y}, у Node Value ={t.GetNodeByValue(y).Value} ");
t.PrintTree();



Console.WriteLine("End");