/*
    StringBuilder is considerably faster than the other methods.
    Using + or string.Concat have the same results with string.Concat beeing faster with 1 milisecond
    string.Format is the slowest. 3x slower than Concat
 */
namespace StringAppending
{
    using System;
    using System.Diagnostics;

    public class StringAppending
    {
        static void Main()
        {
            Stopwatch stopwatch = new Stopwatch();
            // Use StringBuilder for concatenation in tight loops.
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            int iterations = 1000;
            string text = string.Empty;

            // testing concatination with +
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                for (int ch = 'A'; ch < 'z'; ch++)
                {
                    text += (char)i;
                }
            }
            stopwatch.Stop();
            PrintResult(stopwatch.Elapsed, "string + char");
            stopwatch.Reset();

            // testing concatination with string.Concat
            text = string.Empty;
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                for (int ch = 'A'; ch < 'z'; ch++)
                {
                    text = string.Concat(text, (char)ch);
                }
            }
            stopwatch.Stop();
            PrintResult(stopwatch.Elapsed, "string.Concat");
            stopwatch.Reset();

            // testing concatination with string.Format
            text = string.Empty;
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                for (int ch = 'A'; ch < 'z'; ch++)
                {
                    text = string.Format("{0}{1}", text, (char)ch);
                }
            }
            stopwatch.Stop();
            PrintResult(stopwatch.Elapsed, "string.Format");
            stopwatch.Reset();

            // testing concatination with StringBuilder
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                for (int ch = 'A'; ch < 'z'; ch++)
                {
                    sb.Append(ch);
                }
            }
            text = sb.ToString();
            stopwatch.Stop();
            PrintResult(stopwatch.Elapsed, "StringBuilder");
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
