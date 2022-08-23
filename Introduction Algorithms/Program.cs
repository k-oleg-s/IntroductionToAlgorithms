using Introduction_Algorithms;

Console.WriteLine("Start");


TestCase mainTester = new TestCase();
List<TestCase> tests = new List<TestCase>();


// Простое число

tests.Add(new TestCase() { X = 17, ExpectedS = "y" });
tests.Add(new TestCase() { X = 29, ExpectedS = "y" });
tests.Add(new TestCase() { X = 43, ExpectedS = "y" });
tests.Add(new TestCase() { X = 14, ExpectedS = "n" });  //не простое
tests.Add(new TestCase() { X = 25, ExpectedS = "n" });  //не простое

Console.WriteLine("     Простое число");
foreach (TestCase testCase in tests)
{
    mainTester.TestSimpleNumber(testCase);
}
tests.Clear();



//числа Фибоначчи
// 0	1	2	3	4	5	6	7   9   10
// 0	1	1	2	3	5	8	13  34  55
//tests.Add(new TestCase() { X = 0, ExpectedI = 0 });
tests.Add(new TestCase() { X = 2, ExpectedI = 1 });
tests.Add(new TestCase() { X = 4, ExpectedI = 3 });
tests.Add(new TestCase() { X = 7, ExpectedI = 13 });
tests.Add(new TestCase() { X = 9, ExpectedI = 33 });    // must be 34
tests.Add(new TestCase() { X = 10, ExpectedI = 54 });   // must be 55

Console.WriteLine("\n \n   числа Фибоначчи");
foreach (TestCase testCase in tests)
{
    Console.WriteLine($" for X={testCase.X}  Expected result:{testCase.ExpectedI}");
    mainTester.TestFiboRecursive(testCase);
    mainTester.TestFiboCycleFor(testCase);
    Console.WriteLine(" ");
}

tests.Clear();


Console.ReadLine();