namespace Algorithms
{
    public class InsertionSort : IAlgorithm
    {
        public string Title { get; } = "Insertion Sort";

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
            int buffer = default;
            for (int i = 0; i < array.Length; i++)
            {
                buffer = array[i];
                for (int j = i - 1; j >= 0; j--)
                {
                    if (buffer < array[j])
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}