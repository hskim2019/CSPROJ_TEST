//https://www.geeksforgeeks.org/problems/evaluation-of-postfix-expression1735/1?itm_source=geeksforgeeks&itm_medium=article&itm_campaign=bottom_sticky_on_article

// 📌 이 코드는 후위 표기법(Postfix Expression)을 평가하는 알고리즘입니다.
// 📌 후위 표기법은 연산자 우선순위나 괄호 없이도 수식을 계산할 수 있는 방식입니다.
// 📌 예: "231*+9-" → ((2 + (3 * 1)) - 9) = -4
// 📌 이 코드는 알고리즘 문제 풀이, 스택 자료구조 학습, 또는 계산기 구현 등에 활용됩니다.

// 필요한 네임스페이스 참조
using System;
using System.Collections.Generic;

// 후위 표기 수식
string S = "231*+9-";

// 정수형 스택 생성
Stack<int> s = new Stack<int>();

// 수식 문자열을 한 글자씩 순회
for (var i = 0; i < S.Length; i++)
{
    // 숫자일 경우 스택에 푸시
    if (char.IsDigit(S[i]))
    {
        int tempNum = S[i] - '0'; // 문자 → 숫자 변환
        s.Push(tempNum);
    }
    else
    {
        // 연산자일 경우 두 숫자를 꺼내서 계산
        int num1 = s.Pop();
        int num2 = s.Pop();

        // 연산자에 따라 계산 후 결과를 다시 스택에 푸시
        if (S[i] == '+')
        {
            s.Push(num2 + num1);
            Console.WriteLine("+");
        }
        else if (S[i] == '-')
        {
            s.Push(num2 - num1);
            Console.WriteLine("-");
        }
        else if (S[i] == '*')
        {
            s.Push(num2 * num1);
            Console.WriteLine("*");
        }
        else if (S[i] == '/')
        {
            s.Push(num2 / num1);
            Console.WriteLine("/");
        }
    }
}

// 최종 결과 출력
var returnVal = s.Pop();
Console.WriteLine($"Result: {returnVal}");