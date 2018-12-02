using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeBased
{

    public class BST
    {
        public TreeNode Predecessor(TreeNode root)
        {
            if (root == null)
                return root;

            var pred = root.left;
            var parent = pred;
            while(pred!=null)
            {
                parent = pred;
                pred = pred.right;
            }
            return parent;
        }

        public TreeNode Successor(TreeNode root)
        {
            return root;
        }

        //public TreeNode BSTDelete(TreeNode toDelete)
        //{
        //    if (toDelete.left == null)
        //    {
        //        // toDelete.parent.left/right = toDelete.right;
        //    }
        //    if (toDelete.right == null)
        //    {
        //        // toDelete.parent.left/right  = toDelete.left;
        //    }

        //    TreeNode pred = this.Predecessor(toDelete);
        //    // first delete pred
        //    this.BSTDelete(pred);
        //    // toDelete.parent/left or right == pred;
        //    // pred.

        //}
    }
}
