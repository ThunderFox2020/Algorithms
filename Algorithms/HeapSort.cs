using System.Collections.Generic;

namespace Algorithms
{
    public class HeapSort : IAlgorithm
    {
        public string Title { get; } = "Heap Sort";

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
                case 3:
                    AlgorithmVariant3(inputArray);
                    break;
                case 4:
                    AlgorithmVariant4(inputArray);
                    break;
            }
        }

        private void AlgorithmVariant1(int[] array)
        {
            bool swap = false;
            int bound = array.Length;

            for (int i = 0, minOnLevel = 0, maxOnLevel = 0; minOnLevel <= i && i <= maxOnLevel; i++)
            {
                if (i * 2 + 1 < bound && array[i] < array[i * 2 + 1])
                {
                    (array[i], array[i * 2 + 1]) = (array[i * 2 + 1], array[i]);
                    swap = true;
                }
                if (i * 2 + 2 < bound && array[i] < array[i * 2 + 2])
                {
                    (array[i], array[i * 2 + 2]) = (array[i * 2 + 2], array[i]);
                    swap = true;
                }
                if (i == maxOnLevel)
                {
                    minOnLevel = minOnLevel * 2 + 1;
                    maxOnLevel = maxOnLevel * 2 + 2;
                }
                if (swap && i == bound)
                {
                    swap = false;
                    i = -1;
                    minOnLevel = 0;
                    maxOnLevel = 0;
                }
                if (!swap && i == bound)
                {
                    (array[0], array[bound - 1]) = (array[bound - 1], array[0]);
                    bound--;
                    i = -1;
                    minOnLevel = 0;
                    maxOnLevel = 0;
                }
                if (bound == 1)
                {
                    break;
                }
            }
        }
        private void AlgorithmVariant2(int[] array)
        {
            bool swap = false;
            int bound = array.Length;

            for (int i = 0, minOnLevel = 0, maxOnLevel = 0; minOnLevel <= i && i <= maxOnLevel; i++)
            {
                if (i * 2 + 1 < bound && array[i] < array[i * 2 + 1])
                {
                    (array[i], array[i * 2 + 1]) = (array[i * 2 + 1], array[i]);
                    swap = true;
                }
                if (i * 2 + 2 < bound && array[i] < array[i * 2 + 2])
                {
                    (array[i], array[i * 2 + 2]) = (array[i * 2 + 2], array[i]);
                    swap = true;
                }
                if (i == maxOnLevel)
                {
                    minOnLevel = minOnLevel * 2 + 1;
                    maxOnLevel = maxOnLevel * 2 + 2;
                }
                if (swap && i == bound)
                {
                    swap = false;
                    i = -1;
                    minOnLevel = 0;
                    maxOnLevel = 0;
                }
                if (!swap && i == bound)
                {
                    break;
                }
            }

            while (bound > 1)
            {
                for (int i = 0; i < bound;)
                {
                    if (i * 2 + 2 < bound && array[i * 2 + 1] >= array[i] && array[i * 2 + 1] >= array[i * 2 + 2])
                    {
                        (array[i], array[i * 2 + 1]) = (array[i * 2 + 1], array[i]);
                        i = i * 2 + 1;
                        continue;
                    }
                    else if (i * 2 + 2 < bound && array[i * 2 + 2] >= array[i] && array[i * 2 + 2] >= array[i * 2 + 1])
                    {
                        (array[i], array[i * 2 + 2]) = (array[i * 2 + 2], array[i]);
                        i = i * 2 + 2;
                        continue;
                    }
                    break;
                }
                (array[0], array[bound - 1]) = (array[bound - 1], array[0]);
                bound--;
            }
        }
        private void AlgorithmVariant3(int[] array)
        {
            int bound = array.Length;

            for (int i = (bound - 2) / 2; i >= 0; i--)
            {
                Traversal(i);
            }

            while (bound > 1)
            {
                Traversal(0);
                (array[0], array[bound - 1]) = (array[bound - 1], array[0]);
                bound--;
            }

            void Traversal(int i)
            {
                if (i * 2 + 1 < bound && i * 2 + 2 >= bound)
                {
                    if (array[i * 2 + 1] >= array[i])
                    {
                        (array[i], array[i * 2 + 1]) = (array[i * 2 + 1], array[i]);
                        Traversal(i * 2 + 1);
                    }
                }
                else if (i * 2 + 1 < bound && i * 2 + 2 < bound)
                {
                    if (array[i * 2 + 1] >= array[i] && array[i * 2 + 1] >= array[i * 2 + 2])
                    {
                        (array[i], array[i * 2 + 1]) = (array[i * 2 + 1], array[i]);
                        Traversal(i * 2 + 1);
                    }
                    else if (array[i * 2 + 2] >= array[i] && array[i * 2 + 2] >= array[i * 2 + 1])
                    {
                        (array[i], array[i * 2 + 2]) = (array[i * 2 + 2], array[i]);
                        Traversal(i * 2 + 2);
                    }
                }
            }
        }
        private void AlgorithmVariant4(int[] array)
        {
            BinaryHeap heap = new BinaryHeap();

            for (int i = 0; i < array.Length; i++)
            {
                heap.Add(array[i]);
            }

            int[] result = heap.Sort();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = result[i];
            }
        }

        private class BinaryHeap
        {
            private List<int> storage = new List<int>();

            public bool IsBalanced { get; private set; } = true;
            public int Count { get; private set; } = 0;

            public void Add(int data)
            {
                storage.Add(data);
                IsBalanced = false;
                Count++;
            }
            public void Balancing()
            {
                for (int i = (Count - 2) / 2; i >= 0; i--)
                {
                    Balancing(i, Count, storage);
                }
                IsBalanced = true;
            }
            public int[] Sort()
            {
                if (!IsBalanced)
                {
                    Balancing();
                }

                int[] result = storage.ToArray();
                int bound = result.Length;

                while (bound > 1)
                {
                    Balancing(0, bound, result);
                    (result[0], result[bound - 1]) = (result[bound - 1], result[0]);
                    bound--;
                }

                return result;
            }
            public void Balancing(int current, int bound, IList<int> storage)
            {
                int left = current * 2 + 1;
                int right = current * 2 + 2;

                if (left < bound && right >= bound)
                {
                    if (storage[left] >= storage[current])
                    {
                        (storage[current], storage[left]) = (storage[left], storage[current]);
                        Balancing(left, bound, storage);
                    }
                }
                else if (left < bound && right < bound)
                {
                    if (storage[left] >= storage[current] && storage[left] >= storage[right])
                    {
                        (storage[current], storage[left]) = (storage[left], storage[current]);
                        Balancing(left, bound, storage);
                    }
                    else if (storage[right] >= storage[current] && storage[right] >= storage[left])
                    {
                        (storage[current], storage[right]) = (storage[right], storage[current]);
                        Balancing(right, bound, storage);
                    }
                }
            }
        }
    }
}