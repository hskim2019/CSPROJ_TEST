using System;
using System.Collections.Generic;

var maps1 = new int[,] {
    {1, 0, 1, 1, 1},
    {1, 0, 1, 0, 1},
    {1, 0, 1, 1, 1},
    {1, 1, 1, 0, 1},
    {0, 0, 0, 0, 1}
};
var sol = new Solution();
Console.WriteLine(sol.solution(maps1)); // 11
public class Solution
{

    public int solution(int[,] maps)
    {
        int n = maps.GetLength(0);
        int m = maps.GetLength(1);
        int[,] dist = new int[n, m];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                dist[i, j] = -1;
            }
        }
        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };
        var queue = new Queue<(int, int)>();
        queue.Enqueue((0, 0));
        dist[0, 0] = 1;
        while (queue.Count > 0)
        {
            var (x, y) = queue.Dequeue();
            for (int dir = 0; dir < 4; dir++)
            {
                var nx = x + dx[dir];
                var ny = y + dy[dir];
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