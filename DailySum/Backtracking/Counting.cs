using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backtracking
{
    class Counting
    {
        // Subsets
        // test cases at: https://leetcode.com/problems/subsets/
        // interesting things to note:
        // converting IList<IList<int>> to List<List<int>>
        // do that by IList<IList<int>> = new List<IList<int>>();
        public static IList<IList<int>> Result;
        public IList<IList<int>> Subsets(int[] nums)
        {
            Result = new List<IList<int>>();
            helper(nums, 0, 0);
            return Result;
        }

        public static bool On(int mask, int position)
        {

            return (mask & (1 << position)) >= 1;

        }

        public static int Set(int mask, int position)
        {

            return (mask | (1 << position));
        }

        public void helper(int[] nums, int mask, int index)
        {

            if (index >= nums.Length)
            {
                var list = new List<int>();
                for (int k = 0; k < nums.Length; k++)
                {

                    if (Counting.On(mask, k))
                    {
                        list.Add(nums[k]);
                    }
                }
                Result.Add(list);
                return;
            }

            helper(nums, Counting.Set(mask, index), index + 1);
            helper(nums, mask, index + 1);
        }
    }
}
