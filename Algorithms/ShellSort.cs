namespace Algorithms
{
    public class ShellSort : IAlgorithm
    {
        public string Title { get; } = "Shell Sort";

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
            int buffer;
            int delta = array.Length / 2;
            while (delta > 0)
            {
                for (int i = 0; i < delta; i++)
                {
                    for (int j = i; j < array.Length; j += delta)
                    {
                        buffer = array[j];
                        for (int k = j - delta; k >= 0; k -= delta)
                        {
                            if (buffer < array[k])
                            {
                                (array[k + delta], array[k]) = (array[k], array[k + delta]);
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
                delta /= 2;
            }
        }
        private void AlgorithmVariant2(int[] array)
        {
            int delta = array.Length / 2;
            while (delta > 0)
            {
                for (int i = 0; i + delta < array.Length; i++)
                {
                    for (int j = i; j >= 0; j -= delta)
                    {
                        if (array[j] > array[j + delta])
                        {
                            (array[j + delta], array[j]) = (array[j], array[j + delta]);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                delta /= 2;
            }
        }
    }
}