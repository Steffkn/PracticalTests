namespace SortCity.Algorithms
{
    using System;
    using System.Collections.Generic;

    public interface IAlgorithm
    {
        string AlgorithmName { get; set; }

        IEnumerable<int> Execute(int[] array);
    }
}
