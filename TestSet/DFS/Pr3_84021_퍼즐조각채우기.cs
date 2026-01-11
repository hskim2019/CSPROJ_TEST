// https://school.programmers.co.kr/learn/courses/30/lessons/84021?language=csharp
// https://doublsb.tistory.com/124
// https://howudong.tistory.com/158
// https://velog.io/@soseuleaf/%ED%8D%BC%EC%A6%90-%EC%A1%B0%EA%B0%81-%EC%B1%84%EC%9A%B0%EA%B8%B0
using System;

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


public class Solution
{
    public int solution(int[,] game_board, int[,] table)
    {

        // 1. table에서 퍼즐 조각 추출
        
    var pieces = ExtractPieces(table);

        // 2. game_board에서 빈 칸 추출
        var blanks = ExtractBlanks(game_board);
        // 3. 모양 비교 및 매칭

        int score = 0;

    foreach (var blank in blanks) {
    foreach (var piece in pieces.ToList()) {
        if (blank.Count == piece.Count && Match(blank, piece)) {
            score += blank.Count; // 빈 칸 크기만큼 점수 추가
            pieces.Remove(piece); // 사용한 퍼즐 제거
            break;
        }
    }
}

    return score;

        // 4. 점수 계산 후 반환
    }


    // 1. table에서 퍼즐 조각 추출
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

    // 2. game_board에서 빈 칸 추출
    public List<List<(int, int)>> ExtractBlanks(int[,] game_board)
    {
        int n = game_board.GetLength(0);
        bool[,] visited = new bool[n, n];
        var blanks = new List<List<(int, int)>>();

        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (game_board[i, j] == 0 && !visited[i, j])
                {
                    var blank = new List<(int, int)>();
                    var queue = new Queue<(int, int)>();
                    queue.Enqueue((i, j));
                    visited[i, j] = true;

                    while (queue.Count > 0)
                    {
                        var (x, y) = queue.Dequeue();
                        blank.Add((x, y));

                        for (int dir = 0; dir < 4; dir++)
                        {
                            int nx = x + dx[dir];
                            int ny = y + dy[dir];
                            if (nx >= 0 && ny >= 0 && nx < n && ny < n)
                            {
                                if (game_board[nx, ny] == 0 && !visited[nx, ny])
                                {
                                    visited[nx, ny] = true;
                                    queue.Enqueue((nx, ny));
                                }
                            }
                        }
                    }

                    // 정규화
                    int minX = blank.Min(p => p.Item1);
                    int minY = blank.Min(p => p.Item2);
                    var normalized = blank
                        .Select(p => (p.Item1 - minX, p.Item2 - minY))
                        .ToList();

                    blanks.Add(normalized);
                }
            }
        }

        return blanks;
    }

    // 3. 모양 비교 및 매칭
    // 3-1. 좌표 정규화
    public List<(int,int)> Normalize(List<(int,int)> shape) {
    int minX = shape.Min(p => p.Item1);
    int minY = shape.Min(p => p.Item2);
    return shape.Select(p => (p.Item1 - minX, p.Item2 - minY))
                .OrderBy(p => p.Item1).ThenBy(p => p.Item2)
                .ToList();
}

// 3-2. 회전 함수
// 90도 회전 : (x, y) -> (y, -x)
// 180도 회전 : (x, y) -> (-x, -y)
// 270도 회전 : (x, y) -> (-y, x)
public List<(int,int)> Rotate(List<(int,int)> shape) {
    return shape.Select(p => (p.Item2, -p.Item1)).ToList();
}

// 3-3. 모양 비교 함수
// 크기(조표 개수)가 같아야 하고
// 정규화된 좌표 집합이 동일해야 함
// 퍼즐 조각을 회전 4번 시도해서 하나라도 맞으면 매칭
public bool Match(List<(int,int)> blank, List<(int,int)> piece) {
    var normBlank = Normalize(blank);
    var rotated = piece;

    for (int i = 0; i < 4; i++) {
        var normPiece = Normalize(rotated);
        if (normBlank.SequenceEqual(normPiece)) return true;
        rotated = Rotate(rotated);
    }
    return false;
}
}