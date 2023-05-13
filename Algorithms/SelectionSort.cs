namespace Algorithms
{
    public class SelectionSort : IAlgorithm
    {
        public string Title { get; } = "Selection Sort";

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
            int maxIndex = 0;
            int bound = array.Length - 1;
            while (bound > 0)
            {
                for (int i = 0; i <= bound; i++)
                {
                    if (array[i] > array[maxIndex])
                    {
                        maxIndex = i;
                    }
                    if (i == bound)
                    {
                        (array[maxIndex], array[bound]) = (array[bound], array[maxIndex]);
                        maxIndex = 0;
                        bound--;
                    }
                }
            }
        }
        private void AlgorithmVariant2(int[] array)
        {
            int minIndex;
            for (int i = 0; i < array.Length - 1; i++)
            {
                minIndex = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }
                if (i != minIndex)
                {
                    (array[minIndex], array[i]) = (array[i], array[minIndex]);
                }
            }
        }
    }
}