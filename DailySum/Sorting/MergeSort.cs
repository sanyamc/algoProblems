using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sorting
{
    public class Sorts
    {

        public static List<int> MergeSort(List<int> nums, int start, int end)
        {
            if (start >= end)
                return nums;

            var mid = (start + (end - start) / 2);

            MergeSort(nums, start, mid);
            MergeSort(nums, mid + 1, end);
            Merge(nums, start, mid + 1, end);
            return nums;

        }

        public static List<int> Merge(List<int> nums, int start1, int start2, int end)
        {

            List<int> temp1 = new List<int>();
            List<int> temp2 = new List<int>();

            for (var i= start1; i < start2 && i < nums.Count; i++)
			temp1.Add(nums[i]);

            temp1.Add(int.MaxValue);

            for (var j= start2; j <= end && j < nums.Count; j++)
			temp2.Add(nums[j]);

            temp2.Add(int.MaxValue);

            int temp1_index = 0, temp2_index = 0;

            for (int k = start1; k <= end; k++)
            {
                if (temp1[temp1_index] < temp2[temp2_index])
                {
                    nums[k] = temp1[temp1_index++];
                }
                else
                    nums[k] = temp2[temp2_index++];
            }

            return nums;
        }



	}
    [TestClass]
    public class MergeSortTest
    {
        [TestMethod]
        public void MergeSortBasic()
        {
            var m = new List<int> { 1, 100, 90, 40 };

            Sorts.MergeSort(m, 0, m.Count - 1);
            Assert.IsTrue(m[1] == 40);
            Assert.IsTrue(m[3] == 100);
        }

        [TestMethod]
        public void MergeSortBasic2()
        {
            var m = new List<int> { 1, 100, 90, 40, -99, 100, 1000, 34, 2 };

            Sorts.MergeSort(m, 0, m.Count - 1);
            Assert.IsTrue(m[0] == -99);
            Assert.IsTrue(m[8] == 1000);
        }
    }
}
