using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backtracking
{
    public class Solution
    {
        public bool IsMatch(string s, string p)
        {
            return Solution.helper(s, p, 0, 0);

        }

        public static bool helper(string str, string pattern, int s_index, int p_index)
        {
            if (s_index >= str.Length && p_index >= pattern.Length)
                return true;
            if (p_index >= pattern.Length && s_index < str.Length)
                return false;
            if (s_index >= str.Length)
            {
                // check if all pattern has is *
                for (int j = p_index; j < pattern.Length; j++)
                {
                    if (pattern[j] != '*')
                        return false;
                }
                return true;
            }

            if (pattern[p_index] == '?' || str[s_index] == pattern[p_index])
                return helper(str, pattern, s_index + 1, p_index + 1);

            else if (pattern[p_index] == '*')
            {
                bool partial = false;
                for (int i = s_index; i <= str.Length; i++)
                {
                    partial = helper(str, pattern, i, p_index + 1);
                    if (partial)
                        return true;
                }
            }
            return false;
        }
    

    //public static void Main()
    //    {
    //       // Console.WriteLine(Solution.IsMatch("aa", "*"));
    //        Console.WriteLine(Solution.IsMatch("", "*"));
    //    }
    }
}
