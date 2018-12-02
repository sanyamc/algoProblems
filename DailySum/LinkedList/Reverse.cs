using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{



    // Definition for singly-linked list.
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class Solution
    {
        public ListNode ReverseBetween(ListNode head, int m, int n)
        {

            if (head == null)
                return null;

            ListNode startNode = head;
            var temp = head;
            for (int i = 1; i < (m - 1); i++)
            {
                startNode = startNode.next;
                temp = temp.next;
            }

            if (m == 1)
            {
                Reverse(ref startNode, startNode, startNode, n, m);
                return startNode;

            }
            else
            {
                Reverse(ref startNode, startNode.next, startNode.next, n, m);
                temp.next = startNode;
                return head;
            }
        }


        public static ListNode Reverse(ref ListNode head, ListNode tail, ListNode current, int target, int currIndex)
        {



            if (currIndex == target)
            {

                tail.next = current.next;
                head = current;
                return current;
            }

            else
            {

                var t = Reverse(ref head, tail, current.next, target, currIndex + 1);
                t.next = current;
                return current;
            }
        }

        public static void Main()
        {
            var head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);
            head.next.next.next.next = new ListNode(5);

            var l = new Solution();
            l.ReverseBetween(head, 2, 4);

            
        }
    }
}
