using System;
using System.Collections.Generic;

namespace Algorithms
{
    public class TreeSort : IAlgorithm
    {
        public string Title { get; } = "Tree Sort";

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
            int[] tree = new int[(int)Math.Pow(2, array.Length)];

            for (int i = 0; i < array.Length; i++)
            {
                fillTree(array[i], 0);
            }

            int index = 0;
            int currentNode = 0;
            int previousNode = 0;

            if (tree[currentNode] != 0)
            {
            Mark1:
                if (currentNode * 2 + 1 < tree.Length && tree[currentNode * 2 + 1] != 0)
                {
                    previousNode = currentNode;
                    currentNode = currentNode * 2 + 1;
                    goto Mark1;
                }
                array[index++] = tree[currentNode];
                if (currentNode * 2 + 2 < tree.Length && tree[currentNode * 2 + 2] != 0)
                {
                    previousNode = currentNode;
                    currentNode = currentNode * 2 + 2;
                    goto Mark1;
                }
                else
                {
                    previousNode = currentNode;
                    currentNode = (currentNode - 1) / 2;
                Mark2:
                    if (previousNode == currentNode * 2 + 1)
                    {
                        array[index++] = tree[currentNode];
                        if (currentNode * 2 + 2 < tree.Length && tree[currentNode * 2 + 2] != 0)
                        {
                            previousNode = currentNode;
                            currentNode = currentNode * 2 + 2;
                            goto Mark1;
                        }
                        else
                        {
                            previousNode = currentNode;
                            currentNode = (currentNode - 1) / 2;
                            goto Mark2;
                        }
                    }
                    if (previousNode == currentNode * 2 + 2)
                    {
                        previousNode = currentNode;
                        currentNode = (currentNode - 1) / 2;
                        goto Mark2;
                    }
                }
            }

            void fillTree(int data, int node)
            {
                if (data < tree[node])
                {
                    if (tree[node] == 0)
                    {
                        tree[node] = data;
                    }
                    else
                    {
                        fillTree(data, node * 2 + 1);
                    }
                }
                else
                {
                    if (tree[node] == 0)
                    {
                        tree[node] = data;
                    }
                    else
                    {
                        fillTree(data, node * 2 + 2);
                    }
                }
            }
        }
        private void AlgorithmVariant2(int[] array)
        {
            int[] tree = new int[(int)Math.Pow(2, array.Length)];

            int min = 0;
            int max = tree.Length - 1;
            int current = (max - min) / 2;

            tree[current] = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                fillTree(min, max, current, array[i]);
            }

            for (int i = 0, j = 0; i < tree.Length; i++)
            {
                if (tree[i] != 0)
                {
                    array[j++] = tree[i];
                }
            }

            void fillTree(int min, int max, int current, int data)
            {
                if (0 <= current && current < tree.Length && data < tree[current])
                {
                    max = current;
                    current = min + (max - min) / 2;
                    if (0 <= current && current < tree.Length && tree[current] == 0)
                    {
                        tree[current] = data;
                    }
                    else
                    {
                        fillTree(min, max, current, data);
                    }
                }
                else
                {
                    min = current;
                    current = min + (max - min) / 2;
                    if (0 <= current && current < tree.Length && tree[current] == 0)
                    {
                        tree[current] = data;
                    }
                    else
                    {
                        fillTree(min, max, current, data);
                    }
                }
            }
        }
        private void AlgorithmVariant3(int[] array)
        {
            BinaryTree tree = new BinaryTree(array[0]);
            for (int i = 1; i < array.Length; i++)
            {
                tree.Add(array[i]);
            }

            List<int> sequence = tree.Traversal();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = sequence[i];
            }
        }

        private class BinaryTree
        {
            public BinaryTree(int data)
            {
                this.data = data;
            }

            private int data;
            private BinaryTree? left;
            private BinaryTree? right;

            public void Add(int inputData)
            {
                if (inputData < data)
                {
                    if (left == null)
                    {
                        left = new BinaryTree(inputData);
                    }
                    else
                    {
                        left.Add(inputData);
                    }
                }
                else
                {
                    if (right == null)
                    {
                        right = new BinaryTree(inputData);
                    }
                    else
                    {
                        right.Add(inputData);
                    }
                }
            }
            public List<int> Traversal(List<int>? sequence = null)
            {
                if (sequence == null)
                {
                    sequence = new List<int>();
                }

                if (left != null)
                {
                    left.Traversal(sequence);
                }

                sequence.Add(data);

                if (right != null)
                {
                    right.Traversal(sequence);
                }

                return sequence;
            }
        }
    }
}