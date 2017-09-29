namespace SortCity.Algorithms
{
    using System;
    using System.Collections.Generic;

    public abstract class Algorithm : IAlgorithm
    {
        public string AlgorithmName
        {
            get => algorithmName;
            set => algorithmName = value;
        }

        private string algorithmName = "Unnamed";

        public Algorithm(string algorithmName)
        {
            this.AlgorithmName = algorithmName;
        }

        public abstract IEnumerable<int> Execute(int[] array);
    }
}
