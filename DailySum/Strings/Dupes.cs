using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    public class Dupes
    {
        public static char firstNonRepeatingChar(string Original)
        {
            var map = new Dictionary<char, double>();
            double min =  double.PositiveInfinity;
            char minChar = ' ';
            for (int i = 0; i < Original.Length; i++)
            {
                //Original[i] = 't';
                var current = Original.ElementAt(i);
                if (current == ' ')
                    continue;

                if (map.ContainsKey(current))
                {
                    map[current] = -1;
                }
                else
                {
                    map[current] = i;
                }
            }
	        foreach(var k in map.Keys)
                 {
                     if (map[k] != -1 && min > map[k])
                    {
                     min = map[k];
                        minChar = k;
                    }
            }
            return minChar;
        }

        // remove duplicates from a given string
        // remove duplicates from a given string

        public static string RemoveDupes(string original)
        {
            var d = new Dictionary<char, int>();
            var sb = new StringBuilder();
            for (var i = 0; i < original.Length; i++)
            {
                var c = original.ElementAt(i);
                if (d.ContainsKey(c))
                    continue;
                else
                {
                    if(c!=' ')
                        d[c] = i;
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }


        //public static void Main()
        //{
        //    Console.WriteLine(Dupes.RemoveDupes("this is a test"));
        //    Console.WriteLine(Dupes.RemoveDupes("   a tests"));

        //    //Console.Wr

        //}
    }
}
