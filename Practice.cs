using System;

var genres = { "classic", "pop", "classic", "classic", "pop" };
var plays = { 500, 600, 150, 800, 2500 };
// [4, 1, 3, 0]

public class Solution
{
    public class Song
    {
        public int Index { get; set; }
        public int Plays { get; set; }
    }
    public int[] solution(string[] genres, int[] plays)
    {
        var dict = new Dictionary<string, List<Song>>();
        for (int i = 0; i < genres.Length; i++)
        {
            if (!dict.ContainsKey(genres[i]))
                dict[genres[i]] = new List<Song>();

            dict[genres[i]].Add(new Song { Index = i, Plays = plays[i] });

        }

        var sortedGenres = dict.OrderByDescending(p => p.Value.Sum(song => song.Plays));
        var answer = new List<int>();

        foreach (var genre in sortedGenres)
        {
            var topSongs = genre.Value.OrderByDescending(s => s.Plays)
            .ThenBy(s => s.Index).Take(2);
            answer.AddRange(topSongs.Select(s => s.Index));
        }
        return answer.ToArray();
    }
}
