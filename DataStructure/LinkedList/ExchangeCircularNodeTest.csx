// 순환 노드 교환
// 순환 리스트에서 첫 번째 노드와 마지막 노드를 교환
// 링크 교환 방식 : 노드의 연결 구조를 바꿔서 첫 번째와 마지막 노드의 위치를 바꿈
// 값 교환 방식 : 노드의 위치는 그대로 두고, 데이터만 서로 바꿈

using System;

// 노드 정의
class Node
{
    public int data;
    public Node next;
}

// 빈 리스트에 노드 추가
Node addToEmpty(Node head, int data)
{
    if (head != null) return head;

    Node temp = new Node();
    temp.data = data;
    head = temp;
    head.next = head;
    return head;
}

// 리스트 앞에 노드 추가
Node addBegin(Node head, int data)
{
    if (head == null) return addToEmpty(head, data);

    Node temp = new Node();
    temp.data = data;
    temp.next = head.next;
    head.next = temp;
    return head;
}

// 리스트 순회 출력
void traverse(Node head)
{
    if (head == null)
    {
        Console.Write("List is empty.");
        return;
    }

    Node p = head;
    do
    {
        Console.Write(p.data + " ");
        p = p.next;
    } while (p != head);
    Console.WriteLine();
}

// 보기 좋게 출력
void printList(Node head)
{
    Console.WriteLine();
    Node node = head;
    do
    {
        Console.Write(node.data + "-> ");
        node = node.next;
    } while (node != null && node != head);
    Console.Write(node.data + "-> ");
    Console.WriteLine();
}

// 첫 번째와 마지막 노드 교환 (링크 변경 방식)
Node exchangeNodes(Node head)
{
    if (head.next.next == head)
    {
        head = head.next;
        return head;
    }

    Node p = head;
    while (p.next.next != head)
        p = p.next;

    p.next.next = head.next;
    head.next = p.next;
    p.next = head;
    head = head.next;

    return head;
}

// 첫 번째와 마지막 노드 교환 (값 변경 방식)
Node exchangeNodesValue(Node head)
{
    if (head == null || head.next == null) return head;

    Node tail = head;
    while (tail.next != head)
        tail = tail.next;

    int temp = tail.data;
    tail.data = head.data;
    head.data = temp;

    return head;
}

// 새 노드 생성
Node newNode(int data)
{
    Node temp = new Node();
    temp.data = data;
    temp.next = null;
    return temp;
}

// 테스트 실행
int i;
Node head = null;
head = addToEmpty(head, 6);
for (i = 5; i > 0; i--)
{
    head = addBegin(head, i);
}
Console.Write("List Before: ");
traverse(head);
printList(head);

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
for (i = 5; i > 0; i--)
{
    head3 = addBegin(head3, i);
}
Console.Write("List Before: ");
traverse(head3);
printList(head3);

Console.Write("List After: ");
head3 = exchangeNodesValue(head3);
traverse(head3);
printList(head3);