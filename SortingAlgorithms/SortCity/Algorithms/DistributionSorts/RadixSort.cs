namespace SortCity.Algorithms.DistributionSorts
{
    using System;
    using System.Collections.Generic;

    public class RadixSort : Algorithm
    {
        public RadixSort(string algorithmName) : base(algorithmName) { }

        public override IEnumerable<int> Execute(int[] array)
        {
            // The main function to that sorts arr[] of size n using 
            // Radix Sort
            // Find the maximum number to know number of digits
            int maxNumber = GetMax(array);

            // Do counting sort for every digit. Note that instead
            // of passing digit number, exp is passed. exp is 10^i
            // where i is current digit number
            for (int exp = 1; maxNumber / exp > 0; exp *= 10)
            {
                CountSort(array, exp);
            }

            return array;
        }

        private int GetMax(int[] array)
        {
            int maxElement = array[0];
            int lenght = array.Length;

            for (int i = 1; i < lenght; i++)
            {
                if (array[i] > maxElement)
                {
                    maxElement = array[i];
                }
            }

            return maxElement;
        }

        // A function to do counting sort of arr[] according to
        // the digit represented by exp.
        void CountSort(int[] array, int exp)
        {
            int n = array.Length;
            int[] result = new int[n]; // result array
            int[] count = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int i = 0;

            // Store count of occurrences in count[]
            for (i = 0; i < n; i++)
            {
                count[(array[i] / exp) % 10]++;
            }

            // Change count[i] so that count[i] now contains actual
            //  position of this digit in result[]
            for (i = 1; i < 10; i++)
            {
                count[i] += count[i - 1];
            }

            // Build the result array
            for (i = n - 1; i >= 0; i--)
            {
                result[count[(array[i] / exp) % 10] - 1] = array[i];
                count[(array[i] / exp) % 10]--;
            }

            // Copy the result array to arr[], so that arr[] now
            // contains sorted numbers according to current digit
            for (i = 0; i < n; i++)
            {
                array[i] = result[i];
            }
        }
    }
}
