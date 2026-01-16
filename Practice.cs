string[] phone_book = { "123", "456", "789" };
var sol = new Solution();
Console.WriteLine(sol.solution(phone_book));
class Solution
{
    public bool solution(String[] phone_book)
    {
        Array.Sort(phone_book);
        for (var i = 0; i < phone_book.Length - 1; i++)
        {
            if (phone_book[i + 1].StartsWith(phone_book[i]))
                return false;
        }
        return true;
    }
}