using System;

string word = "I";
var sol = new Solution();
Console.WriteLine(sol.solution(word));
public class Solution
{
    public int solution(string word)
    {
        int answer = 0;
        var weight = new int[5];
        weight[0] = 1;
        for (int i = 1; i < 5; i++)
        {
            weight[i] = weight[i - 1] + (int)Math.Pow(5, i);
        }
        Console.WriteLine(string.Join(", ", weight));

        return answer;
    }
}