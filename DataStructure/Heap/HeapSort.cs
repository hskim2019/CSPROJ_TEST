//https://www.geeksforgeeks.org/heap-sort/
// namespace DotNet.DataStructure.Heap
// {

HeapSort heapSort = new HeapSort();
heapSort.Test();

public class HeapSort
{
    public HeapSort() { }
    public void Test()
    {
        int[] arr = { 12, 11, 13, 5, 6, 7 };
        int N = arr.Length;

        sort(arr);

        Console.WriteLine("Sorted array is");
        printArray(arr);
    }

    private void sort(int[] arr)
    {
        int N = arr.Length;

        // Build heap
        for (int i = N / 2 - 1; i >= 0; i--)
        {
            heapify(arr, N, i, "1 : " + i + "...");
        }

        // One by one extract an element from heap
        for (int i = N - 1; i > 0; i--)
        {
            // Move current root to end
            int temp = arr[0];
            arr[0] = arr[i];
            arr[i] = temp;

            heapify(arr, i, 0, "2 : " + i + "...");
        }
    }

    private void heapify(int[] arr, int N, int i, string origin)
    {
        Console.WriteLine("origin " + origin);
        int largest = i;

        int l = 2 * i + 1;
        int r = 2 * i + 2;

        if (l < N && arr[l] > arr[largest])
        {
            largest = l;
        }
        if (r < N && arr[r] > arr[largest])
        {
            largest = r;
        }

        if (largest != i)
        {
            int swap = arr[i];
            arr[i] = arr[largest];
            arr[largest] = swap;

            heapify(arr, N, largest, "3 : " + origin);
        }

        Console.WriteLine("origin " + origin + " END");
    }

    private void printArray(int[] arr)
    {
        int N = arr.Length;
        for (int i = 0; i < N; i++)
        {
            Console.Write(arr[i] + " ");
        }
    }
}
// }

