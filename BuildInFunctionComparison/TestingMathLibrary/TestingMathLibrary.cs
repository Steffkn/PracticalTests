/*
    Math.Pow is 2/3 slower than a for loop
 */
namespace TestingMathLibrary
{
    using System;
    using System.Diagnostics;
    using System.Numerics;

    public class TestingMathLibrary
    {
        static void Main()
        {
            Stopwatch stopwatch = new Stopwatch();
            double iterations = 1024; // maximum for big integer on my machine 2^1024
            double power = 0;
            BigInteger bigInt = new BigInteger();

            Console.WriteLine($"{1024} iterations");
            // testing Math.Pow
            stopwatch.Start();
            power = 1;
            for (int i = 0; i < 1024; i++)
            {
                power = Math.Pow(1, i);
            }
            stopwatch.Stop();
            PrintResult(stopwatch.Elapsed, "Math.Pow");
            stopwatch.Reset();

            // testing power = power * 1
            stopwatch.Start();
            power = 1;
            for (int i = 0; i < 1024; i++)
            {
                power = power * 1;
            }
            stopwatch.Stop();
            PrintResult(stopwatch.Elapsed, "power = power * 1");
            stopwatch.Reset();

            Console.WriteLine($"{100000000} iterations");

            // testing Math.Pow
            stopwatch.Start();
            power = 1;
            for (int i = 0; i < 100000000; i++)
            {
                power = Math.Pow(1, i);
            }
            stopwatch.Stop();
            PrintResult(stopwatch.Elapsed, "Math.Pow");
            stopwatch.Reset();

            // testing power = power * 1
            stopwatch.Start();
            power = 1;
            for (int i = 0; i < 100000000; i++)
            {
                power = power * 1;
            }
            stopwatch.Stop();
            PrintResult(stopwatch.Elapsed, "power = power * 1");
            stopwatch.Reset();

            Console.WriteLine($"BigInteger {iterations} iterations");

            // testing BigInteger with Math.Pow
            stopwatch.Start();
            power = 1;
            for (int i = 0; i < iterations; i++)
            {
                bigInt = (BigInteger)Math.Pow(2, i);
            }
            stopwatch.Stop();
            PrintResult(stopwatch.Elapsed, "BigInteger with Math.Pow");
            stopwatch.Reset();

            // testing BigInteger with power = power * 1
            stopwatch.Start();
            power = 1;
            for (int i = 0; i < iterations; i++)
            {
                bigInt = bigInt * 2;
            }
            stopwatch.Stop();
            PrintResult(stopwatch.Elapsed, "BigInteger with power = power * 1");
            stopwatch.Reset();
        }

        public static void PrintResult(TimeSpan ts, string name)
        {
            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:0000}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
            Console.WriteLine(string.Format("RunTime for {0} {1}", name, elapsedTime));
        }
    }
}
