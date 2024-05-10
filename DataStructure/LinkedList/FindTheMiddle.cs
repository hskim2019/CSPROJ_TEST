using System;

namespace DotNet.DataStructure.LinkedList
{
    public class FindTheMiddle
    {
        static Node head {get; set;}

        // Link list node
        public class Node
        {
            public int data;
            public Node next;

            // Constructor
            public Node(Node next, int data) 
            {
                this.data = data;
                this.next = next;
            }
        }

        // Constructor
        public FindTheMiddle() 
        {
           
        }

        public void Test() 
        {
            Console.WriteLine("FindTheMiddle");

            for (int i = 5; i > 0; i--) {
                Push(head, i);
                printList(head);
                printMiddle(head);
                getMiddle(head);
            }           
        }

        // Function to get middle of the linked list
        void printMiddle(Node head) 
        {
            int count = 0;
            Node mid = head;

            while(head != null) 
            {
                //      0 1 2 3 4 5 6 7
                // head               v
                // mid          v
                // Update mid, when 'count' is odd num
                Console.WriteLine("count = " + count + " head.data = " + head.data + " ");
                if((count % 2) == 1) {
                    Console.Write("mid.data = " + mid.data);
                    mid = mid.next;
                    Console.Write(" mid.next.data = " + mid.data + "\n");
                }
                ++count;
                head = head.next;
            }
                // If eampty list is provied
            if(mid != null) {
                Console.WriteLine("the middle element is [" + mid.data + "]");
            }
        }

        void getMiddle(Node head)
        {
            Node temp = head;
            Node mid = head;
            if(head == null) 
            {
                Console.WriteLine("head is null");
            }
            
            while(mid != null && mid.next != null)
            {
                mid = mid.next.next;
                temp = temp.next;
            }

            Console.WriteLine("the middle element is [" + temp.data + "]");
        }

        public void Push(Node head_ref, int new_data) 
        {
            // Allocate node
            Node new_node = new Node(head_ref, new_data);
            
            // Move the head to point to the new node
            head = new_node;
        }

        // A utility function to print a given linked list
        void printList(Node head) 
        {
            while (head != null) 
            {
                Console.Write(head.data + "-> ");
                head = head.next;
                //Console.Write(" ( head.data ? " + head.data + " ) ");
            }
            Console.WriteLine("null");
        }
    }
}