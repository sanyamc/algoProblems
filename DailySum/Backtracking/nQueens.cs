using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backtracking
{
    class nQueens
    {

        static string[][] find_all_arrangements(int n)
        {

            var aggregator = new List<List<string>>();

            var columns = new List<int>();

            helper(n, columns, 0, aggregator);

            var result = new List<string[]>();
            foreach (var k in aggregator)
            {
                result.Add(k.ToArray());
            }


            return result.ToArray();

        }

        static bool isValid(int c1, int r1, int c2, int r2)
        {
            if (c1 == c2 || r1 == r2)
                return false;
            if (Math.Abs(c1 - c2) == Math.Abs(r1 - r2))
                return false;
            return true;
        }

        static void helper(int n, List<int> columns, int currentIndex, List<List<string>> agg)
        {

            if (currentIndex == n)
            {
                var temp = new List<string>();
                for (int i = 0; i < columns.Count; i++)
                {
                    string str = "";
                    for (int j = 0; j < n; j++)
                    {
                        if (j == columns[i])
                        {
                            str += "q";
                        }
                        else
                        {
                            str += "-";
                        }
                    }
                    temp.Add(str);
                }
                agg.Add(temp);
                return;
            }

            for (int k = 0; k < n; k++)
            {
                columns.Add(k);
                var currIndex = columns.Count - 1;
                int t = 0;
                for (t=0; t <= columns.Count - 2; t++)
                {
                    if (!isValid(columns[t], t, columns[currIndex], currIndex))
                    {
                        break;
                    }
                }
                if (t == currIndex)
                {
                    helper(n, columns, currentIndex + 1, agg);
                }
                columns.RemoveAt(currIndex);
            }


        }

        //public static void Main()
        //{
        //    //var s = new List<string>();
        //    //s.Add("2");
        //    //var r = new List<string>();

        //    //helper("222", 24, 1, s, r);
        //    //var temp = string.Join("", s.ToArray());
        //    //var t = temp.Replace("\"\"", "");

        //    nQueens.find_all_arrangements(4);




        //    //List<int> b = new List<int>(a.Skip(0).Take(5));

        //    //Console.WriteLine("abc".ToList<string>());
        //    //var a = new List<string>()
        //    //{
        //    //    "2","*","5","\"\"","3","*","2","+","1"
        //    //};
        //    //var r = Expressions.ConvertInfixToPostFix(a);
        //    //Expressions.EvaluatePostFix(r);
        //}

    }
}
