
using BenchmarkDotNet.Running;
using Introduction_Algorithms;
using System.Text;

Console.WriteLine("Start");

//BenchmarkRunner.Run<TestUnit>();

//var tst = new TestUnit();
//tst.IsExistsInMassive();
//tst.IsExistsInHashSet();




// Создадим ROOT node. Ей зададим к примеру значение 50
var t = new TreeNode();
t.Insert(50);

//  ЗАПОЛНЕНИЕ ДЕРЕВА
int x=0, y = -1;


for (int i = 0; i < 15; i++)
{
    x = new Random().Next(100);

    t.Insert(x);
    if (i == 5) y = x; // ЗАПОМНИМ 9-е ЗНАЧЕНИЕ
}

// ПРОВЕРКА этого 9го ЗНАЧЕНИЯ
//Console.WriteLine($" значение {y}, у Node Value ={t.GetNodeByValue(y).Value} ");


// РАСПЕЧАТКА ДЕРЕВА
//t.PrintTree();

Console.WriteLine(" ----------BFS---------- ");
TreeHelper.GoBFS(t);

Console.WriteLine(" ----------DFS---------- ");
TreeHelper.GoDFS(t);




Console.WriteLine("End");