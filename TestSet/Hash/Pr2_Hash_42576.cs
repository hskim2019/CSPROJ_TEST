// https://school.programmers.co.kr/learn/courses/30/lessons/42576



string[] participant = { "leo", "kiki", "eden" };
string[] completion = { "eden", "kiki" };
// 정답: "leo"

var sol = new Solution();
Console.WriteLine(sol.solution(participant, completion));
public class Solution
{
    public string solution(string[] participant, string[] completion)
    {
        var dict = new Dictionary<string, int>();

        // 참가자 카운트
        foreach (var part in participant)
        {
            if (dict.ContainsKey(part))
                dict[part]++;
            else
                dict[part] = 1;
        }

        // 완주자 카운트 감소
        foreach (var comp in completion)
        {
            dict[comp]--;
        }

        // 남은 카운트가 0보다 큰 이름이 정답
        return dict.First(x => x.Value > 0).Key;
    }
}
