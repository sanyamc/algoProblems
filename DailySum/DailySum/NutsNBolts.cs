using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySum
{
    class NutsNBolts
    {
        static string[] solve(int[] nuts, int[] bolts)
        {
            /*
             * get the pivot
               partition both nuts and bolts
               do it recursively for left and right
               add it to results
             */

            var result = new List<string>();
            quickMatch(nuts, bolts, 0, nuts.Length - 1, result);
            return result.ToArray();

        }

        static void quickMatch(int[] nuts, int[] bolts, int n_start, int n_end, List<string> result)
        {

            if (n_start == n_end)
            {
                result.Add(nuts[n_start] + " " + nuts[n_end]);
                return;
            }

            if (n_start > n_end)
            {
                return;
            }

            int pivotValue = nuts[n_start];
            int boltIndex = Array.IndexOf(bolts, pivotValue);
            result.Add(pivotValue + " " + pivotValue);
            int n_pivot = Partition(nuts, n_start, n_end, n_start, bolts[boltIndex]);
            int b_pivot = Partition(bolts, n_start, n_end, boltIndex, pivotValue);

            quickMatch(nuts, bolts, n_start, n_pivot - 1, result);
            quickMatch(nuts, bolts, n_pivot + 1, n_end, result);

        }


        static int Partition(int[] arr, int start, int end, int pivotIndex, int partitionValue)
        {

            int temp = arr[end];
            arr[end] = arr[pivotIndex];
            arr[pivotIndex] = temp;

            int left = start, current = start;

            while (current < end)
            {
                if (arr[current] < partitionValue)
                {
                    int temp2 = arr[left];
                    arr[left] = arr[current];
                    arr[current] = temp2;
                    left++;
                }
                current++;
            }

            int temp3 = arr[left];
            arr[left] = arr[end];
            arr[end] = temp3;
            return left;

        }



    }
}
