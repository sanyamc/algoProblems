using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    class MinWindow
    {


        /*
        Input: S = "ADOBECODEBANC", T = "ABC"
        Output: "BANC"
        */

        // conver T to a set
        // create a dict with index 
        // find a set
        // then try to minimize it

        public static int GetMinKey(Dictionary<char, int> map)
        {
            int min = int.MaxValue;
            foreach (var k in map.Keys)
            {
                if (map[k] < min)
                    min = map[k];
            }
            return min;
        }

        public static string MinimumWindowSubstring(string str, string T)
        {

            int start = -1, end = 0;
            //var set = new HashSet<char>();
            var map = new Dictionary<char, int>();
            string result = "";
            //foreach (var c in T)
            //{
            //    set.Add(c);
            //}

            while (end <= str.Length)
            {
                char current = str.ElementAt(end);
                if (T.Contains(current))
                {
                    if (start == -1)
                        start = end;
                    if (map.ContainsKey(current))
                        map[current] = end;
                    else
                        map.Add(current, end);
                }
                if (map.Count == T.Length)
                    break;
                end++;
            }

            if (start == -1)
                return "";
            result = str.substring(start, end - start + 1);

            // minimize
            while (end < str.Length)
            {
                if (str[end] == str[start])
                {
                    map[str[end]] = end;
                    start = GetMinKey(map);
                    string temp = str.Substring(start, end - start + 1);
                    if result.length > temp.length
        
                result = temp;
                }
                end++;
            }
            return result;

        }



    }
}
