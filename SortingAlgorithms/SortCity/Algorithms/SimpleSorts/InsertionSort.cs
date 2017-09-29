/* Insertion Sort algorithm test
    Best case: already sorted O(n)
    Worst case: reverse ordered array O(n*n)
    Avarage case: O(n*n)

    good for small number of elements
    bad for big number of elements

    wiki
    advantages:
        * Simple implementation: Jon Bentley shows a three-line C version, and a five-line optimized version[2]:116
        * Efficient for (quite) small data sets, much like other quadratic sorting algorithms
        * More efficient in practice than most other simple quadratic (i.e., O(n2)) algorithms such as selection sort or bubble sort
        * Adaptive, i.e., efficient for data sets that are already substantially sorted: the time complexity is O(nk) when each element in the input is no more than k places away from its sorted position
        * Stable; i.e., does not change the relative order of elements with equal keys
        * In-place; i.e., only requires a constant amount O(1) of additional memory space
        * Online; i.e., can sort a list as it receives it
 */

namespace SortCity.Algorithms.SimpleSorts
{
    using System.Collections.Generic;

    public class InsertionSort : Algorithm
    {
        public InsertionSort(string algorithmName) : base(algorithmName) { }

        public override IEnumerable<int> Execute(int[] array)
        {
            int i = 1;
            int temp = 0;
            while (i < array.Length)
            {
                int j = i;

                while (j > 0 && array[j - 1] > array[j])
                {
                    temp = array[j];
                    array[j] = array[j - 1];
                    array[j - 1] = temp;
                    j = j - 1;
                }

                i = i + 1;
            }

            return array;
        }
    }
}