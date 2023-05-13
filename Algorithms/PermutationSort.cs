namespace Algorithms
{
    public class PermutationSort : IAlgorithm
    {
        public string Title { get; } = "Permutation Sort";

        public void Test(int variant, int[] inputArray)
        {
            switch (variant)
            {
                case 1:
                    AlgorithmVariant1(inputArray);
                    break;
                case 2:
                    AlgorithmVariant2(inputArray);
                    break;
            }
        }

        private void AlgorithmVariant1(int[] array)
        {
            if (IsSorted(array)) return;

            int[] copy = new int[array.Length];
            array.CopyTo(copy, 0);

            int pointer = array.Length - 1;

            while (pointer > 0)
            {
                int buffer = array[0];
                for (int i = 0; i <= pointer - 1; i++)
                {
                    array[i] = array[i + 1];
                }
                array[pointer] = buffer;

                if (array[pointer] != copy[pointer])
                {
                    if (IsSorted(array)) return;
                    pointer = array.Length - 1;
                }
                else
                {
                    pointer--;
                }
            }

            bool IsSorted(int[] array)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        private void AlgorithmVariant2(int[] array)
        {
            int[] result = new int[array.Length];

            Sort(array, 0, array.Length - 1);

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = result[i];
            }

            void Sort(int[] array, int min, int max)
            {
                if (min == max)
                {
                    if (IsSorted(array))
                    {
                        for (int i = 0; i < result.Length; i++)
                        {
                            result[i] = array[i];
                        }
                    }
                }
                else
                {
                    for (int i = min; i <= max; i++)
                    {
                        (array[min], array[i]) = (array[i], array[min]);
                        Sort(array, min + 1, max);
                        (array[min], array[i]) = (array[i], array[min]);
                    }
                }
            }
            bool IsSorted(int[] array)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}