namespace Algorithms
{
    public class StupidSort : IAlgorithm
    {
        public string Title { get; } = "Stupid Sort";

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
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    (array[i], array[i + 1]) = (array[i + 1], array[i]);
                    i = -1;
                }
            }
        }
    }
}