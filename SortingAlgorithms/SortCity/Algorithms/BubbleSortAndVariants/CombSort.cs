namespace SortCity.Algorithms.BubbleSortAndVariants
{
    using System;
    using System.Collections.Generic;

    public class CombSort : Algorithm
    {
        public CombSort(string algorithmName) : base(algorithmName) { }

        public override IEnumerable<int> Execute(int[] array)
        {
            int gap = array.Length;
            double shrinkFactor = 1.3;
            bool sorted = false;

            while (sorted == false)
            {
                gap = (int)Math.Floor((int)gap / shrinkFactor);

                if (gap > 1)
                {
                    sorted = false;
                }
                else
                {
                    gap = 1;
                    sorted = true;
                }
                int i = 0;
                int temp = 0;
                while (i + gap < array.Length)
                {
                    if (array[i] > array[i + gap])
                    {
                        temp = array[i];
                        array[i] = array[i + gap];
                        array[i + gap] = temp;
                        sorted = false;
                    }

                    i++;
                }
            }

            /*
             function combsort(array input)

                gap := input.size // Initialize gap size
                shrink := 1.3 // Set the gap shrink factor
                sorted := false

                loop while sorted = false
                    // Update the gap value for a next comb
                    gap := floor(gap / shrink)
                    if gap > 1
                        sorted := false // We are never sorted as long as gap > 1
                    else
                        gap := 1
                        sorted := true // If there are no swaps this pass, we are done
                    end if

                    // A single "comb" over the input list
                    i := 0
                    loop while i + gap < input.size // See Shell sort for a similar idea
                        if input[i] > input[i+gap]
                            swap(input[i], input[i+gap])
                            sorted := false
                            // If this assignment never happens within the loop,
                            // then there have been no swaps and the list is sorted.
                         end if

                         i := i + 1
                     end loop

                 end loop
             end function
                         */

            return array;
        }
    }
}
