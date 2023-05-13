using System;

namespace Algorithms
{
    public static class Program
    {
        public static bool BubbleSort { get; set; } = true;
        public static bool CocktailSort { get; set; } = true;
        public static bool InsertionSort { get; set; } = true;
        public static bool ShellSort { get; set; } = true;
        public static bool TreeSort { get; set; } = true;
        public static bool HeapSort { get; set; } = true;
        public static bool SelectionSort { get; set; } = true;
        public static bool StupidSort { get; set; } = true;
        public static bool GnomeSort { get; set; } = true;
        public static bool RadixSort { get; set; } = true;
        public static bool CountingSort { get; set; } = true;
        public static bool MergeSort { get; set; } = true;
        public static bool QuickSort { get; set; } = true;
        public static bool BogoSort { get; set; } = true;
        public static bool PermutationSort { get; set; } = true;

        public static void Main()
        {
            if (BubbleSort) TestBubbleSort();
            if (CocktailSort) TestCocktailSort();
            if (InsertionSort) TestInsertionSort();
            if (ShellSort) TestShellSort();
            if (TreeSort) TestTreeSort();
            if (HeapSort) TestHeapSort();
            if (SelectionSort) TestSelectionSort();
            if (StupidSort) TestStupidSort();
            if (GnomeSort) TestGnomeSort();
            if (RadixSort) TestRadixSort();
            if (CountingSort) TestCountingSort();
            if (MergeSort) TestMergeSort();
            if (QuickSort) TestQuickSort();
            if (BogoSort) TestBogoSort();
            if (PermutationSort) TestPermutationSort();

            Console.WriteLine("Выполнено");
            Console.ReadLine();
        }

        private static void TestBubbleSort()
        {
            BubbleSort bubbleSort = new BubbleSort();
            AlgorithmTester.TestAlgorithm(bubbleSort, 1);
            AlgorithmTester.TestAlgorithm(bubbleSort, 2);
        }
        private static void TestCocktailSort()
        {
            CocktailSort cocktailSort = new CocktailSort();
            AlgorithmTester.TestAlgorithm(cocktailSort, 1);
        }
        private static void TestInsertionSort()
        {
            InsertionSort insertionSort = new InsertionSort();
            AlgorithmTester.TestAlgorithm(insertionSort, 1);
        }
        private static void TestShellSort()
        {
            ShellSort shellSort = new ShellSort();
            AlgorithmTester.TestAlgorithm(shellSort, 1);
            AlgorithmTester.TestAlgorithm(shellSort, 2);
        }
        private static void TestTreeSort()
        {
            TreeSort treeSort = new TreeSort();
            AlgorithmTester.TestAlgorithm(treeSort, 1);
            AlgorithmTester.TestAlgorithm(treeSort, 2);
            AlgorithmTester.TestAlgorithm(treeSort, 3);
        }
        private static void TestHeapSort()
        {
            HeapSort heapSort = new HeapSort();
            AlgorithmTester.TestAlgorithm(heapSort, 1);
            AlgorithmTester.TestAlgorithm(heapSort, 2);
            AlgorithmTester.TestAlgorithm(heapSort, 3);
            AlgorithmTester.TestAlgorithm(heapSort, 4);
        }
        private static void TestSelectionSort()
        {
            SelectionSort selectionSort = new SelectionSort();
            AlgorithmTester.TestAlgorithm(selectionSort, 1);
            AlgorithmTester.TestAlgorithm(selectionSort, 2);
        }
        private static void TestStupidSort()
        {
            StupidSort stupidSort = new StupidSort();
            AlgorithmTester.TestAlgorithm(stupidSort, 1);
        }
        private static void TestGnomeSort()
        {
            GnomeSort gnomeSort = new GnomeSort();
            AlgorithmTester.TestAlgorithm(gnomeSort, 1);
        }
        private static void TestRadixSort()
        {
            RadixSort radixSort = new RadixSort();
            AlgorithmTester.TestAlgorithm(radixSort, 1);
            AlgorithmTester.TestAlgorithm(radixSort, 2);
        }
        private static void TestCountingSort()
        {
            CountingSort countingSort = new CountingSort();
            AlgorithmTester.TestAlgorithm(countingSort, 1);
            AlgorithmTester.TestAlgorithm(countingSort, 2);
        }
        private static void TestMergeSort()
        {
            MergeSort mergeSort = new MergeSort();
            AlgorithmTester.TestAlgorithm(mergeSort, 1);
            AlgorithmTester.TestAlgorithm(mergeSort, 2);
            AlgorithmTester.TestAlgorithm(mergeSort, 3);
        }
        private static void TestQuickSort()
        {
            QuickSort quickSort = new QuickSort();
            AlgorithmTester.TestAlgorithm(quickSort, 1);
        }
        private static void TestBogoSort()
        {
            BogoSort bogoSort = new BogoSort();
            AlgorithmTester.TestAlgorithm(bogoSort, 1);
        }
        private static void TestPermutationSort()
        {
            PermutationSort permutationSort = new PermutationSort();
            AlgorithmTester.TestAlgorithm(permutationSort, 1);
            AlgorithmTester.TestAlgorithm(permutationSort, 2);
        }
    }
}