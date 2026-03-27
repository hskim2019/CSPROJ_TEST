// https://school.programmers.co.kr/learn/courses/30/lessons/42839

// 문제 설명
// 한자리 숫자가 적힌 종이 조각이 흩어져있습니다. 흩어진 종이 조각을 붙여 소수를 몇 개 만들 수 있는지 알아내려 합니다.

// 각 종이 조각에 적힌 숫자가 적힌 문자열 numbers가 주어졌을 때, 종이 조각으로 만들 수 있는 소수가 몇 개인지 return 하도록 solution 함수를 완성해주세요.

// 제한사항
// numbers는 길이 1 이상 7 이하인 문자열입니다.
// numbers는 0~9까지 숫자만으로 이루어져 있습니다.
// "013"은 0, 1, 3 숫자가 적힌 종이 조각이 흩어져있다는 의미입니다.

// 입출력 예
// string numbers = "17"; // 3
// string numbers = "011"; // 2

// 입출력 예 설명
// 예제 #1
// [1, 7]으로는 소수 [7, 17, 71]를 만들 수 있습니다.

// 예제 #2
// [0, 1, 1]으로는 소수 [11, 101]를 만들 수 있습니다.

// 11과 011은 같은 숫자로 취급합니다.

using System;
using System.Collections.Generic;


string numbers = "179";
var sol = new Solution();
Console.WriteLine(sol.solution(numbers));

public class Solution
{
    public int solution(string numbers)
    {
        var set = new HashSet<int>();
        var visited = new bool[numbers.Length];
        char[] arr = numbers.ToCharArray();

        // 모든 길이에 대해 순열 생성
        for (int len = 1; len <= numbers.Length; len++)
        {
            //DFS(numbers, "", len, visited, set);
            Permute(arr, len, set);

        }

        int count = 0;
        foreach (var num in set)
        {
            if (IsPrime(num)) count++;
        }

        return count;

    }

    // DFS로 숫자 조합 생성
    void DFS(string numbers, string current, int targetLen, bool[] visited, HashSet<int> set)
    {
        if (current.Length == targetLen)
        {
            set.Add(int.Parse(current));
            return;
        }

        for (int i = 0; i < numbers.Length; i++)
        {
            if (!visited[i])
            {
                visited[i] = true;
                DFS(numbers, current + numbers[i], targetLen, visited, set);
                visited[i] = false;
            }
        }
    }

    // 순열 생성 (재귀 없이)
    void Permute(char[] arr, int targetLen, HashSet<int> set)
    {
        bool[] visited = new bool[arr.Length];
        Stack<(string, bool[])> stack = new Stack<(string, bool[])>();
        stack.Push(("", visited));

        while (stack.Count > 0)
        {
            var (current, used) = stack.Pop();
            if (current.Length == targetLen)
            {
                set.Add(int.Parse(current));
                continue;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (!used[i])
                {
                    bool[] nextUsed = (bool[])used.Clone();
                    nextUsed[i] = true;
                    stack.Push((current + arr[i], nextUsed));
                }
            }
        }
        //         str
        // ""  : for문
        //      i = 0 / stack "1" { true, false, false} -> pop->stack "12" { true, true, false}, "13" { true,false, true}
        //         i = 1 / stack "2" { false, true, false}
        //         i = 2 / stack "3" { false, false, true}
    }


    // 소수 판별
    bool IsPrime(int num)
    {
        if (num < 2) return false;
        for (int i = 2; i * i <= num; i++)
        {
            if (num % i == 0) return false;
        }
        return true;
    }

}