/*
Worst case: O(n*n)
Best case: O(n)
Average: O(n*n)
 */
namespace SortCity.Algorithms.BubbleSortAndVariants
{
    using System.Collections.Generic;

    public class BubbleSort : Algorithm
    {
        public BubbleSort(string algorithmName) : base(algorithmName) { }

        public override IEnumerable<int> Execute(int[] array)
        {
            int n = array.Length;
            int temp = 0;
            bool swapped = true;

            while (swapped)
            {
                swapped = false;
                for (int i = 1; i <= n - 1; i++)
                {
                    if (array[i - 1] > array[i])
                    {
                        temp = array[i - 1];
                        array[i - 1] = array[i];
                        array[i] = temp;
                        swapped = true;
                    }
                }
            }

            return array;
        }
    }
}
