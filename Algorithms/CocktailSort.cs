namespace Algorithms
{
    public class CocktailSort : IAlgorithm
    {
        public string Title { get; } = "CocktailSort";

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
            int minBound = 0;
            int maxBound = array.Length - 1;

            bool swap;
            while (!(minBound >= maxBound))
            {
                swap = false;
                for (int i = minBound; i < maxBound; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        (array[i], array[i + 1]) = (array[i + 1], array[i]);
                        swap = true;
                    }
                }
                if (!swap)
                {
                    break;
                }
                maxBound--;
                for (int i = maxBound; i > minBound; i--)
                {
                    if (array[i] < array[i - 1])
                    {
                        (array[i], array[i - 1]) = (array[i - 1], array[i]);
                        swap = true;
                    }
                }
                if (!swap)
                {
                    break;
                }
                minBound++;
            }
        }
    }
}