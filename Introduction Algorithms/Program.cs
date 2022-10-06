
using Introduction_Algorithms;

Console.WriteLine("Start");

int[] arr = new int[10]; 
var rnd = new Random();
for (int i = 0; i < arr.Length; i++)
{
    arr[i] = rnd.Next(100);
}

Console.WriteLine($" До сортировки: ");
foreach (int i in arr)
{
    Console.Write($"{i}, ");
}

var bs = new Sort();
var sorted = bs.BucketSort(arr);

Console.WriteLine($" После сортировки: ");
foreach (int i in sorted)
{
    Console.Write($"{i}, ");
}