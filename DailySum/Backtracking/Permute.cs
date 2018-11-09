using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backtracking
{
    public class Permute
    {

        public static void Permutation(IList<int> nums, int k)
        {
            IList<int> bitArray = new List<int>();
            foreach (var i in nums)
                bitArray.Add(0);

            Helper(nums, 0);
        }


        public static void Swap(IList<int> nums, int index1, int index2)
        {
            int temp = nums[index1];
            nums[index1] = nums[index2];
            nums[index2] = temp;
        }



        public static void Helper(IList<int> nums, int j)
        {

            if (j==nums.Count-1)
            {
                foreach (var v in nums)
                    Console.Write(v + ",");
                Console.WriteLine();

                return;
            }

            for (int i=0; i< nums.Count; i++)
            {
                Swap(nums, i, j);
                Helper(nums, j + 1);
                Swap(nums, i, j);

            }


        }


        public static void Main()
        {
            List<int> nums = new List<int> { 1, 3, 4 };//, 9, 2, 5 };
            Permutation(nums, 2);
        }
    }
}
