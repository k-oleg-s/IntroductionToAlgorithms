using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction_Algorithms;

    public class TestCase
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int ExpectedI { get; set; }
        public string ExpectedS { get; set; }
        public Exception ExpectedException { get; set; }


    public void TestSimpleNumber(TestCase testCase)
    {
        try
        {
            var actual = Algorithms.SimpleNumber(testCase.X);
            if (actual == testCase.ExpectedS)
            {
                Console.WriteLine("VALID TEST");
            }
            else
            {
                Console.WriteLine("INVALID TEST");
            }
        }
        catch (Exception ex)
        {
            if (testCase.ExpectedException != null)
            {
                //TODO add type exception tests;
                Console.WriteLine("ex VALID TEST");
            }
            else
            {
                Console.WriteLine("ex INVALID TEST");
            }
        }
    }

    public void TestFiboRecursive(TestCase testCase)
        {
            try
            {
                var actual = Algorithms.F_recurse(testCase.X);
                if (actual == testCase.ExpectedI)
                {
                    Console.WriteLine("recurse VALID TEST");
                }
                else
                {
                    Console.WriteLine("recurse INVALID TEST");
                }
            }
            catch (Exception ex)
            {
                if (testCase.ExpectedException != null)
                {
                    //TODO add type exception tests;
                    Console.WriteLine("ex recurse VALID TEST");
                }
                else
                {
                    Console.WriteLine("ex recurse INVALID TEST");
                }
            }
        }

        public void TestFiboCycleFor(TestCase testCase)
        {
            try
            {
                var actual = Algorithms.F_cycle(testCase.X);
                if (actual == testCase.ExpectedI)
                {
                    Console.WriteLine("cycleFor VALID TEST");
                }
                else
                {
                    Console.WriteLine("cycleFor INVALID TEST");
                }
            }
            catch (Exception ex)
            {
                if (testCase.ExpectedException != null)
                {
                    //TODO add type exception tests;
                    Console.WriteLine("ex cycleFor VALID TEST");
                }
                else
                {
                    Console.WriteLine("ex cycleFor INVALID TEST");
                }
            }
        }


    }

