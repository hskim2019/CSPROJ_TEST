// https://school.programmers.co.kr/learn/courses/30/lessons/42842

// 문제 설명
// Leo는 카펫을 사러 갔다가 아래 그림과 같이 중앙에는 노란색으로 칠해져 있고 테두리 1줄은 갈색으로 칠해져 있는 격자 모양 카펫을 봤습니다.

// carpet.png

// Leo는 집으로 돌아와서 아까 본 카펫의 노란색과 갈색으로 색칠된 격자의 개수는 기억했지만, 전체 카펫의 크기는 기억하지 못했습니다.

// Leo가 본 카펫에서 갈색 격자의 수 brown, 노란색 격자의 수 yellow가 매개변수로 주어질 때 카펫의 가로, 세로 크기를 순서대로 배열에 담아 return 하도록 solution 함수를 작성해주세요.

// 제한사항
// 갈색 격자의 수 brown은 8 이상 5,000 이하인 자연수입니다.
// 노란색 격자의 수 yellow는 1 이상 2,000,000 이하인 자연수입니다.
// 카펫의 가로 길이는 세로 길이와 같거나, 세로 길이보다 깁니다.

using System;

int brown = 10;
int yellow = 2;
// [4, 3]

// int brown = 8;
// int yellow = 1;
// [3, 3]

// int brown = 24;
// int yellow = 24;
// [8, 6]

var sol = new Solution();

int brown = 10;
int yellow = 2;

Console.WriteLine(string.Join(" , ", sol.solution(brown, yellow)));

public class Solution
{
    public int[] solution(int brown, int yellow)
    {
        int[] answer = new int[] { };
        // 카펫의 총 격자 수는 갈색과 노란색의 합입니다.
        int total = brown + yellow;
        // 가능한 가로와 세로의 조합을 찾기 위해 반복문을 사용합니다.
        for (int width = 3; width <= total; width++)
        {
            int height = total / width; // 세로 길이는 총 격자 수를 가로 길이로 나눈 값입니다.
            if (width * height == total && width >= height)
            { // 가로와 세로의 곱이 총 격자 수와 같고, 가로가 세로보다 크거나 같은 경우
                if ((width - 2) * (height - 2) == yellow)
                { // 내부 노란색 격자의 수가 주어진 yellow와 일치하는지 확인합니다.
                    answer = new int[] { width, height }; // 조건을 만족하는 경우 가로와 세로를 answer에 저장합니다.
                    break; // 조건을 만족하는 조합을 찾았으므로 반복문을 종료합니다.
                }
            }
        }
        return answer;
    }
}