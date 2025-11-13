
using System.Collections.Generic;

var sol = new Solution();
var testCase = new string[,]
{
    {"hat", "headgear"},
{"sunglass", "eyewear"}
};
Console.WriteLine(sol.solution(testCase));

public class Solution
{
    public int solution(string[,] clohtes)
    {
        int answer = 1;
        Dictionary<string, int> clohtesCnt = new Dictionary<string, int>();
        for (int i = 0; i < clohtes.GetLength(0); i++)
        {
            string type = clohtes[i, 1];
            if (clohtesCnt.ContainsKey(type))
            {
                clohtesCnt[type]++;
            }
            else
            {
                clohtesCnt[type] = 2;
            }
        }
        foreach (int count in clohtesCnt.Values)
        {
            answer *= (count + 1);
        }
        answer--;
        return answer;
    }
}