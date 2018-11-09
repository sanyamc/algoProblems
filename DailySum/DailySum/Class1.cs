using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySum
{
    class Class1
    {
        static void Swap(int[] arr, int index1, int index2)
        {
            int temp = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = temp;
        }

        /*
         * Complete the merger_first_into_second function below.
         */
        static int[] merger_first_into_second(int[] arr1, int[] arr2)
        {
            int n = arr1.Length;

            for (int i = n; i < arr2.Length; i++)
            {
                Swap(arr2, i - n, i);
            }

            int a1 = 0;
            int a2 = n;
            int left = 0;
            while (left < arr2.Length && a1 < arr1.Length && a2 < arr2.Length)
            {
                if (arr1[a1] < arr2[a2])
                {
                    arr2[left] = arr1[a1];
                    a1++;
                    left++;
                }

                else if (arr2[a2] <= arr1[a1])
                {
                    arr2[left] = arr2[a2];
                    a2++;
                    left++;
                }
            }

            while (a1 < arr1.Length)
            {
                arr2[left] = arr1[a1];
                left++;
                a1++;
            }

            while (a2 < arr2.Length)
            {
                arr2[left] = arr2[a2];
                left++;
                a2++;
            }

            return arr2;
        }

        public static void Main()
        {
            //int[][] arr = new int[4][3];

            int[] a1 = { 10, 4};
            int[] a2 = { 8, 13, 0, 0};

            string a = "test";
            char[] test = a.ToArray<char>();
            test[0] = 'f';
            string b = new string(test);



            //merger_first_into_second(a1, a2);


            // solve(nuts, bolts);
        }

    }
}
