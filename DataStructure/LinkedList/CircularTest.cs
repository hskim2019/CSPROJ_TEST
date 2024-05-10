using System.Reflection.Metadata.Ecma335;
using System;

namespace DotNet.DataStructure.LinkedList
{
    public class CircularTest
    {
        static Node head {get; set;}


        public class Node {
            public int data;
            public Node next;
        }

        public CircularTest() {

        }

        public void Test() {
            /* Start with the empty list */
            Node head = newNode(1);
            head.next = newNode(2);
            head.next.next = newNode(3);
            head.next.next.next = newNode(4);
            Console.Write(isCircular(head)? "Yes\n" : "No\n" );
            
            // Making linked list circular
            //head.next.next.next.next = head;
            
            Console.Write(isCircular(head)? "Yes\n" : "No\n" );  

            printReverse(head, 0);

        }

        static Node newNode(int data)  
        {
            Node temp = new Node();  
            temp.data = data;
            temp.next = null;
            return temp;  
        } 

        bool isCircular( Node head)  
        {
            // An empty linked list is circular
            if (head == null)  
            return true;
            Console.WriteLine("node.data(head) : " + head.data);
            // Next of head
            Node node = head.next;
            Console.WriteLine("node.data : " + node.data);

            // This loop would stop in both cases 
            // (1) If Circular (2) Not circular
            while (node != null && node != head) {
                node = node.next;
                if(node != null) {
                    Console.WriteLine("while...node.data : " + node.data);
                }
            }
            
            // If loop stopped because of circular condition
            return (node == head);  
        }

        static void printReverse(Node head, int index) {
            if(head == null) {
                return;
            }

            //Console.WriteLine("[1] index : " + index + " head.data = " + head.data);
            printReverse(head.next, index+1);

            //Console.WriteLine("[2] index : " + index + " head.data = " + head.data);
            Console.Write(head.data + " ");
        }
    }
}