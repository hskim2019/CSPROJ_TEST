using System;
using System;
using System.Collections.Generic;

string[] participant = { "leo", "kiki", "eden" };
string[] completion = { "eden", "kiki" };
// [4, 1, 3, 0]
var sol = new Solution();
Console.WriteLine(sol.solution(participant, completion));
public class Solution
{

    public string solution(string[] participant, string[] completion)
    {
        var dict = new Dictionary<string, int>();
        for (var i = 0; i < participant.Length; i++)
        {
            if (!dict.ContainsKey(participant[i]))
            {
                dict[participant[i]] = 1;
            }
            else
            {
                dict[participant[i]]++;
            }
        }
        foreach (var c in completion)
        {
            dict[c]--;
        }
        return dict.FirstOrDefault().Key;
    }
}
