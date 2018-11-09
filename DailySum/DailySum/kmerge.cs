using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySum
{
    class kmerge
    {
        static int findNextElement(int[] kArray, int[][] arr, int direction)
        {

            int maxValue = int.MinValue;
            int minValue = int.MaxValue;
            int valueIndex = -1;
            int i = 0;
            for (i = 0; i < kArray.Length; i++)
            {
                int index = kArray[i];
                if (index >= arr[i].Length)
                    continue;
                else
                {
                    if (direction > 0)
                    {
                        if (arr[i][index] < minValue)
                        {
                            minValue = arr[i][index];
                            valueIndex = i;
                        }
                    }
                    else
                    {
                        if (arr[i][index] > maxValue)
                        {
                            maxValue = arr[i][index];
                            valueIndex = i;
                        }
                    }
                }
            }

            kArray[valueIndex]++;

            if (direction > 0)
                return minValue;
            else
                return maxValue;
        }

        static int[] mergeArrays(int[][] arr)
        {
            /*
             * Write your code here.
             */

            int direction = 1;

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 1; j < arr[i].Length; j++)
                {
                    if (arr[i][j] > arr[i][j - 1])
                    {
                        direction = 1;
                        i = arr.Length;
                        break;
                    }

                    else if (arr[i][j] < arr[i][j - 1])
                    {
                        direction = -1;
                        i = arr.Length;
                        break;

                    }
                }
            }

            List<int> result = new List<int>();
            List<int> kArray = new List<int>();

            for (int t = 0; t < arr.Length; t++)
            {
                kArray.Add(0);
            }


            var kA = kArray.ToArray();

            while (result.Count < (arr.Length * kA.Length))
            {
                int nextValue = findNextElement(kA, arr, direction);
                result.Add(nextValue);
            }
            return result.ToArray();

        }



    }
}
