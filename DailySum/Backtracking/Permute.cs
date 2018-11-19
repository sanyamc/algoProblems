using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backtracking
{
    public class Permute
    {
        static void PermuteMain(string toPermute)
        {

            var temp = toPermute.ToArray<char>();
            PermuteHelper(temp, 0);

        }


        static void Swap(char[] temp, int i, int j)
        {

            char t = temp[i];
            temp[i] = temp[j];
            temp[j] = t;
        }


        static void PermuteHelper(char[] temp, int i)
        {

            if (i == temp.Length - 1)
            {

                foreach (var c in temp)
                    Console.Write(c);
                Console.WriteLine();

                return;

            }

            for (int j = i; j < temp.Length; j++) { 
            //{
            //    if (temp[i]==temp[j] && i!=j)
            //        continue;

                Swap(temp, i, j);

                PermuteHelper(temp, i + 1);
                Swap(temp, i, j);

            }


        }

        public static bool shouldSwap(char[] temp, int i, int j)
        {

            for (int k = 0; k <= i; k++)
            {
                if (temp[k] == temp[j] )
                    return false;
            }
            return true;

        }

        static void SwapInt(List<int> arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        public static void PermuteEvenOdd(List<int> arr, int i)
        {
            if (i == arr.Count -1)
            {
                foreach (var k in arr)
                    Console.Write(k);
                Console.WriteLine();
            }

            for(int j=i;j<arr.Count; j++)
            {
                if ((i%2==0 && arr[j]%2!=0) || (i%2!=0 && arr[j] % 2 == 0))
                {
                    SwapInt(arr, i, j);
                    PermuteEvenOdd(arr, i + 1);
                    SwapInt(arr, i, j);
                }
            }
        }

        //public static void Main()
        //{
        //    //{
        //    //    string s = "abcc";
        //    //    Permute.PermuteMain(s);

        //    //    Permute.PermuteMain("aba");

        //    var l = new List<int> { 1, 2, 3, 4 };
        //    PermuteEvenOdd(l, 0);

        //}
    }
}
