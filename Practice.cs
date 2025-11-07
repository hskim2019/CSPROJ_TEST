

var sol = new Solution();
string[,] testCase = new string[,]
{
    {"hat", "headgear"},
    {"sunglass", "eyewear"}
};
Console.WriteLine(sol.solution(testCase));

public class Solution
{
    public int solution(string[,] clothes)
    {
        int answer = 1;
        Dictionary<string, int> clotheCnt = new Dictionary<string, int>();
        for (int i = 0; i < clothes.GetLength(0); i++)
        {
            string type = clothes[i, 1];
            if (clotheCnt.ContainsKey(clothes[i, 1]))
            {
                clotheCnt[clothes[i, 1]]++;
            }
            else
            {
                clotheCnt[clothes[i, 1]] = 1;
            }
        }
        foreach (int count in clotheCnt.Values)
        {
            answer *= (count + 1);
        }
        answer--;
        return answer;
    }
}