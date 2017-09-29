/*
    Worst case: О(n*n)
    Best case: О(n*n)
    Average: O(n*n)
 */

namespace SortCity.Algorithms.SimpleSorts
{
    using System.Collections.Generic;

    public class SelectionSort : Algorithm
    {
        public SelectionSort(string algorithmName) : base(algorithmName) { }

        public override IEnumerable<int> Execute(int[] array)
        {
            int temp = 0;
            for (int j = 0; j < array.Length - 1; j++)
            {
                int iMin = j;

                for (int i = j + 1; i < array.Length; i++)
                {
                    if (array[i] < array[iMin])
                    {
                        iMin = i;
                    }
                }

                if (iMin != j)
                {
                    temp = array[j];
                    array[j] = array[iMin];
                    array[iMin] = temp;
                }
            }

            return array;
        }
    }
}