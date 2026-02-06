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
using System.Reflection;

string numbers = "179";
var sol = new Solution();
Console.WriteLine(sol.solution(numbers));

public class Solution
{
    public int solution(string numbers)
    {
        string[] arr = numbers.Select(n => n.ToString()).ToArray();
        HashSet<int> hs = new HashSet<int>();
        int answer = 0;
        for (int i = 1; i <= arr.Length; i++)
        {
            GeneratePermutations(arr, i, "", new bool[arr.Length], hs);
        }
        //Console.WriteLine(string.Join(", ", hs));

        foreach (int num in hs)
        {
            if (IsPrime(num))
            {
                answer++;
            }
        }
        return answer;
    }

    public void GeneratePermutations(string[] arr, int targetLength, string current, bool[] used, HashSet<int> resultSet)
    {

        //Console.WriteLine("targetLength : " + targetLength.ToString() + " current : " + current);
        if (targetLength == current.Length)
        {
            resultSet.Add(int.Parse(current));
            return;
        }

        for (var i = 0; i < arr.Length; i++)
        {

            if (!used[i])
            {
                used[i] = true;
                GeneratePermutations(arr, targetLength, current + arr[i], used, resultSet);
                used[i] = false;
            }
        }
    }

    public bool IsPrime(int num)
    {

        if (num < 2)
        {
            return false;
        }
        if (num == 2)
        {
            return true;
        }
        var sqrt = (int)Math.Sqrt(num);
        for (var i = 2; i < sqrt + 1; i++)
        {
            if (num % i == 0)
            {
                return false;
            }
        }
        return true;
    }
}