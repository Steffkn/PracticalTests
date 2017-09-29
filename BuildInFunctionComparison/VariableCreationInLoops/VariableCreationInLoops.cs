/*
    Surprisingly variable created inside the loop makes it run faster after the billion iteration with few miliseconds
    Swapping 2 variables without 3rd temp variable is around 2.5x slower
 */
namespace VariableCreationInLoops
{
    using System;
    using System.Diagnostics;

    public class VariableCreationInLoops
    {
        static void Main()
        {
            Stopwatch stopwatch = new Stopwatch();

            double iterations = 1000000000;
            int outsideVariableInit = 0;

            int dataA = 212312;
            int dataB = -172463;

            // testing outside variable creation
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                outsideVariableInit = dataB;
                dataB = dataA;
                dataA = outsideVariableInit;
            }
            stopwatch.Stop();
            PrintResult(stopwatch.Elapsed, "outside variable creation");
            stopwatch.Reset();

            // testing inside the loop variable creation
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                int insideVariableInit = dataB;
                dataB = dataA;
                dataA = insideVariableInit;
            }
            stopwatch.Stop();
            PrintResult(stopwatch.Elapsed, "inside the loop variable creation");
            stopwatch.Reset();

            // testing swap variables without 3rd variable
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                dataA = dataB + dataA;
                dataB = dataA - dataB;
                dataA = dataA - dataB;
            }
            stopwatch.Stop();
            PrintResult(stopwatch.Elapsed, "swap variables without 3rd variable");
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
