
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

            "test".ToList<char>();
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


        public static void PrintCombination(List<int> arr, List<int> output, int target, int curr)
        {
            if(output.Count == target)
            {
                foreach(var k in output)
                {
                    Console.Write(k + "-");
                }
                Console.WriteLine();
                return;
            }
            if (curr == arr.Count)
                return;

            output.Add(arr[curr]);
            PrintCombination(arr, output, target, curr + 1);
            output.RemoveAt(output.Count - 1);
            PrintCombination(arr, output, target, curr + 1);

        }

        public static void PrintPermutations(List<int> arr, int position)
        {
            if (position == arr.Count -1)
            {
                foreach(var k in arr)
                {
                    Console.Write(k + "-");
                }
                Console.WriteLine("");
                return;
            }

            for(int i=position; i<arr.Count; i++)
            {
                var temp = arr[i];
                arr[i] = arr[position];
                arr[position] = temp;
                PrintPermutations(arr, position + 1);

                temp = arr[i];
                arr[i] = arr[position];
                arr[position] = temp;
            }
        }

        public static void Main()
        {
            var a = new List<int> { 1,2,3,4,5,6};
            //PrintPermutations(a, 0);
            PrintCombination(a, new List<int>(), 4, 0);
        }


    }
}
