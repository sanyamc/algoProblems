using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeBased
{
    public class Node
    {
        public int data;
        public Node next;
        public Node(int data, Node next =null)
        {
            this.data = data;
            this.next = next;
        }
    }

    public class LinkedList
    {
        public static void printNodes(Node start)
        {
            while(start!=null)
            {
                Console.Write(start.data+" -->");
                start = start.next;
            }
        }

        public static Node reverseNode(Node start)
        {
            Node current = start;
            Node previous = null;
            while(current!=null)
            {
                var next = current.next;
                current.next = previous;
                previous = current;
                current = next;
            }
            return previous;
        }

        public static Node SumTwo(Node first, Node second)
        {
            Node result = null;
            Node end = null;
            var r_first = LinkedList.reverseNode(first);
            var r_second = LinkedList.reverseNode(second);
            int carry = 0;

            while(r_first!=null && r_second!=null) {
                int digitSum = (r_first.data + r_second.data + carry) % 10;
                Node curr = new Node(digitSum, null);
                if (result == null)
                    result = curr;
                if (end != null)
                    end.next = curr;
                end = curr;
                carry = (r_first.data + r_second.data + carry) / 10;
                r_first = r_first.next;
                r_second = r_second.next;
            }

            var temp = r_first ?? r_second;

            while (temp !=null)
            {
                int digitSum = (temp.data + carry) % 10;
                carry = (temp.data + carry) / 10;
                Node curr = new Node(digitSum, null);
                if (result == null)
                    result = curr;
                if (end != null)
                    end.next = curr;
                end = curr;
                temp = temp.next;
            }

            if (carry != 0)
                end.next = new Node(carry, null);

            result = LinkedList.reverseNode(result);

            return result;
        }

        public static Node MergeSorted(Node first, Node second)
        {


            if (first == null && second == null)
            {
                return null;
        
    }

            if (first != null && second != null)
            {
                if (first.data < second.data)
                {
                    first.next = MergeSorted(first.next, second);
                    return first;
                }
                else
                {
                    second.next = MergeSorted(first, second.next);
                    return second;
                }
            }
            else
            {

                if (first == null)
                    return second;
                return first;

            }

        }

       
    }
}
