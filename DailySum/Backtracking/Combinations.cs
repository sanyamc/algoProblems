using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backtracking
{
    public class Combinations
    {


        public static void FindCombination(IList<int> nums, int k)
        {
            if (nums.Count <= k)
                return; // or print it


            Helper(nums, k, 0, new List<int>());
        }


        public static void Helper(IList<int> nums, int k, int currentIndex, IList<int> result)
        {

            if (result.Count == k)
            {
                foreach(var i in result)
                    Console.Write(i+",");
                Console.WriteLine();
                return;
            }

            if (currentIndex >= nums.Count)
                return;
            result.Add(nums[currentIndex]);
            Helper(nums, k, currentIndex + 1, result);
            result.RemoveAt(result.Count - 1);
            Helper(nums, k, currentIndex + 1, result);
        }

        //public static void Main()
        //{
        //    List<int> nums = new List<int> { 1, 3, 4, 9, 2, 5 };

        //    Combinations.FindCombination(nums, 3);
        //}
    }
}
