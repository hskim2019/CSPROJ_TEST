// https://school.programmers.co.kr/learn/courses/30/lessons/84021?language=csharp
// https://doublsb.tistory.com/124
// https://howudong.tistory.com/158
// https://velog.io/@soseuleaf/%ED%8D%BC%EC%A6%90-%EC%A1%B0%EA%B0%81-%EC%B1%84%EC%9A%B0%EA%B8%B0
using System;

var int[,] game_board = [[1, 1, 0, 0, 1, 0], [0, 0, 1, 0, 1, 0], [0, 1, 1, 0, 0, 1], [1, 1, 0, 1, 1, 1], [1, 0, 0, 0, 1, 0], [0, 1, 1, 1, 0, 0]];
var int[,] table = [[1, 0, 0, 1, 1, 0], [1, 0, 1, 0, 1, 0], [0, 1, 1, 0, 1, 1], [0, 0, 1, 0, 0, 0], [1, 1, 0, 1, 1, 0], [0, 1, 0, 0, 0, 0]];
// result = 14


public class Solution
{
    public int solution(int[,] game_board, int[,] table)
    {
        int answer = -1;

        // 1. table에서 퍼즐 조각 추출
        // 2. game_board에서 빈 칸 추출
        // 3. 모양 비교 및 매칭
        // 4. 점수 계산 후 반환
        return answer;
    }


    public List<List<(int, int)>> ExtractPieces(int[,] table)
    {
        int n = table.GetLength(0);
        bool[,] visited = new bool[n, n];
        var pieces = new List<List<(int, int)>>();

        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (table[i, j] == 1 && !visited[i, j])
                {
                    var piece = new List<(int, int)>();
                    var queue = new Queue<(int, int)>();
                    queue.Enqueue((i, j));
                    visited[i, j] = true;

                    while (queue.Count > 0)
                    {
                        var (x, y) = queue.Dequeue();
                        piece.Add((x, y));

                        for (int dir = 0; dir < 4; dir++)
                        {
                            int nx = x + dx[dir];
                            int ny = y + dy[dir];
                            if (nx >= 0 && ny >= 0 && nx < n && ny < n)
                            {
                                if (table[nx, ny] == 1 && !visited[nx, ny])
                                {
                                    visited[nx, ny] = true;
                                    queue.Enqueue((nx, ny));
                                }
                            }
                        }
                    }

                    // 정규화
                    int minX = piece.Min(p => p.Item1);
                    int minY = piece.Min(p => p.Item2);
                    var normalized = piece
                        .Select(p => (p.Item1 - minX, p.Item2 - minY))
                        .ToList();

                    pieces.Add(normalized);
                }
            }
        }

        return pieces;
    }
}