// https://school.programmers.co.kr/learn/courses/30/lessons/84021?language=csharp
// https://doublsb.tistory.com/124
// https://howudong.tistory.com/158
// https://velog.io/@soseuleaf/%ED%8D%BC%EC%A6%90-%EC%A1%B0%EA%B0%81-%EC%B1%84%EC%9A%B0%EA%B8%B0

// 0이고!visited
// ->visited 처리
// ->q 에 담기
// q에서 꺼내기
//  -> 담기
//  -> dir 확인
//      -> 0이고 !visited 이면
//          -> visited 처리
//          -> q에 담기


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


public class Solution {
    int n;
    int[] dx = { -1, 1, 0, 0 };
    int[] dy = { 0, 0, -1, 1 };

    public int solution(int[,] game_board, int[,] table) {
        n = game_board.GetLength(0);

        var blanks = ExtractShapes(game_board, 0); // 빈 공간
        var pieces = ExtractShapes(table, 1);      // 퍼즐 조각

        int answer = 0;
        var used = new bool[pieces.Count];

        foreach (var blank in blanks) {
            for (int i = 0; i < pieces.Count; i++) {
                if (used[i]) continue;
                var piece = pieces[i];

                for (int r = 0; r < 4; r++) {
                    var rotated = Rotate(piece, r);
                    if (EqualShape(blank, rotated)) {
                        answer += blank.Count;
                        used[i] = true;
                        goto NextBlank;
                    }
                }
            }
            NextBlank:;
        }

        return answer;
    }

    // BFS로 모양 추출
    List<List<(int,int)>> ExtractShapes(int[,] board, int target) {
        var visited = new bool[n,n];
        var shapes = new List<List<(int,int)>>();

        for (int i=0; i<n; i++) {
            for (int j=0; j<n; j++) {
                if (!visited[i,j] && board[i,j]==target) {
                    var q = new Queue<(int,int)>();
                    var shape = new List<(int,int)>();
                    q.Enqueue((i,j));
                    visited[i,j] = true;

                    while (q.Count>0) {
                        var (x,y) = q.Dequeue();
                        shape.Add((x,y));
                        for (int d=0; d<4; d++) {
                            int nx=x+dx[d], ny=y+dy[d];
                            if (nx>=0 && ny>=0 && nx<n && ny<n &&
                                !visited[nx,ny] && board[nx,ny]==target) {
                                visited[nx,ny]=true;
                                q.Enqueue((nx,ny));
                            }
                        }
                    }
                    shapes.Add(Normalize(shape));
                }
            }
        }
        return shapes;
    }

    // 좌표 정규화
    List<(int,int)> Normalize(List<(int,int)> shape) {
        int minX = shape.Min(p=>p.Item1);
        int minY = shape.Min(p=>p.Item2);
        return shape.Select(p=>(p.Item1-minX, p.Item2-minY))
                    .OrderBy(p=>p.Item1).ThenBy(p=>p.Item2).ToList();
    }

    // 회전
    List<(int,int)> Rotate(List<(int,int)> shape, int times) {
        var rotated = shape.Select(p=>{
            int x=p.Item1, y=p.Item2;
            for (int t=0; t<times; t++) (x,y)=(y,n-1-x);
            return (x,y);
        }).ToList();
        return Normalize(rotated);
    }

    // 모양 비교
    bool EqualShape(List<(int,int)> a, List<(int,int)> b) {
        if (a.Count!=b.Count) return false;
        return a.SequenceEqual(b);
    }
}