using System;

string numbers = "011";
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
        Console.WriteLine(string.Join(", ", hs));

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
        var sqrt = Math.Sqrt(num);
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