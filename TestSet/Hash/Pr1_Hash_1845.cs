// https://school.programmers.co.kr/learn/courses/30/lessons/1845

using System;
using System.Collections.Generic;

var sol = new Solution();
int[] nums = new int[] { 3, 1, 2, 3 };
Console.WriteLine(sol.solution(nums));

public class Solution
{
    public int solution(int[] nums)
    {
        HashSet<int> unique = new HashSet<int>(nums);
        int share = nums.Length / 2;
        return Math.Min(unique.Count, share);
    }
}