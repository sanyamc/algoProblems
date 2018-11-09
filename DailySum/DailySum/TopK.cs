using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySum
{
    class TopK
    {
        static int[] topK(int[] arr, int k)
        {
            if (arr.Length < k)
                return arr;

            if (k <= 0)
            {
                return new int[0];
            }

            List<int> heap = new List<int>();
            HashSet<int> set = new HashSet<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (!set.Contains(arr[i]))
                {


                    if (heap.Count < k)
                    {
                        set.Add(arr[i]);
                        InsertMinHeap(heap, arr[i]);
                    }
                    else if (arr[i] > heap[0])
                    {
                        set.Add(arr[i]);
                        ReplaceMinAndHeapify(heap, arr[i]);
                    }
                }
            }
            return heap.ToArray();
        }

        static void InsertMinHeap(List<int> heap, int value)
        {
            heap.Add(value);
            int parentIndex = (heap.Count / 2);
            if (heap.Count % 2 == 0)
            {
                parentIndex -= 1;
            }

            int currentIndex = heap.Count - 1;

            while (parentIndex >= 0 && heap[parentIndex] > heap[currentIndex])
            {
                int temp = heap[parentIndex];
                heap[parentIndex] = heap[currentIndex];
                heap[currentIndex] = temp;

                currentIndex = parentIndex;
                if (parentIndex % 2 == 0)
                {
                    parentIndex = parentIndex / 2 - 1;
                }
                else
                {
                    parentIndex = parentIndex / 2;
                }

            }
        }

        static void ReplaceMinAndHeapify(List<int> heap, int value)
        {
            int parent = 0;
            heap[parent] = value;
            int child1 = parent * 2 + 1;
            int child2 = parent * 2 + 2;

            while (true)
            {
                if (child1 < heap.Count && child2 < heap.Count)
                {
                    if (heap[parent] > heap[child1] && heap[parent] > heap[child2])
                    {
                        if (heap[child1] > heap[child2])
                        {
                            int temp = heap[child2];
                            heap[child2] = heap[parent];
                            heap[parent] = temp;
                            parent = child2;
                        }
                        else
                        {
                            int temp = heap[child1];
                            heap[child1] = heap[parent];
                            heap[parent] = temp;
                            parent = child1;
                        }
                    }
                    else if (heap[parent] > heap[child1])
                    {
                        int temp = heap[child1];
                        heap[child1] = heap[parent];
                        heap[parent] = temp;
                        parent = child1;
                    }
                    else if (heap[parent] > heap[child2])
                    {
                        int temp = heap[child2];
                        heap[child2] = heap[parent];
                        heap[parent] = temp;
                        parent = child2;
                    }
                    else
                    {
                        break;
                    }
                }
                else if (child1 < heap.Count && heap[parent] > heap[child1])
                {
                    int temp = heap[child1];
                    heap[child1] = heap[parent];
                    heap[parent] = temp;
                    parent = child1;

                }
                else if (child2 < heap.Count && heap[parent] > heap[child2])
                {
                    int temp = heap[child2];
                    heap[child2] = heap[parent];
                    heap[parent] = temp;
                    parent = child2;

                }
                else
                {
                    break;
                }
                child1 = 2 * parent + 1;
                child2 = 2 * parent + 2;

            }

        }

    }
}
