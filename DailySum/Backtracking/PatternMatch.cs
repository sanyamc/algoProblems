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


            return helper(s, 0, p, 0);

        }

        static int getNextIndex(string p, int current)
        {
            if (current >= p.Length)
                return current;
            int next = current + 1;

            while (next < p.Length)
            {
                if (p[next] == '*')
                {
                    current += 2;
                    next = current + 1;
                }
                else
                {
                    return current;
                }

            }
            return current;
        }

        static bool helper(string s, int s_index, string p, int p_index)
        {

            if (s_index >= s.Length || p_index >= p.Length)
            {
                p_index = getNextIndex(p, p_index);
                if (p_index >= p.Length)
                    return s_index >= s.Length && true;
                return false;
            }

            char curr = s[s_index];


            int next = p_index + 1;
            if (next < p.Length && p[next] == '*')
            {
                if (p[p_index] == '.' || curr == p[p_index])
                {
                    return (helper(s, s_index + 1, p, p_index + 2) ||
                         helper(s, s_index + 1, p, p_index)) ||
                         helper(s, s_index, p, p_index + 2);

                }

                else
                {
                    return helper(s, s_index, p, p_index + 2);
                }
            }
            else if (p[p_index] == '.')
            {
                return helper(s, s_index + 1, p, p_index + 1);
            }
            else
            {
                return s[s_index] == p[p_index] && helper(s, s_index + 1, p, p_index + 1);
            }


        }
    }


    



}

