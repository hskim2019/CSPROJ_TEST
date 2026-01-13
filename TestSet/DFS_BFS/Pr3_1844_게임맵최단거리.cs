// https://school.programmers.co.kr/learn/courses/30/lessons/1844?language=csharp


/*
[프로그래머스] 게임 맵 최단거리
- 5x5 크기 맵에서, 당신은 (1,1) 위치(좌상단)에 있고 상대팀은 (5,5) 위치(우하단)에 있음.
- maps는 n x m 크기의 2차원 배열로 맵 상태를 나타냄.
- maps는 0과 1로 이루어져 있음:
    * 0 → 벽, 지나갈 수 없음
    * 1 → 길, 지나갈 수 있음
- 이동 규칙:
    * 상, 하, 좌, 우로 한 칸씩만 이동 가능
    * 맵 밖으로는 이동 불가
- 목표:
    * (1,1)에서 (n,m)까지 최단 경로로 이동할 때 지나간 칸 수(시작 칸 포함)를 반환
    * 도달 불가능하면 -1 반환
- 제한사항:
    * 1 ≤ n,m ≤ 100
*/


// 결과: 11
var maps1 = new int[][]
{
    new int[] {1, 0, 1, 1, 1},
    new int[] {1, 0, 1, 0, 1},
    new int[] {1, 0, 1, 1, 1},
    new int[] {1, 1, 1, 0, 1},
    new int[] {0, 0, 0, 0, 1}
};

// 결과: -1
var maps2 = new int[][]
{
    new int[] {1, 0, 1, 1, 1},
    new int[] {1, 0, 1, 0, 1},
    new int[] {1, 0, 1, 1, 1},
    new int[] {1, 1, 1, 0, 0},
    new int[] {0, 0, 0, 0, 1}
};

// 호출
var sol = new Solution();
Console.WriteLine(sol.solution(maps1)); // 11
Console.WriteLine(sol.solution(maps2)); // -1

using System;

class Solution
{
    public int solution(int[,] maps)
    {
        int answer = 0;
        return answer;
    }
}
