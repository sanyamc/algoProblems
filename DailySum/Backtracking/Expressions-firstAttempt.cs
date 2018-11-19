using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backtracking
{
    class Expressions
    {

        static bool isLess(string first, string second, string[] a)
        {


            return Array.IndexOf(a,first) < Array.IndexOf(a,second);
        }
        static List<string> ConvertInfixToPostFix(List<string> infix)
        {

            var a = new string[] { "+", "*", "\"\"" };

            var s = new Stack<string>();
            var q = new List<string>();

            foreach (var i in infix)
            {
                if (Array.IndexOf(a,i) >= 0)
                {
                    while (s.Count> 0)
                    {
                        var val = s.Peek();
                        if (isLess(val, i, a))
                        {
                            break;
                        }
                        else
                        {
                            q.Add(s.Pop());
                        }
                    }
                    s.Push(i);
                }
                else
                {
                    q.Add(i);
                }

            }
            while(s.Count > 0)
            {
                q.Add(s.Pop());
            }
            return q;

        }

        static long EvaluatePostFix(List<string> postFix)
        {
            long result = 0;
            var a = new string[] { "+", "*", "\"\"" };
            var s = new Stack<string>();
            foreach (var i in postFix)
            {
                if(Array.IndexOf(a, i) >= 0)
                {
                    int first = Int32.Parse(s.Pop());
                    int second = Int32.Parse(s.Pop());
                    if(i=="\"\"")
                    {
                        s.Push(second.ToString()+ first.ToString());
                    }
                    else if(i=="*")
                    {
                        s.Push((first * second).ToString());
                    }
                    else
                    {
                        s.Push((first + second).ToString());
                    }
                }
                else
                {
                    s.Push(i);
                }
            }
            result = long.Parse(s.Pop());

            return result;
        }

        static void helper(string s, long target, int currentIndex, List<string> soFar, List<string> result)
        {

            if (currentIndex == s.Length)
            {
                var r = ConvertInfixToPostFix(soFar);
                long currVal = EvaluatePostFix(r);
                if (currVal == target)
                    result.Add(string.Join("", soFar.ToArray()));
                return;
            }

            var temp = ConvertInfixToPostFix(soFar);
            long curr = EvaluatePostFix(temp);
            if (curr > target)
                return;


            soFar.Add("\"\"");
            soFar.Add(s[currentIndex].ToString());
            helper(s, target, currentIndex + 1, soFar, result);
            soFar.RemoveAt(soFar.Count - 1);
            soFar.RemoveAt(soFar.Count - 1);
            soFar.Add("*");
            soFar.Add(s[currentIndex].ToString());
            helper(s, target, currentIndex + 1, soFar, result);
            soFar.RemoveAt(soFar.Count - 1);
            soFar.RemoveAt(soFar.Count - 1);
            soFar.Add("+");
            soFar.Add(s[currentIndex].ToString());
            helper(s, target, currentIndex + 1, soFar, result);
            soFar.RemoveAt(soFar.Count - 1);
            soFar.RemoveAt(soFar.Count - 1);


        }

        //public static void Main()
        //{
        //    //var s = new List<string>();
        //    //s.Add("2");
        //    //var r = new List<string>();

        //    //helper("222", 24, 1, s, r);
        //    //var temp = string.Join("", s.ToArray());
        //    //var t = temp.Replace("\"\"", "");

        //    var a = new List<List<string>>();
        //    var b = new List<string[]>();
        //    foreach(var i in a)
        //    {
        //        b.Add(i.ToArray());
        //    }
        //    var b = a.ToArray();


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
