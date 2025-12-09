using System;
using System.Linq;

var sol = new Solution();
int[] array = { 3, 30, 34, 5, 9 };
Console.Write(sol.solution(array));

public class Solution
{
    public string solution(int[] array)
    {
        string answer;
        var stringNum = array.Select(n => n.ToString()).ToArray();
        Array.Sort(stringNum, (a, b) => (b + a).CompareTo((a + b)));
        answer = String.Join("", stringNum);
        return answer;
    }
}