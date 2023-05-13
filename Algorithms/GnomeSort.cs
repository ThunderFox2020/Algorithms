namespace Algorithms
{
    public class GnomeSort : IAlgorithm
    {
        public string Title { get; } = "Gnome Sort";

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
            for (int i = 0; i < array.Length;)
            {
                if (i - 1 < 0)
                {
                    i++;
                    continue;
                }
                if (array[i] >= array[i - 1])
                {
                    i++;
                }
                else
                {
                    (array[i], array[i - 1]) = (array[i - 1], array[i]);
                    i--;
                }
            }
        }
    }
}