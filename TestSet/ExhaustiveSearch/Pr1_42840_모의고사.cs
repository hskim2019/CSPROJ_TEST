// https://school.programmers.co.kr/learn/courses/30/lessons/42840

// 문제 설명
// 수포자는 수학을 포기한 사람의 준말입니다. 수포자 삼인방은 모의고사에 수학 문제를 전부 찍으려 합니다. 수포자는 1번 문제부터 마지막 문제까지 다음과 같이 찍습니다.

// 1번 수포자가 찍는 방식: 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, ...
// 2번 수포자가 찍는 방식: 2, 1, 2, 3, 2, 4, 2, 5, 2, 1, 2, 3, 2, 4, 2, 5, ...
// 3번 수포자가 찍는 방식: 3, 3, 1, 1, 2, 2, 4, 4, 5, 5, 3, 3, 1, 1, 2, 2, 4, 4, 5, 5, ...

// 1번 문제부터 마지막 문제까지의 정답이 순서대로 들은 배열 answers가 주어졌을 때, 가장 많은 문제를 맞힌 사람이 누구인지 배열에 담아 return 하도록 solution 함수를 작성해주세요.

// 제한 조건
// 시험은 최대 10,000 문제로 구성되어있습니다.
// 문제의 정답은 1, 2, 3, 4, 5중 하나입니다.
// 가장 높은 점수를 받은 사람이 여럿일 경우, return하는 값을 오름차순 정렬해주세요.
// 입출력 예
// answers	return
// [1,2,3,4,5]	[1]
// [1,3,2,4,2]	[1,2,3]
// 입출력 예 설명
// 입출력 예 #1

// 수포자 1은 모든 문제를 맞혔습니다.
// 수포자 2는 모든 문제를 틀렸습니다.
// 수포자 3은 모든 문제를 틀렸습니다.
// 따라서 가장 문제를 많이 맞힌 사람은 수포자 1입니다.

// 입출력 예 #2

// 모든 사람이 2문제씩을 맞췄습니다.
using System;
using System.Collections.Generic;
using System.Linq;

int[] answers = { 1, 3, 2, 4, 2 };
var sol = new Solution();
Console.WriteLine(string.Join(", ", sol.solution(answers)));

public class Solution
{
    public int[] solution(int[] answers)
    {
        // 수포자들의 찍는 패턴
        int[] first = { 1, 2, 3, 4, 5 };
        int[] second = { 2, 1, 2, 3, 2, 4, 2, 5 };
        int[] third = { 3, 3, 1, 1, 2, 2, 4, 4, 5, 5 };

        // 맞춘 개수 카운트
        int[] scores = new int[3];

        for (int i = 0; i < answers.Length; i++)
        {
            if (answers[i] == first[i % first.Length]) scores[0]++;
            if (answers[i] == second[i % second.Length]) scores[1]++;
            if (answers[i] == third[i % third.Length]) scores[2]++;
        }

        // 최고 점수
        int maxScore = scores.Max();

        // 최고 점수를 받은 사람들 반환 (오름차순)
        List<int> result = new List<int>();
        for (int i = 0; i < scores.Length; i++)
        {
            if (scores[i] == maxScore)
                result.Add(i + 1); // 사람 번호는 1부터 시작
        }

        return result.ToArray();
    }
}