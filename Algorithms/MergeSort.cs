using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Algorithms
{
    public class MergeSort : IAlgorithm
    {
        public string Title { get; } = "Merge Sort";

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
            }
        }

        private void AlgorithmVariant1(int[] array)
        {
            int[] ret = Sort(array);
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = ret[i];
            }

            int[] Sort(int[] arr)
            {
                if (arr.Length > 2)
                {
                    int[] ret1 = Sort(arr[0..(arr.Length / 2)]);
                    for (int i = 0; i < arr.Length / 2; i++)
                    {
                        arr[i] = ret1[i];
                    }
                    int[] ret2 = Sort(arr[(arr.Length / 2)..]);
                    for (int i = arr.Length / 2, j = 0; i < arr.Length; i++, j++)
                    {
                        arr[i] = ret2[j];
                    }

                    int left = 0;
                    int right = arr.Length / 2;
                    int[] res = new int[arr.Length];

                    for (int i = 0; i < res.Length; i++)
                    {
                        if (left == arr.Length / 2)
                        {
                            while (right < arr.Length) res[i++] = arr[right++];
                            break;
                        }
                        if (right == arr.Length)
                        {
                            while (left < arr.Length / 2) res[i++] = arr[left++];
                            break;
                        }
                        if (arr[left] <= arr[right]) res[i] = arr[left++];
                        else res[i] = arr[right++];
                    }

                    for (int i = 0; i < arr.Length; i++)
                    {
                        arr[i] = res[i];
                    }
                }
                if (arr.Length == 2 && arr[0] > arr[1])
                {
                    (arr[0], arr[1]) = (arr[1], arr[0]);
                }
                return arr;
            }
        }
        private void AlgorithmVariant2(int[] array)
        {
            Sort(array, 0, array.Length - 1);

            void Sort(int[] arr, int min, int max)
            {
                if (max - min > 1)
                {
                    Sort(arr, min, min + (max - min) / 2);
                    Sort(arr, min + (max - min) / 2 + 1, max);

                    int left = min;
                    int right = min + (max - min) / 2 + 1;
                    int[] res = new int[arr.Length];

                    for (int i = 0; i < res.Length; i++)
                    {
                        if (left == min + (max - min) / 2 + 1)
                        {
                            while (right < max + 1) res[i++] = arr[right++];
                            break;
                        }
                        if (right == max + 1)
                        {
                            while (left < min + (max - min) / 2 + 1) res[i++] = arr[left++];
                            break;
                        }
                        if (arr[left] <= arr[right]) res[i] = arr[left++];
                        else res[i] = arr[right++];
                    }

                    for (int i = min, j = 0; i <= max; i++, j++)
                    {
                        arr[i] = res[j];
                    }
                }
                if (max - min == 1 && arr[min] > arr[max])
                {
                    (arr[min], arr[max]) = (arr[max], arr[min]);
                }
            }
        }
        private void AlgorithmVariant3(int[] array)
        {
            Stopwatch stopwatch = new Stopwatch();

            Console.WriteLine("==================================================");
            List<int> buffer = new List<int>();
            List<int> result = new List<int>();

            bool success = true;
            while (success)
            {
                Console.Write("Введите число: ");
                success = int.TryParse(Console.ReadLine(), out int data);
                stopwatch.Start();
                if (success)
                {
                    bool ret;
                    do
                    {
                        ret = false;
                        if (buffer.Count < 2)
                        {
                            buffer.Add(data);
                        }
                        else
                        {
                            if (buffer[0] > buffer[1])
                            {
                                (buffer[0], buffer[1]) = (buffer[1], buffer[0]);
                            }
                            if (result.Count == 0)
                            {
                                result.AddRange(buffer);
                                buffer.Clear();
                                ret = true;
                            }
                            else
                            {
                                Merge(result, buffer);
                                ret = true;
                            }
                        }
                    } while (ret);
                }
                stopwatch.Stop();
                Console.WriteLine($"Отсортированный массив: {string.Join(' ', result)}");
                Console.WriteLine();
                Console.WriteLine(stopwatch.ElapsedMilliseconds / 1000D);
                Console.WriteLine();
                stopwatch.Reset();
            }
            if (buffer.Count > 0)
            {
                if (buffer.Count == 2 && buffer[0] > buffer[1])
                {
                    (buffer[0], buffer[1]) = (buffer[1], buffer[0]);
                }
                if (result.Count == 0)
                {
                    result.AddRange(buffer);
                    buffer.Clear();
                }
                else
                {
                    Merge(result, buffer);
                }
            }
            Console.WriteLine($"Отсортированный массив: {string.Join(' ', result)}");
            Console.WriteLine();
            Console.WriteLine("==================================================");
            void Merge(List<int> result, List<int> buffer)
            {
                int left = 0;
                int right = 0;
                int[] merge = new int[result.Count + buffer.Count];

                for (int i = 0; i < merge.Length; i++)
                {
                    if (left == result.Count)
                    {
                        while (right < buffer.Count) merge[i++] = buffer[right++];
                        break;
                    }
                    if (right == buffer.Count)
                    {
                        while (left < result.Count) merge[i++] = result[left++];
                        break;
                    }
                    if (result[left] <= buffer[right])
                    {
                        merge[i] = result[left++];
                    }
                    else
                    {
                        merge[i] = buffer[right++];
                    }
                }

                result.Clear();
                for (int i = 0; i < merge.Length; i++)
                {
                    result.Add(merge[i]);
                }

                buffer.Clear();
            }
        }
    }
}