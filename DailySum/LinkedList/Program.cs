using System;

namespace LinkedList
{
    public class DLLNode
    {

        public int value;
        public int key;
        public DLLNode prev;
        public DLLNode next;

        public DLLNode(int key, int value)
        {
            this.value = value;
            this.prev = null;
            this.next = null;
            this.key = key;
        }

    }
    class Program
    {
        DLLNode head;
        DLLNode tail;

        //Program()
        //{
        //    this.head = null;
        //    this.tail = null
        //}
        void InsertLL(int value)
        {
            var node = new DLLNode(1, value);
            if (this.head == null)
            {
                this.head = node;
                this.tail = node;
            }
            else
            {
                this.head.next = node;
                node.prev = this.head;
                this.head = node;
            }
            PrintLL(this.tail);

        }

        void DeleteTail()
        {
            if (this.tail != null)
            {
                var node = this.tail;
                this.tail = node.next;
                if (this.tail != null)
                {
                    this.tail.prev = null;
                }

                node.next = null;
                node.prev = null;
            }

            PrintLL(this.tail);

        }

        DLLNode GetNode(int nodeValue)
        {
            DLLNode node = null;

            var temp = this.tail;
            while(temp != null)
            {
                if (temp.value == nodeValue)
                {
                    node = temp;
                    return node;
                }
                temp = temp.next;
            }
            return node;
        }

        void MoveToFront(int value)
        {
            var node = GetNode(value);

            if (node!=null && this.head != node)
            {
                if (node.prev != null)
                {
                    node.prev.next = node.next;
                    
                }
                else
                {
                    this.tail = node.next;
                }
                if (node.next != null)
                {
                    node.next.prev = node.prev;
                    this.head.next = node;
                    node.prev = this.head;
                    node.next = null;
                    this.head = node;
                }

            }

            Console.WriteLine("printing from tail");
            PrintLL(this.tail);
            Console.WriteLine("printing from head");
            PrintLL(this.head, false);
        }
        static void PrintLL(DLLNode head, bool fromTail = true)
        {
            var temp = head;
            while (temp != null)
            {
                Console.Write(temp.value + "-->");
                if (fromTail)
                {
                    temp = temp.next;
                }
                else
                {
                    temp = temp.prev;
                }

            }
            Console.WriteLine();
        }
        //}
        //static void Main(string[] args)
        //{

        //    var p = new Program();
        //    p.InsertLL(1);
        //    p.InsertLL(2);
        //    p.InsertLL(3);

        //    p.MoveToFront(1);

        //    p.MoveToFront(3);

        //    p.MoveToFront(3);

        //    //p.DeleteTail();
        //    //p.DeleteTail();
        //    //p.DeleteTail();
            
        //}
    }
}
