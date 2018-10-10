using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySum
{
    public class BinarySearch
    {

        public static void Main()
        {
            // find an element just greater than key in BST

            // assumptions
            // 1. Array is sorted
            int[] input = { 1, 3, 9, 9, 9, 10, 30, 300, 900 };
            Console.WriteLine(JustGreater(input, 9)); // expects 10
            Console.WriteLine(JustGreater(input, -1)); // expects 1
            Console.WriteLine(JustGreater(input, 950)); // expects null


        }

        // Below is actual binay search but it is modified ONLY in returning Just value
        // Remaining is same as regular BS
        // Learnings are as follows
        // Make sure that calculation of mid and then setting start and end DON'T run an infinite loop
        // Remember that int division is a floor so ALWAY INCREASE + 1 or DECREASE -1 from mid to 
        // reset start and end
        // Other Learning is around returning NULL from a function which returns an int
        public static int? JustGreater(int[] input, int key)
        {
            if (input.Length == 0)
                return null;
            int? just = null;

            int start = 0, end = input.Length - 1;
            if (key >= input[end])
                return null;

            while (start <= end)
            {
                int mid = (start + (end - start) / 2);
                //if (key == input[mid])
                //{
                //    if (mid < end)
                //        return input[mid + 1];
                //    return null;

                //}
                if (key < input[mid])
                {
                    end = mid -1;
                    just = input[mid];
                }
                if (key >= input[mid])
                {
                    start = mid +1;
                }
            }
            return just;


        }
    }
    }
