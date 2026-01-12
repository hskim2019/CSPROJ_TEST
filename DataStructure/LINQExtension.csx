// 📌 CSharp_LINQ_Extensions.csx
// LINQ 확장 함수 메모 및 간단 예제
// using System.Linq 필요

using System;
using System.Collections.Generic;
using System.Linq;

var nums = new List<int> { 1, 2, 3, 4, 5 };

// =======================
// SequenceEqual
// =======================
// 두 시퀀스가 길이, 순서, 값까지 동일한지 비교
Console.WriteLine(nums.SequenceEqual(new List<int> { 1, 2, 3, 4, 5 })); // true
Console.WriteLine(nums.SequenceEqual(new List<int> { 5, 4, 3, 2, 1 })); // false

// =======================
// Except
// =======================
// 차집합 (nums - other)
var except = nums.Except(new List<int> { 2, 3 });
Console.WriteLine(string.Join(", ", except)); // 1, 4, 5

// =======================
// Intersect
// =======================
// 교집합
var intersect = nums.Intersect(new List<int> { 3, 4, 6 });
Console.WriteLine(string.Join(", ", intersect)); // 3, 4

// =======================
// Union
// =======================
// 합집합
var union = nums.Union(new List<int> { 5, 6, 7 });
Console.WriteLine(string.Join(", ", union)); // 1,2,3,4,5,6,7

// =======================
// Count
// =======================
// 요소 개수
Console.WriteLine(nums.Count()); // 5

// =======================
// Any / All
// =======================
// 조건 만족 여부
Console.WriteLine(nums.Any(x => x > 3)); // true
Console.WriteLine(nums.All(x => x > 0)); // true

// =======================
// Select
// =======================
// 요소 변환
var doubled = nums.Select(x => x * 2);
Console.WriteLine(string.Join(", ", doubled)); // 2,4,6,8,10

// =======================
// Where
// =======================
// 조건 필터링
var evens = nums.Where(x => x % 2 == 0);
Console.WriteLine(string.Join(", ", evens)); // 2,4

// =======================
// OrderBy / OrderByDescending
// =======================
// 정렬
var ordered = nums.OrderBy(x => x);
Console.WriteLine(string.Join(", ", ordered)); // 1,2,3,4,5

var desc = nums.OrderByDescending(x => x);
Console.WriteLine(string.Join(", ", desc)); // 5,4,3,2,1