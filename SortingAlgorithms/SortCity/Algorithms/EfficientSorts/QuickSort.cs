/*
    Worst case: O(n2)
    Best case: O(n log n) (simple partition) or O(n) (three-way partition and equal keys)
    Average: O(n log n)
*/

namespace SortCity.Algorithms.EfficientSorts
{
    using System.Collections.Generic;

    public class QuickSort : Algorithm
    {
        public QuickSort(string algorithmName) : base(algorithmName) { }

        public override IEnumerable<int> Execute(int[] array)
        {
            Sort(array, 0, array.Length - 1);
            
            return array;
        }

        public void Sort(int[] array, int lowIndex, int highIndex)
        {
            int i = lowIndex, j = highIndex;
            int pivot = array[(lowIndex + highIndex) / 2];
            int temp = 0;
            while (i <= j)
            {
                while (array[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (array[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (lowIndex < j)
            {
                Sort(array, lowIndex, j);
            }

            if (i < highIndex)
            {
                Sort(array, i, highIndex);
            }
        }
    }
}