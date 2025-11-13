// 단일 연결 리스트 + 중간 노드 탐색
// 전체 길이를 모르거나 동적으로 추가되는 데이터에서 중간값을 실시간으로 추적할 때
// 연결리스트의 중간 노드 찾기
// 배열보다 메모리 재할당이 유연하고 삽입/삭제가 빠름
// 스택/큐 기반 알고리즘 구현

using System;

// 노드 정의
class Node
{
    public int data;
    public Node next;

    public Node(Node next, int data)
    {
        this.data = data;
        this.next = next;
    }
}

// 전역 head
Node head = null;

// 노드 추가
void Push(int new_data)
{
    Node new_node = new Node(head, new_data);
    head = new_node;
}

// 리스트 출력
void printList(Node node)
{
    while (node != null)
    {
        Console.Write(node.data + "-> ");
        node = node.next;
    }
    Console.WriteLine("null");
}

// 중간 노드 출력 (카운트 기반)
void printMiddle(Node node)
{
    int count = 0;
    Node mid = node;

    while (node != null)
    {
        Console.WriteLine($"count = {count}, head.data = {node.data}");
        if (count % 2 == 1)
        {
            Console.Write($"mid.data = {mid.data}");
            mid = mid.next;
            Console.WriteLine($" mid.next.data = {mid?.data}");
        }
        count++;
        node = node.next;
    }

    if (mid != null)
        Console.WriteLine($"The middle element is [{mid.data}]");
}

// 중간 노드 출력 (빠른/느린 포인터 방식)
void getMiddle(Node node)
{
    Node slow = node;
    Node fast = node;

    if (node == null)
    {
        Console.WriteLine("head is null");
        return;
    }

    while (fast != null && fast.next != null)
    {
        fast = fast.next.next;
        slow = slow.next;
    }

    Console.WriteLine($"The middle element is [{slow.data}]");
}

// 테스트 실행
Console.WriteLine("FindTheMiddle");
for (int i = 5; i > 0; i--)
{
    Push(i);
    printList(head);
    printMiddle(head);
    getMiddle(head);
    Console.WriteLine();
}