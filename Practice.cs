var sol = new Solution();

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
sol.solution(game_board, table);

public class Solution
{
    public int solution(int[,] game_board, int[,] table)
    {
        // 1. table에서 퍼즐 조각 추출
        // 2. game_board에서 빈 칸 추출
        // 3. 모양 비교 및 매칭
        // 4. 점수 계산 후 반환
        //ExtractPieces(table);
        ExtractBlanks(game_board);
        return 0;
    }

    // 테이블에서 퍼즐 조각을 추출
    public List<List<(int, int)>> ExtractPieces(int[,] table) {
        var pieces = new List<List<(int, int)>>();
        int n = table.GetLength(0);
        bool[,] visited = new bool[n,n];

        int[] dx = {-1, 1, 0, 0};
        int[] dy = {0, 0, -1, 1};

        for(var i = 0; i < n; i++){
            for(var j = 0; j < n; j++) {
                if(!visited[i,j] && table[i,j] == 1) {
                    var piece = new List<(int, int)>();
                    var queue = new Queue<(int, int)>();
                    queue.Enqueue((i, j));
                    visited[i, j] = true;
                    while(queue.Count > 0) {
                        var (x, y) = queue.Dequeue();
                        piece.Add((x, y));

                        for(var dir = 0; dir < 4; dir++) {
                            var nx = x + dx[dir];
                            var ny = y + dy[dir];

                            if(nx >= 0 && ny >= 0 && nx < n && ny < n) {
                                if(!visited[nx, ny] && table[nx, ny] == 1) {
                                    queue.Enqueue((nx, ny));
                                    visited[nx, ny] = true;
                                }
                            }

                        }
                    }
                    //Console.WriteLine(String.Join(" ", piece));
                    int minX = piece.Min(p => p.Item1);
                    int minY = piece.Min(p => p.Item2);
                    var normalized = piece.Select(p => (p.Item1 - minX, p.Item2 - minY)).ToList();
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
                if (game_board[i, j] == 1 && !visited[i, j])
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
                                if (game_board[nx, ny] == 1 && !visited[nx, ny])
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
foreach(var blank in blanks) {
    Console.WriteLine(String.Join(" ", blank));
}
        return blanks;
    }

}