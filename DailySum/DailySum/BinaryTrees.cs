using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySum
{
    public class Node
    {
        public int value;
        public Node left;
        public Node right;

        public Node(int value)
        {
            this.value = value;
        }
    }

    public class BinaryTree
    {


        private Node root;

        //public static void Main()
        //{

        //    Node root = new Node(1);

        //    root.left = new Node(2);
        //    root.right = new Node(3);

        //    root.left.left = new Node(4);
        //    root.right.left = new Node(5);

        //    var path = pathToNode(root, 4);
        //    path = pathToNode(root, 5);
        //    path = pathToNode(root, -1);

        //    string s = "1-2-3";
        //    s += "-4";
        //}

        public static List<int> pathToNode(Node root, int key, List<int> currentPath = null)
        {
            if (root == null)
                return null;

            if (currentPath == null)
                currentPath = new List<int>();

            if (root.value == key)
            {
                currentPath.Add(key);
                return currentPath;
            }
            currentPath.Add(root.value);
            var leftPath = pathToNode(root.left, key, currentPath);
            if (leftPath != null && leftPath[leftPath.Count - 1] == key)
                return currentPath;

            // iterate and remove value until you are at the root
            // other option is to use string as the path like value-value-value
            // that way we need not remove anything
            int index = currentPath.Count - 1;
            while(index>=0)
            {
                if (currentPath[index] == root.value)
                    break;
                else
                    currentPath.RemoveAt(index);

                index -= 1;
            }

            var rightPath = pathToNode(root.right, key, currentPath);
            if (rightPath != null && rightPath[rightPath.Count - 1] == key)
                return currentPath;
            return null;
        }
    }
}
