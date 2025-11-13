// 📌 이 코드는 배열과 리스트의 기본 동작을 테스트하고,
// 📌 두 배열 간의 차집합 및 중복 요소 계산을 수행하는 알고리즘을 포함합니다.
// 📌 배열과 리스트의 차이, 초기값, 인덱스 접근, 중복 허용 여부 등을 실습할 때 유용합니다.

using System;
using System.Collections.Generic;
using System.Linq;

// List<int>는 크기가 가변적이며, 초기에는 Count가 0
List<int> array = new List<int>();
Console.WriteLine(array.Count); // 출력: 0

// 요소가 없으므로 출력되지 않음
foreach (int p in array)
{
    Console.Write(p + " ,");
}
Console.WriteLine();

// 배열은 고정 크기이며, 초기값은 기본값(정수형은 0)
int[] array2 = new int[5];
foreach (int p in array2)
{
    Console.Write(p + ", "); // 출력: 0, 0, 0, 0, 0,
}
Console.WriteLine();

// 테스트용 배열 선언
int[] x = new int[3] { 1, 2, 3 };
int[] y = new int[] { 2 };

// 두 배열 간의 계산 수행
var rv = Calculate(x, x.Length, y, y.Length);
var rv2 = Calculate2(x, x.Length, y, y.Length);
Console.WriteLine("result : " + rv + " result2 : " + rv2);

// 다른 테스트 케이스
x = new int[] { 4, 5, 1, 2, 3 };
y = new int[] { 4, 2 };
rv = Calculate(x, x.Length, y, y.Length);
rv2 = Calculate2(x, x.Length, y, y.Length);
Console.WriteLine("result : " + rv + " result2 : " + rv2);

x = new int[] { 4, 5, 1, 2, 3, 7, 10 };
y = new int[] { 1, 2, 3, 4, 5, 6, 7 };
rv = Calculate(x, x.Length, y, y.Length);
rv2 = Calculate2(x, x.Length, y, y.Length);
Console.WriteLine("result : " + rv + " result2 : " + rv2);

// 📌 Calculate 함수: a에서 b를 제외한 차집합의 개수 + b의 길이
int Calculate(int[] a, int n, int[] b, int m)
{
    var exceptLeft = a.Except(b); // a - b
    var result = b.Length + exceptLeft.Count(); // b의 길이 + 차집합의 개수
    return result;
}

// 📌 Calculate2 함수: a와 b의 총 길이에서 중복된 요소 수만큼 -1
int Calculate2(int[] a, int n, int[] b, int m)
{
    var result = a.Length + b.Length;
    foreach (int value in b)
    {
        if (Array.Exists(a, x => x == value))
        {
            result -= 1;
        }
    }
    return result;
}