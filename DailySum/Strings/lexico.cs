using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    class lexico
    {

        static string[] solve(string[] arr)
        {
            /*
             * Write your code here.
             */
            List<string> result = new List<string>();

            if (arr.Length <= 1)
            {
                var value = arr[0].Split(' ');
                result.Add(value[0] + ":" + 1 + "," + value[1]);
                return result.ToArray();
            }

            Array.Sort(arr, 0, arr.Length);

            string current = "";
            var temp = arr[0].Split(' ');
            string previous = temp[0];
            string previousVal = temp[1];
            int previousCount = 1;
            for (int i = 1; i < arr.Length; i++)
            {
                var val = arr[i].Split(' ');
                current = val[0];
                if (current != previous)
                {
                    result.Add(previous + ":" + previousCount + "," + previousVal);
                    previousCount = 1;
                    previous = current;
                }
                else
                {
                    previousCount++;
                }
                previousVal = val[1];
            }
            result.Add(previous + ":" + previousCount + previousVal);
            return result.ToArray();

        }

        //public static void Main()
        //{
        //    string[] arr = { "key1 abcd", "key4 zzzz", "key2 efef", "key1 hello" };
        //    solve(arr);
        //}
    }
}
