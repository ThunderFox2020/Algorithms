namespace Algorithms
{
    public class QuickSort : IAlgorithm
    {
        public string Title { get; } = "Quick Sort";

        public void Test(int variant, int[] inputArray)
        {
            switch (variant)
            {
                case 1:
                    AlgorithmVariant1(inputArray);
                    break;
            }
        }

        private void AlgorithmVariant1(int[] array)
        {
            Sort(array, 0, array.Length - 1);

            void Sort(int[] array, int min, int max)
            {
                int pivot = max;
                int wall = min;

                if (max - min < 1)
                {
                    return;
                }

                for (int current = wall; current < pivot; current++)
                {
                    if (array[current] <= array[pivot])
                    {
                        (array[current], array[wall]) = (array[wall], array[current]);
                        wall++;
                    }
                }

                (array[pivot], array[wall]) = (array[wall], array[pivot]);

                Sort(array, min, wall - 1);
                Sort(array, wall, max);
            }
        }
    }
}