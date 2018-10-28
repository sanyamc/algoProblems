using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    public class ReverseStrings
    {
        /*
         * O(n) runtime complexity, O(n) space complexity
         * 
         */
        public static string ReverseWordsWithStack(string Original)
        {
            if (Original == null || Original.Length <= 1)
                return Original;
            int left = 0, current = 0;
            Stack<string> resultStack = new Stack<string>();
            //string result = "";
            

            while (current < Original.Length)
            {
                if (Original.ElementAt(current) == ' ')
                    if (current != left)
                    {
                        resultStack.Push(Original.Substring(left, current-left));
                        left = current;
                    }
                    else
                    {
                        resultStack.Push(" ");
                        left++;
                        current++;
                    }
                else
                {
                    current++;
                }

            }
            resultStack.Push(Original.Substring(left, current - left));
            var sb = new StringBuilder();
            while(resultStack.Count >0)
            {
                sb.Append(resultStack.Pop());

            }
            return sb.ToString();
        }

        /*
         * 
         * Reverses a string with given start and end; combines with remaining chars
         * Use of string.Join("", str.Reverse()); // to reverse a string
         * 
         */
        public static string ReverseString(string Original, int start, int end)
        {
            var sub = Original.Substring(start, end - start);

            return Original.Substring(0, start) + string.Join("", sub.Reverse()) + Original.Substring(end);
        }

        /*
         * Reversing a string with two internal reverse operations
         * O(n) run time, constant space
         * NOTE: I reversed the order of operations, still it resulted in same output.
         */

        public static string ReverseWords(string Original)
        {
            if (Original == null || Original.Length <= 1)
                return Original;

            string Reversed = ReverseString(Original, 0, Original.Length);

            int left = 0, current = 0;

            while (current < Reversed.Length)
            {
                if (Reversed.ElementAt(current) == ' ')
                {
                    if (current == left)
                    {
                        current++; left++;
                    }
                    else
                    {
                        Reversed = ReverseString(Reversed, left, current);
                        left = current;
                    }
                }
                else
                {
                    current++;
                }
            }
            Reversed = ReverseString(Reversed, left, current);
            return Reversed;


        }

        //static void Main(string[] args)
        //{
        //    Console.WriteLine(ReverseStrings.ReverseWordsWithStack("This is a test"));
        //    Console.WriteLine(ReverseStrings.ReverseWordsWithStack("   This is a class with spaces and a "));

        //    Console.WriteLine(ReverseStrings.ReverseWords("This is a test"));
        //    Console.WriteLine(ReverseStrings.ReverseWords("   This is a class with spaces and a "));

        //}
    }
}
