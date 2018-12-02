using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeBased
{
    public class TreeNode
    {
        public int value;
        public TreeNode left;
        public TreeNode right;
    }
    class BinaryTrees
    {
        // test cases at: https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/submissions/
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {

            if (root == null)
                return root;

            if (root.value == p.value || root.value == q.value)
                return root;

            TreeNode left = LowestCommonAncestor(root.left, p, q);
            TreeNode right = LowestCommonAncestor(root.right, p, q);

            if (left != null && right != null)
                return root;

            else if (left == null)
                return right;
            return left;
        }

    }
}
