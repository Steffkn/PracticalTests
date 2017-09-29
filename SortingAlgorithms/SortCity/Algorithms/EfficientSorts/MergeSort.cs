/*
    Worst case: O(n log n)
    Best case: O(n log n) typical, O(n) natural variant
    Average: O(n log n)
 */

namespace SortCity.Algorithms.EfficientSorts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MergeSort : Algorithm
    {
        public MergeSort(string algorithmName) : base(algorithmName) { }

        public override IEnumerable<int> Execute(int[] array)
        {
            var algorithmResult = MergeSortAlgorithm(array);
            return algorithmResult;
        }

        private IList<int> MergeSortAlgorithm(IList<int> array)
        {
            if (array.Count <= 1)
            {
                return array;
            }

            IList<int> leftList = new List<int>();
            IList<int> rightList = new List<int>();

            for (int i = 0; i < array.Count; i++)
            {
                if (i < (array.Count / 2))
                {
                    leftList.Add(array[i]);
                }
                else
                {
                    rightList.Add(array[i]);
                }
            }

            leftList = MergeSortAlgorithm(leftList);
            rightList = MergeSortAlgorithm(rightList);

            return Merge(leftList, rightList);
        }

        private IList<int> Merge(IList<int> leftList, IList<int> rightList)
        {
            var result = new List<int>();

            while (leftList.Count > 0 && rightList.Count > 0)
            {
                if (leftList[0] <= rightList[0])
                {
                    result.Add(leftList[0]);
                    leftList.RemoveAt(0);
                }
                else
                {
                    result.Add(rightList[0]);
                    rightList.RemoveAt(0);
                }
            }

            while (leftList.Count > 0)
            {
                result.Add(leftList[0]);
                leftList.RemoveAt(0);
            }

            while (rightList.Count > 0)
            {
                result.Add(rightList[0]);
                rightList.RemoveAt(0);
            }

            return result;
        }
    }
}
