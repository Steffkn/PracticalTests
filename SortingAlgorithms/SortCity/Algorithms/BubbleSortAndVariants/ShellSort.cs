/*
    Worst case: О(n*n)
    Best case: О(n*n)
    Average: O(n*n)
 */

namespace SortCity.Algorithms.BubbleSortAndVariants
{
    using System;
    using System.Collections.Generic;

    public class ShellSort : Algorithm
    {
        public ShellSort(string algorithmName) : base(algorithmName) { }

        public override IEnumerable<int> Execute(int[] array)
        {
            for (int gap = array.Length / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < array.Length; i++)
                {
                    int val = array[i];
                    int j;
                    for (j = i; j >= gap && array[j - gap].CompareTo(val) > 0; j -= gap)
                    {
                        array[j] = array[j - gap];
                    }
                    array[j] = val;
                }
            }

            return array;
        }
    }
}