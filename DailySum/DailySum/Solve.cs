
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySum
{
    class ProblemSet1
    {
        static string[] findZeroSum(int[] arr)
        {
            if (arr.Length < 3)
                return new string[0];

            Array.Sort(arr, 0, arr.Length);
            List<string> result = new List<string>();
            int i = 0;

            while(i<arr.Length)
            {
                int toLookFor = arr[i] == 0 ? 0 : -arr[i];
                int left = i + 1;
                int right = arr.Length - 1;

                while (left < right)
                {
                    if ((arr[left] + arr[right]) == toLookFor)
                    {
                        result.Add(arr[i] + "," + arr[left] + "," + arr[right]);
                        left = newIndex(arr, left, 1);
                        right = newIndex(arr, right, -1);
                    }
                    else if ((arr[left] + arr[right]) < toLookFor)
                    {
                        left = newIndex(arr, left, 1);
                    }
                    else
                    {
                        right = newIndex(arr, right, -1);
                    }
                }
                i = newIndex(arr, i, 1);
            }
            return result.ToArray();

        }

        static int newIndex(int[] arr, int currentIndex, int direction)
        {
            int temp = arr[currentIndex];
            if (direction > 0)
            {

                while (currentIndex < arr.Length)
                {

                    if (temp == arr[currentIndex])
                        currentIndex++;
                    else
                        break;
                }
                return currentIndex;
            }
            else
            {
                while (currentIndex >= 0)
                {
                    if (temp == arr[currentIndex])
                        currentIndex--;
                    else
                        break;
                }
                return currentIndex;
            }
        }


    }
}
