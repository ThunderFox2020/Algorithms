using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Algorithms
{
    public static class AlgorithmTester
    {
        public static bool RequiredShow { get; set; } = true;
        public static int ArrayLength { get; set; } = 10;
        public static int MinimalNumber { get; set; } = -100;
        public static int MaximumNumber { get; set; } = 100;

        public static void TestAlgorithm(IAlgorithm algorithm, int variant)
        {
            Console.WriteLine("==================================================");

            Console.WriteLine("Алгоритм:");
            Console.WriteLine($"{algorithm.Title} ({variant}-й вариант)");
            Console.WriteLine();

            int[] sequence1 = CreateArray();
            int[] sequence2 = (int[])sequence1.Clone();

            Console.WriteLine("Исходная последовательность:");
            Console.WriteLine(string.Join(' ', sequence1));
            Console.WriteLine();

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            algorithm.Test(variant, sequence1);
            stopwatch.Stop();
            var myTime = stopwatch.ElapsedMilliseconds;

            stopwatch.Reset();

            stopwatch.Start();
            Array.Sort(sequence2);
            stopwatch.Stop();
            var referenceTime = stopwatch.ElapsedMilliseconds;

            Console.WriteLine($"Моё решение ({myTime} ms):");
            Console.WriteLine(string.Join(' ', sequence1));
            Console.WriteLine();

            Console.WriteLine($"Эталонное решение ({referenceTime} ms):");
            Console.WriteLine(string.Join(' ', sequence2));
            Console.WriteLine();

            Console.WriteLine("Результат:");
            Console.WriteLine($"Последовательности{(sequence1.SequenceEqual(sequence2) ? " " : " не ")}совпадают");

            Console.WriteLine("==================================================");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Thread.Sleep(100);
        }

        private static int[] CreateArray()
        {
            int[] array = new int[ArrayLength];

            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
                array[i] = random.Next(MinimalNumber, MaximumNumber);

            return array;
        }
    }
}