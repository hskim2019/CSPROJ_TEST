// 📌 CSharp_List_Usage.csx
// List<T> 기본 용법 및 자주 쓰는 메서드 정리
// 실행: csi CSharp_List_Usage.csx 또는 dotnet-script 사용

using System;
using System.Collections.Generic;

var list = new List<int>();

// =======================
// 요소 추가 / 제거
// =======================
list.Add(10);              // 요소 추가
list.AddRange(new[] { 20, 30 }); // 여러 요소 추가
list.Remove(20);           // 특정 값 제거 (첫 번째만 제거)
list.RemoveAt(0);          // 인덱스로 제거
list.Clear();              // 모든 요소 제거

// =======================
// 접근 / 검색
// =======================
list.AddRange(new[] { 1, 2, 3, 4 });
Console.WriteLine(list[0]);        // 인덱스로 접근
Console.WriteLine(list.Contains(3)); // 특정 값 포함 여부
Console.WriteLine(list.IndexOf(4));  // 특정 값의 인덱스
Console.WriteLine(list.Count);       // 요소 개수

// =======================
// 변환
// =======================
int[] arr = list.ToArray();        // 리스트 → 배열
var newList = new List<int>(arr);  // 배열 → 리스트

// =======================
// 정렬 / 뒤집기
// =======================
list.Sort();                       // 오름차순 정렬
list.Sort((a, b) => b.CompareTo(a)); // 내림차순 정렬
list.Reverse();                    // 순서 뒤집기

// =======================
// 반복문
// =======================
foreach (var item in list)
{
    Console.WriteLine(item);
}

// =======================
// 고급 메서드
// =======================
list.Insert(0, 99);                // 특정 위치에 삽입
list.RemoveAll(x => x % 2 == 0);   // 조건에 맞는 모든 요소 제거
var subList = list.GetRange(0, 2); // 부분 리스트 추출