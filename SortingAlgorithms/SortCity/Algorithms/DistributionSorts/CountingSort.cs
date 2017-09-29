/*
    A key-value pair sorting algorithm. It sorts by the key's value (integers)
    O(n + k)
 */
namespace SortCity.Algorithms.DistributionSorts
{
    using System;
    using System.Collections.Generic;

    public class CountingSort : Algorithm
    {
        public CountingSort(string algorithmName) : base(algorithmName) { }

        public override IEnumerable<int> Execute(int[] array)
        {
            int n = array.Length;
            int[] count = new int[n + 1];
            int[] result = new int[n];

            //calculate the histogram of key frequencies:
            foreach (var item in array)
            {
                count[item] += 1;
            }

            //calculate the starting index for each key:
            for (int i = 1; i <= n; i++)
            {
                count[i] += count[i - 1];
            }

            // Build the output character array
            for (int i = 0; i < n; i++)
            {
                result[count[array[i]] - 1] = array[i];
                count[array[i]]--;
            }

            // Copy the output array to arr, so that arr now
            // contains sorted characters
            for (int i = 0; i < n; i++)
            {
                array[i] = result[i];
            }

            return array;
        }
    }
}
