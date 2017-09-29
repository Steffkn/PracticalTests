/*
    there is almost no difference between operator ++ and manual incrementing with n = n + 1 (1 milisecond difference for 20 mil iterations)
 */
namespace IncrementOperator
{
    using System;
    using System.Diagnostics;

    public class IncrementOperator
    {
        static void Main()
        {
            Stopwatch stopwatch = new Stopwatch();

            double number = 0.0;
            double iterations = 200000000;

            // testing ++
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                number++;
            }

            stopwatch.Stop();
            PrintResult(stopwatch.Elapsed, "++");
            stopwatch.Reset();

            // testing n += 1
            number = 0;
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                number += 1;
            }

            stopwatch.Stop();
            PrintResult(stopwatch.Elapsed, "n += 1");
            stopwatch.Reset();

            // testing n = n + 1
            number = 0;
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                number = number + 1;
            }

            stopwatch.Stop();
            PrintResult(stopwatch.Elapsed, "n = n + 1");
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