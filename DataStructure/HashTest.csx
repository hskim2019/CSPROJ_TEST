using System;
using System.Collections;
using System.Collections.Generic;

// Hashtable 테스트
// Key와 Value를 사용하여 자료를 저장하며, 중복 Key는 허용되지 않음.
// Key와 Value 모두 Object 형식이므로 박싱/언박싱 발생 가능.
// 다양한 타입의 데이터를 저장할 수 있음.
void HashTableTest()
{
    var hash = new Hashtable();
    hash.Add("A", 1);
    hash.Add("B", "Hello");
    hash.Add("C", 3.14);

    Console.WriteLine("Hashtable 출력:");
    foreach (var key in hash.Keys)
    {
        Console.WriteLine($"{key} → {hash[key]}");
    }

    // 예시: 값 가져오기
    int valueA = (int)hash["A"];
    Console.WriteLine($"'A'의 값: {valueA}");
}

// HashSet 테스트
// Key 없이 Value만 저장하며, 중복을 허용하지 않음.
// 순서가 없으며, 삽입 순서와 출력 순서가 다를 수 있음.
void HashSetTest()
{
    HashSet<int> uniqueVals = new HashSet<int>();
    uniqueVals.Add(1);
    uniqueVals.Add(2);
    uniqueVals.Add(1); // 중복은 무시됨
    uniqueVals.Remove(0); // 없는 값 제거 시 오류 없음

    Console.WriteLine("HashSet 출력:");
    foreach (var val in uniqueVals)
    {
        Console.WriteLine(val);
    }
}

// 실행
Console.WriteLine("▶ HashTable 테스트");
HashTableTest();

Console.WriteLine("\n▶ HashSet 테스트");
HashSetTest();