# C# Length / Count / Count() 비교

| 구분      | 대상                                   | 반환값 | 특징                                   |
|-----------|----------------------------------------|--------|----------------------------------------|
| Length    | 배열(Array), 문자열(string)            | int    | 전체 길이(요소 수), 속성(Property)     |
| Count     | 컬렉션(List, Dictionary, HashSet 등)   | int    | 포함된 요소 수, 속성(Property)         |
| Count()   | IEnumerable<T> (LINQ 확장 메서드)      | int    | 조건을 만족하는 요소 수, 메서드(Method) |



```c#
// 배열
int[] arr = { 1, 2, 3, 4 };
Console.WriteLine(arr.Length);  // 4

// 문자열
string text = "hello";
Console.WriteLine(text.Length); // 5

// 리스트
List<int> list = new List<int> { 1, 2, 3, 4 };
Console.WriteLine(list.Count);  // 4

// Dictionary
Dictionary<string, int> dict = new Dictionary<string, int>
{
    {"A", 1}, {"B", 2}
};
Console.WriteLine(dict.Count);  // 2

// LINQ Count()
int[] nums = { 1, 2, 3, 4, 5 };
int greaterThanTwo = nums.Where(x => x > 2).Count();
Console.WriteLine(greaterThanTwo); // 3 (3,4,5)
```