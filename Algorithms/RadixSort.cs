using System;
using System.Collections.Generic;

namespace Algorithms
{
    public class RadixSort : IAlgorithm
    {
        public string Title { get; } = "Radix Sort";

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
            Radix radix = new Radix();

            int rank = rankCount();
            int[] result = default!;

            for (int i = 0; i < rank; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    int rankValue = (int)(array[j] % Math.Pow(10, i + 1) / Math.Pow(10, i));
                    if (rankValue == -9) { radix.NegativeNine.Add(array[j]); continue; }
                    if (rankValue == -8) { radix.NegativeEight.Add(array[j]); continue; }
                    if (rankValue == -7) { radix.NegativeSeven.Add(array[j]); continue; }
                    if (rankValue == -6) { radix.NegativeSix.Add(array[j]); continue; }
                    if (rankValue == -5) { radix.NegativeFive.Add(array[j]); continue; }
                    if (rankValue == -4) { radix.NegativeFour.Add(array[j]); continue; }
                    if (rankValue == -3) { radix.NegativeThree.Add(array[j]); continue; }
                    if (rankValue == -2) { radix.NegativeTwo.Add(array[j]); continue; }
                    if (rankValue == -1) { radix.NegativeOne.Add(array[j]); continue; }
                    if (rankValue == 0) { radix.Zero.Add(array[j]); continue; }
                    if (rankValue == 1) { radix.One.Add(array[j]); continue; }
                    if (rankValue == 2) { radix.Two.Add(array[j]); continue; }
                    if (rankValue == 3) { radix.Three.Add(array[j]); continue; }
                    if (rankValue == 4) { radix.Four.Add(array[j]); continue; }
                    if (rankValue == 5) { radix.Five.Add(array[j]); continue; }
                    if (rankValue == 6) { radix.Six.Add(array[j]); continue; }
                    if (rankValue == 7) { radix.Seven.Add(array[j]); continue; }
                    if (rankValue == 8) { radix.Eight.Add(array[j]); continue; }
                    if (rankValue == 9) { radix.Nine.Add(array[j]); continue; }
                }
                result = radix.Result.ToArray();
                for (int k = 0; k < array.Length; k++)
                {
                    array[k] = result[k];
                }
                radix.Clear();
            }

