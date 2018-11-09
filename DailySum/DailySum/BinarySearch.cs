﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySum
{
    public class BinarySearch
    {

        //public static void Main()
        //{
        //    // find an element just greater than key in BST


        //    /*
        //     * Iterative Binary Search
        //     */

        //    // 
        //    int[] input = { 1, 3, 10, 30, 30, 30, 30, 30, 300, 900, 900, 900 };
        //    Console.WriteLine(IterativeBinarySearch(input, 10)); // expects true
        //    Console.WriteLine(IterativeBinarySearch(input, -1)); // expects false

        //    /*
        //     *  Recursive Binary Search
        //     */
        //    Console.WriteLine(RecursiveBinarySearch(input, 0, input.Length - 1, 10)); // expects true
        //    Console.WriteLine(RecursiveBinarySearch(input, 0, input.Length - 1, -1)); // expects false

        //    /*
        //     *  First occurence in binary search
        //     * 
        //     */
        //    Console.WriteLine("first occurence at: " + FirstOccurenceOfTarget(input, 30));

        //    Console.WriteLine("first occurence at: " + FirstOccurenceOfTarget(input, 900));

        //    Console.WriteLine(JustGreater(input, 950)); // expects null
        //                                                //    assumptions
        //                                                //1.Array is sorted
        //                                                // input = { 1, 3, 9, 9, 9, 10, 30, 300, 900 };
        //    Console.WriteLine(JustGreater(input, 9)); // expects 10
        //    Console.WriteLine(JustGreater(input, -1)); // expects 1
        //    Console.WriteLine(JustGreater(input, 950)); // expects null

        //}

        public static bool RecursiveBinarySearch(int[] SortedArray, int start, int end, int target)
        {
            if (start > end)
                return false;
            int mid = start + (end - start) / 2;
            int val = SortedArray.ElementAt(mid);
            if (val == target)
                return true;
            if (val < target)
                return RecursiveBinarySearch(SortedArray, start, mid - 1, target);
            return RecursiveBinarySearch(SortedArray, mid + 1, end, target);
        }


        public static bool IterativeBinarySearch(int[] SortedArray, int toFind)
        {
            int start = 0, end = SortedArray.Length - 1;

            while (start <= end)
            {
                int mid = start + (end - start) / 2;
                if (SortedArray.ElementAt(mid) == toFind)
                    return true;
                if (SortedArray.ElementAt(mid) < toFind)
                    end = mid - 1;
                else
                    start = mid + 1;
            }

            return false;
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
                    end = mid - 1;
                    just = input[mid];
                }
                if (key >= input[mid])
                {
                    start = mid + 1;
                }
            }
            return just;
        }



        //    find first occurence of binary search
        //-- iterative will take O(n)

        //target is to find index of just less than target then return 
        // OR modify binary search to NOt stop when element is found but instead keep going in one direction
        // TODO: find for last element

        public static int JustLessThanTarget(int[] SortedArray, int start, int end, int target, int currentIndex)
        {
            if (start > end)
                return currentIndex;
            int mid = start + (end - start) / 2;
            int val = SortedArray.ElementAt(mid);

            if (val < target)
            {
                currentIndex = mid;
                return JustLessThanTarget(SortedArray, mid+1, end, target, currentIndex);
            }
            else
            {
                return JustLessThanTarget(SortedArray, start, mid-1, target, currentIndex);
            }

        }

        public static int FirstOccurenceOfTarget(int[] SortedArray, int target)
        {
            int index = JustLessThanTarget(SortedArray, 0, SortedArray.Length - 1, target, -1);
            if (index != -1 && index < SortedArray.Length)
                return index + 1;
            return -1;
        }
    }


}
