using System;

namespace Algorithms
{
    public class BogoSort : IAlgorithm
    {
        public string Title { get; } = "Bogo Sort";

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
            while (!IsSorted(array))
            {
                Randomize(array);
            }

            void Randomize(int[] array)
            {
                Random random = new Random();
                int randomElement;
                for (int i = 0; i < array.Length; i++)
                {
                    randomElement = random.Next(0, array.Length - 1);
                    (array[i], array[randomElement]) = (array[randomElement], array[i]);
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