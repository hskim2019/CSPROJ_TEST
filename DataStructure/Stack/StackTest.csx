// 📌 이 코드는 배열 기반의 스택 자료구조를 직접 구현한 예제입니다.
// 📌 스택은 후입선출(LIFO) 구조로, 컴퓨터 과학에서 함수 호출, undo 기능, 괄호 검사 등 다양한 곳에 활용됩니다.
// 📌 이 구현은 고정 크기의 배열을 사용하며, push/pop/peek/print 기능을 제공합니다.

using System;

// 스택 클래스 정의
class StackTest
{
    private int[] ele; // 스택 요소를 저장할 배열
    private int top;   // 현재 스택의 top 인덱스
    private int max;   // 스택의 최대 크기

    // 생성자: 스택 초기화
    public StackTest(int size)
    {
        ele = new int[size];
        top = -1;
        max = size;
    }

    // 스택에 요소 추가
    public void push(int item)
    {
        if (top == max - 1)
        {
            Console.WriteLine("Stack Overflow"); // 스택이 가득 찼을 때
            return;
        }
        else
        {
            ele[++top] = item;
            Console.WriteLine("top after Push(): " + top);
        }
    }

    // 스택에서 요소 제거 및 반환
    public int pop()
    {
        if (top == -1)
        {
            Console.WriteLine("Stack is Empty"); // 스택이 비었을 때
            return -1;
        }
        else
        {
            Console.WriteLine($"{ele[top]} popped from stack");
            var testValue = ele[top--];
            Console.WriteLine("top after Pop(): " + top);
            return testValue;
        }
    }

    // 스택의 top 요소 확인 (제거하지 않음)
    public int peek()
    {
        if (top == -1)
        {
            Console.WriteLine("Stack is Empty");
            return -1;
        }
        else
        {
            Console.WriteLine($"{ele[top]} peeked from stack");
            return ele[top];
        }
    }

    // 스택의 모든 요소 출력
    public void printStack()
    {
        if (top == -1)
        {
            Console.WriteLine("Stack is Empty");
            return;
        }
        else
        {
            for (int i = 0; i <= top; i++)
            {
                Console.WriteLine($"{ele[i]} pushed into stack");
            }
        }
    }
}

// 테스트 실행
var p = new StackTest(5);

p.push(10);
p.push(20);
p.push(30);

p.printStack();

var test = p.pop();
Console.WriteLine("last : " + test);