namespace Algorithms
{
    public class CountingSort : IAlgorithm
    {
        public string Title { get; } = "Counting Sort";

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
            int count = 0;
            int zero = 0;
            int one = 0;
            int two = 0;
            int three = 0;
            int four = 0;
            int five = 0;
            int six = 0;
            int seven = 0;
            int eight = 0;
            int nine = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 0) { zero++; continue; }
                if (array[i] == 1) { one++; continue; }
                if (array[i] == 2) { two++; continue; }
                if (array[i] == 3) { three++; continue; }
                if (array[i] == 4) { four++; continue; }
                if (array[i] == 5) { five++; continue; }
                if (array[i] == 6) { six++; continue; }
                if (array[i] == 7) { seven++; continue; }
                if (array[i] == 8) { eight++; continue; }
                if (array[i] == 9) { nine++; continue; }
            }

            for (int i = 0; i < zero; i++) array[count++] = 0;
            for (int i = 0; i < one; i++) array[count++] = 1;
            for (int i = 0; i < two; i++) array[count++] = 2;
            for (int i = 0; i < three; i++) array[count++] = 3;
            for (int i = 0; i < four; i++) array[count++] = 4;
            for (int i = 0; i < five; i++) array[count++] = 5;
            for (int i = 0; i < six; i++) array[count++] = 6;
            for (int i = 0; i < seven; i++) array[count++] = 7;
            for (int i = 0; i < eight; i++) array[count++] = 8;
            for (int i = 0; i < nine; i++) array[count++] = 9;
        }
        private void AlgorithmVariant2(int[] array)
        {
            int[] count = new int[10];
            for (int i = 0; i < array.Length; i++)
            {
                count[array[i]]++;
            }
            int index = 0;
            for (int i = 0; i < count.Length; i++)
            {
                for (int j = 0; j < count[i]; j++)
                {
                    array[index++] = i;
                }
            }
        }
    }
}