// https://www.geeksforgeeks.org/problems/parenthesis-checker2744/1?itm_source=geeksforgeeks&itm_medium=article&itm_campaign=bottom_sticky_on_article
// 📌 이 코드는 괄호의 짝이 올바른지 확인하는 알고리즘입니다.
// 📌 괄호 검사 문제는 컴파일러, 수식 파서, HTML/XML 태그 검사 등에서 자주 사용됩니다.
// 📌 예: "([])" → 올바른 괄호 / "([)]" → 잘못된 괄호

using System;
using System.Collections.Generic;
using System.Linq;

// 검사할 문자열
string x = "[])";

// 스택을 이용해 괄호의 짝을 추적
Stack<char> s = new Stack<char>();

// 문자열을 문자 배열로 변환
char[] exp = x.ToCharArray();

// 여는 괄호와 닫는 괄호 정의
char[] startBrace = { '[', '{', '(' };
char[] endBrace = { ']', '}', ')' };

// 닫는 괄호 → 여는 괄호 매핑
Dictionary<char, char> dicBrace = new Dictionary<char, char>();
dicBrace.Add(']', '[');
dicBrace.Add('}', '{');
dicBrace.Add(')', '(');

// 결과를 저장할 변수
bool balanced = true;

// 문자열 순회하며 괄호 검사
foreach (char c in exp)
{
    // 여는 괄호일 경우 스택에 푸시
    if (startBrace.Contains(c))
    {
        s.Push(c);
    }

    // 닫는 괄호일 경우
    if (endBrace.Contains(c))
    {
        if (s.Count > 0)
        {
            // 스택의 top이 짝이 맞는 여는 괄호면 pop
            if (s.Peek() == dicBrace[c])
            {
                s.Pop();
            }
            else
            {
                // 짝이 안 맞으면 오류로 간주하고 푸시
                s.Push(c);
            }
        }
        else
        {
            // 스택이 비어있으면 오류
            s.Push(c);
        }
    }
}

// 스택에 남은 괄호가 있으면 짝이 맞지 않음
if (s.Count > 0)
{
    balanced = false;
}

// 결과 출력
Console.WriteLine($"result : {balanced}");