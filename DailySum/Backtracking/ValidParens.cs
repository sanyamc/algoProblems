using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backtracking
{
    public class ValidParens
    {

        public static void PrintParens(int size, string soFar = "", int leftCount = 0)
        {
            if (leftCount < 0)
                return;

            if (soFar.Length == size)
            {
                if (leftCount == 0)
                    Console.WriteLine(soFar);
                return;
            }

            PrintParens(size, soFar + '(', leftCount + 1);
            PrintParens(size, soFar + ')', leftCount - 1);
        }
        //}
        //static void Main(string[] args)
        //{
        //   // PrintParens(2);
        //    PrintParens(6);
        //    //PrintParens(8);
        //}
    }
}
