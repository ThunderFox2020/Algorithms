namespace Algorithms
{
    public class BubbleSort : IAlgorithm
    {
        public string Title { get; } = "Bubble Sort";

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
            bool swap;
            do
            {
                swap = false;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        (array[i], array[i + 1]) = (array[i + 1], array[i]);
                        swap = true;
                    }
                }
            } while (swap);
        }
        private void AlgorithmVariant2(int[] array)
        {
            bool swap;
            for (int i = 1; i <= array.Length - 1; i++)
            {
                swap = false;
                for (int j = 0; j < array.Length - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        swap = true;
                    }
                }
                if (!swap)
                {
                    break;
                }
            }
        }
    }
}