//https://www.geeksforgeeks.org/heap-sort/
using System;

// 실행
int[] arr = { 12, 11, 13, 5, 6, 7 };
int N = arr.Length;

Sort(arr);

Console.WriteLine("Sorted array is:");
PrintArray(arr);

// 힙 정렬 함수
void Sort(int[] arr)
{
    int N = arr.Length;

    // Build heap (rearrange array)
    for (int i = N / 2 - 1; i >= 0; i--)
    {
        Heapify(arr, N, i, $"1 : {i}...");
    }

    // One by one extract elements from heap
    for (int i = N - 1; i > 0; i--)
    {
        // Move current root to end
        int temp = arr[0];
        arr[0] = arr[i];
        arr[i] = temp;

        // call max heapify on the reduced heap
        Heapify(arr, i, 0, $"2 : {i}...");
    }
}

// 힙 구성 함수
void Heapify(int[] arr, int N, int i, string origin)
{
    Console.WriteLine("origin " + origin);
    int largest = i;
    int l = 2 * i + 1;
    int r = 2 * i + 2;

    if (l < N && arr[l] > arr[largest])
        largest = l;

    if (r < N && arr[r] > arr[largest])
        largest = r;

    if (largest != i)
    {
        int swap = arr[i];
        arr[i] = arr[largest];
        arr[largest] = swap;

        Heapify(arr, N, largest, "3 : " + origin);
    }

    Console.WriteLine("origin " + origin + " END");
}

// 배열 출력 함수
void PrintArray(int[] arr)
{
    foreach (var item in arr)
    {
        Console.Write(item + " ");
    }
    Console.WriteLine();
}