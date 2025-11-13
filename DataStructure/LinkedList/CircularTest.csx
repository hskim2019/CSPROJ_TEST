// 순환 연결 리스트가 사용되는 경우
// 각 작업을 순서대로 반복적으로 처리해야 할 때 유용
// 무한 반복이 필요한 UI 요소
// 삽입/삭제가 간편

using System;

// 노드 정의
class Node
{
    public int data;
    public Node next;
}

// 노드 생성 함수
Node NewNode(int data)
{
    return new Node { data = data, next = null };
}

// 원형 연결 리스트 여부 확인
bool IsCircular(Node head)
{
    if (head == null) return true;

    Console.WriteLine("node.data(head) : " + head.data);

    Node node = head.next;
    if (node != null)
        Console.WriteLine("node.data : " + node.data);

    while (node != null && node != head)
    {
        node = node.next;
        if (node != null)
            Console.WriteLine("while...node.data : " + node.data);
    }

    return node == head;
}

// 연결 리스트 역순 출력
void PrintReverse(Node head, int index)
{
    if (head == null) return;

    PrintReverse(head.next, index + 1);
    Console.Write(head.data + " ");
}

// 테스트 실행
Node head = NewNode(1);
head.next = NewNode(2);
head.next.next = NewNode(3);
head.next.next.next = NewNode(4);

Console.WriteLine(IsCircular(head) ? "Yes" : "No");

// 원형 연결 리스트로 변경
// head.next.next.next.next = head;

// Console.WriteLine(IsCircular(head) ? "Yes" : "No");

PrintReverse(head, 0);