// https://school.programmers.co.kr/learn/courses/30/lessons/84021?language=csharp
// https://doublsb.tistory.com/124
// https://howudong.tistory.com/158
// https://velog.io/@soseuleaf/%ED%8D%BC%EC%A6%90-%EC%A1%B0%EA%B0%81-%EC%B1%84%EC%9A%B0%EA%B8%B0

using System;
using System.Collections.Generic;
using System.Linq;

int[,] game_board = new int[,] {
    {1, 1, 0, 0, 1, 0},
    {0, 0, 1, 0, 1, 0},
    {0, 1, 1, 0, 0, 1},
    {1, 1, 0, 1, 1, 1},
    {1, 0, 0, 0, 1, 0},
    {0, 1, 1, 1, 0, 0}
};

int[,] table = new int[,] {
    {1, 0, 0, 1, 1, 0},
    {1, 0, 1, 0, 1, 0},
    {0, 1, 1, 0, 1, 1},
    {0, 0, 1, 0, 0, 0},
    {1, 1, 0, 1, 1, 0},
    {0, 1, 0, 0, 0, 0}
};
// result = 14

var sol = new Solution();
Console.WriteLine(sol.solution(game_board, table));

public class Solution
{
    // 좌표 값형식 (튜플 대체)
    public struct Point
    {
        public int X;
        public int Y;
        public Point(int x, int y) { X = x; Y = y; }
    }

    public int solution(int[,] game_board, int[,] table)
    {
        // 1. 테이블에서 퍼즐 조각 추출
        var pieces = ExtractPieces(table);

        // 2. 게임 보드에서 빈 칸 추출
        var blanks = ExtractBlanks(game_board);

        // 3. 모양 비교 및 매칭
        int score = 0;

        foreach (var blank in blanks)
        {
            // foreach 는 IEnumerable 을 이용해서 순회하는데, 
            // List<T> 컬렉션이 중간에 수정되므로(Remove) 버전 번호가 바뀌고
            // InvalidOperationException이 발생할 수 있으므로 ToList()로 복사를 하여 사용
            foreach (var piece in pieces.ToList())
            {
                if (blank.Count == piece.Count && Match(blank, piece))
                {
                    score += blank.Count;   // 빈 칸 크기만큼 점수
                    pieces.Remove(piece);   // 사용한 퍼즐 제거
                    break;
                }
            }
        }

        return score;
    }

    // 1. table에서 퍼즐 조각 추출 (값이 1인 연결요소)
    public List<List<Point>> ExtractPieces(int[,] table)
    {
        int n = table.GetLength(0);
        bool[,] visited = new bool[n, n];
        var pieces = new List<List<Point>>();

        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (table[i, j] == 1 && !visited[i, j])
                {
                    var piece = new List<Point>();
                    var queue = new Queue<Point>();
                    queue.Enqueue(new Point(i, j));
                    visited[i, j] = true;

                    while (queue.Count > 0)
                    {
                        var cur = queue.Dequeue();
                        int x = cur.X, y = cur.Y;
                        piece.Add(new Point(x, y));

                        for (int dir = 0; dir < 4; dir++)
                        {
                            int nx = x + dx[dir];
                            int ny = y + dy[dir];
                            if (nx >= 0 && ny >= 0 && nx < n && ny < n)
                            {
                                if (table[nx, ny] == 1 && !visited[nx, ny])
                                {
                                    visited[nx, ny] = true;
                                    queue.Enqueue(new Point(nx, ny));
                                }
                            }
                        }
                    }

                    // 정규화: 좌표를 (0,0) 기준으로 왼쪽 위로 붙이기
                    int minX = piece.Min(p => p.X);
                    int minY = piece.Min(p => p.Y);
                    var normalized = piece
                        .Select(p => new Point(p.X - minX, p.Y - minY))
                        .ToList();

                    pieces.Add(normalized);
                }
            }
        }

        return pieces;
    }

    // 2. game_board에서 빈 칸 추출 (값이 0인 연결요소)
    public List<List<Point>> ExtractBlanks(int[,] game_board)
    {
        int n = game_board.GetLength(0);
        bool[,] visited = new bool[n, n];
        var blanks = new List<List<Point>>();

        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (game_board[i, j] == 0 && !visited[i, j])
                {
                    var blank = new List<Point>();
                    var queue = new Queue<Point>();
                    queue.Enqueue(new Point(i, j));
                    visited[i, j] = true;

                    while (queue.Count > 0)
                    {
                        var cur = queue.Dequeue();
                        int x = cur.X, y = cur.Y;
                        blank.Add(new Point(x, y));

                        for (int dir = 0; dir < 4; dir++)
                        {
                            int nx = x + dx[dir];
                            int ny = y + dy[dir];
                            if (nx >= 0 && ny >= 0 && nx < n && ny < n)
                            {
                                if (game_board[nx, ny] == 0 && !visited[nx, ny])
                                {
                                    visited[nx, ny] = true;
                                    queue.Enqueue(new Point(nx, ny));
                                }
                            }
                        }
                    }

                    // 정규화
                    int minX = blank.Min(p => p.X);
                    int minY = blank.Min(p => p.Y);
                    var normalized = blank
                        .Select(p => new Point(p.X - minX, p.Y - minY))
                        .ToList();

                    blanks.Add(normalized);
                }
            }
        }

        return blanks;
    }

    // 3-1. 좌표 정규화 + 정렬 (비교를 위해 순서/기준 통일)
    public List<Point> Normalize(List<Point> shape)
    {
        int minX = shape.Min(p => p.X);
        int minY = shape.Min(p => p.Y);
        return shape
            .Select(p => new Point(p.X - minX, p.Y - minY))
            .OrderBy(p => p.X).ThenBy(p => p.Y)
            .ToList();
    }

    // 3-2. 회전 (시계 90도): (x, y) -> (y, -x)
    // 회전 후 음수가 생길 수 있으므로 매 비교 전 Normalize로 보정
    public List<Point> Rotate(List<Point> shape)
    {
        return shape.Select(p => new Point(p.Y, -p.X)).ToList();
    }

    // 3-3. 모양 비교: 정규화된 좌표 집합이 동일한지
    // 크기(좌표 개수)가 같아야 하고
    // 정규화된 좌표 집합이 동일해야 함
    // 퍼즐 조각을 회전 4번 시도해서 하나라도 맞으면 매칭
    public bool Match(List<Point> blank, List<Point> piece)
    {
        var normBlank = Normalize(blank);
        var rotated = piece;

        for (int i = 0; i < 4; i++)
        {
            var normPiece = Normalize(rotated);
            // Point는 값형식이므로 필드 값이 같으면 값 비교로 동일하게 판단됨
            if (Enumerable.SequenceEqual(normBlank, normPiece))
                return true;

            rotated = Rotate(rotated);
        }
        return false;
    }
}