            int rankCount()
            {
                int min = array[0];
                int max = array[0];
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] < min) min = array[i];
                    if (array[i] > max) max = array[i];
                }

                int result = 1;
                if (min < 0 && max < 0 || min < 0 && max == 0)
                {
                    result = Count(min);
                }
                else if (min < 0 && max > 0)
                {
                    int minCount = Count(min);
                    int maxCount = Count(max);
                    result = minCount > maxCount ? minCount : maxCount;
                }
                else if (min == 0 && max > 0 || min > 0 && max > 0)
                {
                    result = Count(max);
                }

                int Count(int number)
                {
                    int count = 1;
                    if (number < 0) number = -number;
                    while ((number /= 10) > 0) count++;
                    return count;
                }

                return result;
            }
        }
        private void AlgorithmVariant2(int[] array)
        {
            List<int> list = new List<int>(array);
            int rank = rankCount();

            Sort(list, rank);
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = list[i];
            }

            void Sort(List<int> list, int rank)
            {
                if (list.Count > 0)
                {
                    Radix radix = new Radix();
                    List<int> result = default!;

                    for (int i = 0; i < list.Count; i++)
                    {
                        int rankValue = (int)(list[i] % Math.Pow(10, rank) / Math.Pow(10, rank - 1));
                        if (rankValue == -9) { radix.NegativeNine.Add(list[i]); continue; }
                        if (rankValue == -8) { radix.NegativeEight.Add(list[i]); continue; }
                        if (rankValue == -7) { radix.NegativeSeven.Add(list[i]); continue; }
                        if (rankValue == -6) { radix.NegativeSix.Add(list[i]); continue; }
                        if (rankValue == -5) { radix.NegativeFive.Add(list[i]); continue; }
                        if (rankValue == -4) { radix.NegativeFour.Add(list[i]); continue; }
                        if (rankValue == -3) { radix.NegativeThree.Add(list[i]); continue; }
                        if (rankValue == -2) { radix.NegativeTwo.Add(list[i]); continue; }
                        if (rankValue == -1) { radix.NegativeOne.Add(list[i]); continue; }
                        if (rankValue == 0) { radix.Zero.Add(list[i]); continue; }
                        if (rankValue == 1) { radix.One.Add(list[i]); continue; }
                        if (rankValue == 2) { radix.Two.Add(list[i]); continue; }
                        if (rankValue == 3) { radix.Three.Add(list[i]); continue; }
                        if (rankValue == 4) { radix.Four.Add(list[i]); continue; }
                        if (rankValue == 5) { radix.Five.Add(list[i]); continue; }
                        if (rankValue == 6) { radix.Six.Add(list[i]); continue; }
                        if (rankValue == 7) { radix.Seven.Add(list[i]); continue; }
                        if (rankValue == 8) { radix.Eight.Add(list[i]); continue; }
                        if (rankValue == 9) { radix.Nine.Add(list[i]); continue; }
                    }

                    rank--;
                    if (rank > 0)
                    {
                        for (int i = 0; i < radix.AllLists.Length; i++)
                        {
                            Sort(radix.AllLists[i], rank);
                        }
                    }

                    result = radix.Result;
                    for (int i = 0; i < list.Count; i++)
                    {
                        list[i] = result[i];
                    }

                    radix.Clear();
                }
            }
            int rankCount()
            {
                int min = array[0];
                int max = array[0];
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] < min) min = array[i];
                    if (array[i] > max) max = array[i];
                }

                int result = 1;
                if (min < 0 && max < 0 || min < 0 && max == 0)
                {
                    result = Count(min);
                }
                else if (min < 0 && max > 0)
                {
                    int minCount = Count(min);
                    int maxCount = Count(max);
                    result = minCount > maxCount ? minCount : maxCount;
                }
                else if (min == 0 && max > 0 || min > 0 && max > 0)
                {
                    result = Count(max);
                }

                int Count(int number)
                {
                    int count = 1;
                    if (number < 0) number = -number;
                    while ((number /= 10) > 0) count++;
                    return count;
                }

                return result;
            }
        }

        private class Radix
        {
            public Radix()
            {
                AllLists[0] = NegativeNine;
                AllLists[1] = NegativeEight;
                AllLists[2] = NegativeSeven;
                AllLists[3] = NegativeSix;
                AllLists[4] = NegativeFive;
                AllLists[5] = NegativeFour;
                AllLists[6] = NegativeThree;
                AllLists[7] = NegativeTwo;
                AllLists[8] = NegativeOne;
                AllLists[9] = Zero;
                AllLists[10] = One;
                AllLists[11] = Two;
                AllLists[12] = Three;
                AllLists[13] = Four;
                AllLists[14] = Five;
                AllLists[15] = Six;
                AllLists[16] = Seven;
                AllLists[17] = Eight;
                AllLists[18] = Nine;
            }

            public List<int>[] AllLists { get; } = new List<int>[19];
            public List<int> NegativeNine { get; } = new List<int>();
            public List<int> NegativeEight { get; } = new List<int>();
            public List<int> NegativeSeven { get; } = new List<int>();
            public List<int> NegativeSix { get; } = new List<int>();
            public List<int> NegativeFive { get; } = new List<int>();
            public List<int> NegativeFour { get; } = new List<int>();
            public List<int> NegativeThree { get; } = new List<int>();
            public List<int> NegativeTwo { get; } = new List<int>();
            public List<int> NegativeOne { get; } = new List<int>();
            public List<int> Zero { get; } = new List<int>();
            public List<int> One { get; } = new List<int>();
            public List<int> Two { get; } = new List<int>();
            public List<int> Three { get; } = new List<int>();
            public List<int> Four { get; } = new List<int>();
            public List<int> Five { get; } = new List<int>();
            public List<int> Six { get; } = new List<int>();
            public List<int> Seven { get; } = new List<int>();
            public List<int> Eight { get; } = new List<int>();
            public List<int> Nine { get; } = new List<int>();
            public List<int> Result
            {
                get
                {
                    List<int> result = new List<int>();
                    for (int i = 0; i < AllLists.Length; i++)
                    {
                        result.AddRange(AllLists[i]);
                    }
                    return result;
                }
            }

            public void Clear()
            {
                for (int i = 0; i < AllLists.Length; i++)
                {
                    AllLists[i].Clear();
                }
            }
        }
    }
}