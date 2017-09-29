namespace SortCity.Algorithms.BubbleSortAndVariants
{
    using System;
    using System.Collections.Generic;

    public class BubbleSortOptimised : Algorithm
    {
        public BubbleSortOptimised(string algorithmName) : base(algorithmName) { }

        public override IEnumerable<int> Execute(int[] array)
        {
            int n = array.Length;
            int newN = 0, temp;

            while (n != 0)
            {
                newN = 0;
                for (int i = 1; i <= n - 1; i++)
                {
                    if (array[i - 1] > array[i])
                    {
                        temp = array[i - 1];
                        array[i - 1] = array[i];
                        array[i] = temp;
                        newN = i;
                    }
                }
                n = newN;
            }

            return array;
        }
    }
}
