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

// -시작점을 큐에 넣고, 거리 배열(dist)을 1로 초기화.
// - 큐에서 하나 꺼내서 상하좌우 인접 칸을 확인.
// - 갈 수 있고 아직 방문하지 않은 칸이면:
// -dist[nx][ny] = dist[x][y] + 1
// - 큐에 넣기
// - 목표 지점에 도착하면 그때의 dist 값이 최단거리.
// - 큐가 빌 때까지 탐색했는데 도착 못하면 -1 반환.

using System;
using System.Collections.Generic;

// 테스트 데이터는 int[,] 으로 선언해야 함
var maps1 = new int[,] {
    {1, 0, 1, 1, 1},
    {1, 0, 1, 0, 1},
    {1, 0, 1, 1, 1},
    {1, 1, 1, 0, 1},
    {0, 0, 0, 0, 1}
};

var maps2 = new int[,] {
    {1, 0, 1, 1, 1},
    {1, 0, 1, 0, 1},
    {1, 0, 1, 1, 1},
    {1, 1, 1, 0, 0},
    {0, 0, 0, 0, 1}
};

var sol = new Solution();
Console.WriteLine(sol.solution(maps1)); // 11
Console.WriteLine(sol.solution(maps2)); // -1


public class Solution
{
    public int solution(int[,] maps)
    {
        int n = maps.GetLength(0); // 행
        int m = maps.GetLength(1); // 열

        // 거리 배열: -1로 초기화 (방문 안 함)
        int[,] dist = new int[n, m];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                dist[i, j] = -1;

        // BFS 준비
        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };
        var queue = new Queue<(int x, int y)>();

        // 시작점
        queue.Enqueue((0, 0));
        dist[0, 0] = 1;

        while (queue.Count > 0)
        {
            var (x, y) = queue.Dequeue();

            for (int dir = 0; dir < 4; dir++)
            {
                int nx = x + dx[dir];
                int ny = y + dy[dir];

                if (nx >= 0 && ny >= 0 && nx < n && ny < m)
                {
                    if (maps[nx, ny] == 1 && dist[nx, ny] == -1)
                    {
                        dist[nx, ny] = dist[x, y] + 1;
                        queue.Enqueue((nx, ny));
                    }
                }
            }
        }

        return dist[n - 1, m - 1];
    }
}