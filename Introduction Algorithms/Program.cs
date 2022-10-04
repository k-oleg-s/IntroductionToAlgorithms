
using Introduction_Algorithms;
using System.Text;

Console.WriteLine("Start");







var graf = new Graf();

// Создадим ROOT node. Ей зададим к примеру значение 50
Node n1 = new Node() { Value = 50 };

// Добавляем остальные node - картинка прилагается.
var n2 = graf.AddNode(n1, 40, 4);
var n3 = graf.AddNode(n2, 60, 6);
var n4 = graf.AddNode(n3, 45, 3);
var n5 = graf.AddNode(n4, 75, 2);
var n6 = graf.AddNode(n5, 80, 5);

var n7 = graf.AddNode(n2, 39, 1);

n7.Edges.Add(new Edge() { N=n4, Weight=3});
n4.Edges.Add(new Edge() { N = n7, Weight = 3 });

var n8 = graf.AddNode(n5, 49, 1);

n1.Edges.Add(new Edge() { N = n6, Weight = 9 });
n6.Edges.Add(new Edge() { N = n1, Weight = 9 });

n7.Edges.Add(new Edge() { N = n6, Weight = 4 });
n6.Edges.Add(new Edge() { N = n7, Weight = 4 });




// РАСПЕЧАТКА ДЕРЕВА

Console.WriteLine(" ----------BFS---------- ");
graf.GoGraphBFS(n1);

Console.WriteLine("  \n \n");
Console.WriteLine(" ----------DFS---------- ");
graf.GoGraphDFS(n1);




Console.WriteLine("End");