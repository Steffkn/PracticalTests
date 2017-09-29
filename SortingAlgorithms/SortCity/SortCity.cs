namespace SortCity
{
    using System;
    using System.Collections.Generic;

    using Algorithms;
    using Algorithms.BubbleSortAndVariants;
    using Algorithms.DistributionSorts;
    using Algorithms.EfficientSorts;
    using Algorithms.SimpleSorts;
    using DataLib;
    using System.Diagnostics;

    public class SortCity
    {
        static void Main(string[] args)
        {
            Stopwatch StopWatch = new Stopwatch();

            var simpleSorts = new List<IAlgorithm>();

            //simpleSorts.Add(new InsertionSort("InsertionSort"));
            //simpleSorts.Add(new SelectionSort("SelectionSort"));
            simpleSorts.Add(new MergeSort("MergeSort"));
            simpleSorts.Add(new QuickSort("QuickSort"));
            //simpleSorts.Add(new BubbleSort("BubbleSort"));
            //simpleSorts.Add(new BubbleSortOptimised("BubbleSortOptimised"));
            simpleSorts.Add(new ShellSort("ShellSort"));
            simpleSorts.Add(new CombSort("CombSort"));
            simpleSorts.Add(new CountingSort("CountingSort"));
            simpleSorts.Add(new RadixSort("RadixSort"));

            foreach (var algorithm in simpleSorts)
            {
                int[] data = (int[])Data.Big.Clone();

                StopWatch.Start();
                var algorithmResult = algorithm.Execute(data);
                StopWatch.Stop();

                int prev = int.MinValue;

                // error check
                foreach (var item in algorithmResult)
                {
                    if (item < prev)
                    {
                        Console.WriteLine(item);
                    }
                    prev = item;
                }

                PrintResult(StopWatch.Elapsed, algorithm.AlgorithmName);
                StopWatch.Reset();
            }
        }

        public static void PrintResult(TimeSpan ts, string name)
        {
            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:0000}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
            Console.WriteLine(string.Format("RunTime for {0} {1}", name, elapsedTime));
        }
    }
}