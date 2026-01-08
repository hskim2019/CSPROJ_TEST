int[] citations = { 3, 0, 6, 1, 5 };
var sol = new Solution();
Console.WriteLine(sol.solution(citations));

public class Solution
{
    public int solution(int[] citations)
    {
        var result = 0;
        for (var i = 0; i < citations.Length; i++)
        {
            var target = citations[i];
            var greaterCount = citations.Count(n => n >= target);
            if (greaterCount == target) result = target;
        }
        return result;
    }
}