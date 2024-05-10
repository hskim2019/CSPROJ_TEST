namespace DotNet.DataStructure.LinkedList
{
    public class ExchangeCircularNodeTest
    {
        class Node {
            public int data;
            public Node next;
        };

        public ExchangeCircularNodeTest() 
        {

        }

        public void Test() 
        {
            int i;
            Node head = null;
            head = addToEmpty(head, 6);
            for(i = 5; i > 0; i--) {
                head = addBegin(head, i);
            }
            Console.Write("List Before: ");
            traverse(head);
            printList(head);
            Console.WriteLine();

            Console.Write("List After: ");
            head = exchangeNodes(head);
            traverse(head);
            printList(head);

            // Test2
            Console.WriteLine("[Test2]\n");
            Node head2 = newNode(6);
            head2.next = newNode(1);
            head2.next.next = newNode(2);
            head2.next.next.next = newNode(3);
            head2.next.next.next.next = newNode(4);
            head2.next.next.next.next.next = newNode(5);
            head2.next.next.next.next.next.next = head2;
            Console.Write("List2 Before: ");
            traverse(head2);
            printList(head2);
            head2 = exchangeNodes(head2);
            Console.Write("List2 After: ");
            traverse(head2);
            printList(head2);

            // Test3
            Console.WriteLine("[Test3]\n");
            Node head3 = null;
            head3 = addToEmpty(head3, 6);
            for(i = 5; i > 0; i--) {
                head3 = addBegin(head3, i);
            }
            Console.Write("List Before: ");
            traverse(head3);
            printList(head3);
            Console.WriteLine();

            Console.Write("List After: ");
            head3 = exchangeNodesValue(head3);
            traverse(head3);
            printList(head3);

            

        }
            
            
        static Node addToEmpty(Node head, int data) {
            // This function is only
            // for empty list
            if (head != null)
            return head;
            
            // Creating a node dynamically.
            Node temp = new Node();
            
            // Assigning the data.
            temp.data = data;
            head = temp;
            
            // Creating the link.
            head.next = head;
            
            return head;
        }

        static Node addBegin(Node head, int data)
        {
            if (head == null)
            return addToEmpty(head, data);
            
            Node temp = new Node();
            
            temp.data = data;
            temp.next = head.next;
            head.next = temp;
            
            return head;
        }
        
        // function for traversing the list
        static void traverse(Node head)
        {
            Node p;
            
            // If list is empty, return.
            if (head == null) {
                Console.Write("List is empty.");
                return;
            }
            
            // Pointing to first
            // Node of the list.
            p = head;
            
            // Traversing the list.
            do {
                Console.Write(p.data + " ");
                p = p.next;
                } while (p != head);
        }
        
        // Function to exchange first and last node
        // By changing links of First and Last Nodes
        static Node exchangeNodes(Node head)
        {
            
            // If list is of length 2
            if (head.next.next == head) {
                head = head.next;
                return head;
            }
                
            // Find pointer to previous
            // of last node
            Node p = head;
            while (p.next.next != head)
            p = p.next;
            
            // Exchange first and last
            // nodes using head and p
            p.next.next = head.next;
            head.next = p.next;
            p.next = head;
            head = head.next;
            
            // 6 1 2 3 4 5 (6)
            // h       p
            // p.next.next = head.next (현재 맨 끝에 위치한 5의 next 를 1로)
            // head.next = p.next (head의 다음 주소를 앞자리로 올 5로 (head 를 지정할 때 사용하기))
            // p.next = head; (현재 맨 끝의 prev 인 4의 next의 참조를 head로)
            // head = head.next; (이제 head 는 p.next 였던 6, )

            // (1) p 의 next 를 수정전의 head 로 연결
            //     p.next = head;
            // (2) head 는 수정전의 last 노드로 만든다
            //     head = p.next;
            // (3) 새로운 head.next 는 두번째 노드가 되어야 한다 = 기존 last 는 두번째 노드에 연결
            //     head.next = 기존 head.next;
            //   ->p.next.next = head.next;
            // (4) 새로운 last 의 next 는 새로운 head 로 연결
            //     새로운 p.next.next = 새로운 head;
            //    ->head.next = p.next;

            // (3) 을 먼저 수행 (head 참조가 바뀔 것이므로)
            // p.next.next = head.next;
            
            // (4) 를 수행하려면 기존 head가 바뀌기 전에 head.next 를 참조시켜줘야 한다
            // head.next = p.next;

            // (1) head 참조가 바뀔 것이므로 (2) 보다 먼저 수행
            // p.next = head;

            // 마지막으로 head 를 새롭게 정리
            // head = p.next; 

            return head;
        }

        // function to exchange first and last node
        // By swapping values of First and Last nodes
        static Node exchangeNodesValue(Node head) {

            // If list is of length less than 2
            if(head == null  || head.next == null) {
                return head;
            }

            Node tail = head;

            // Find pointer to the last node
            while (tail.next != head) {
                tail = tail.next;
            }

            /* Exchange first and last nodes using head and p */

            // Temporary variable to store head data
            int temp = tail.data;
            tail.data = head.data;
            head.data = temp;
            return head;

        }

        static Node newNode(int data)  
        {
            Node temp = new Node();  
            temp.data = data;
            temp.next = null;
            return temp;  
        } 

        void printList(Node head) {
            Console.WriteLine();
            Node node = head;
            do {
                Console.Write(node.data + "-> ");
                node = node.next;
            }
            while (node != null && node != head);
            Console.Write(node.data + "-> ");
            Console.WriteLine();
        }
    }
}