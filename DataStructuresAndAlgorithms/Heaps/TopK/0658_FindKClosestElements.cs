using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.Heaps.TopK;

internal class _0658_FindKClosestElements
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var arr = new int[] { 1, 2, 3, 4, 5 };
            var k = 4;
            var x = 3;
            Test(arr, k, x);
        }

        private void Test(int[] arr, int k, int x)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(arr), JsonSerializer.Serialize(arr)),
                (nameof(k), JsonSerializer.Serialize(k)),
                (nameof(x), JsonSerializer.Serialize(x))
            };

            var result = new _0658_FindKClosestElements().FindClosestElements(arr, k, x);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(arr), JsonSerializer.Serialize(arr)),
                (nameof(k), JsonSerializer.Serialize(k)),
                (nameof(x), JsonSerializer.Serialize(x))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    /// <summary>
    /// HEAP #1
    /// </summary>
    public IList<int> FindClosestElements(int[] arr, int k, int x)
    {
        var comparer = Comparer<(int, int)>.Create((n1, n2) => n2.CompareTo(n1));
        var heap = new PriorityQueue<int, (int, int)>(comparer);

        foreach(var value in arr)
        {
            heap.Enqueue(value, (Math.Abs(value - x), value));

            if(heap.Count > k)
            {
                heap.Dequeue();
            }
        }

        var result = new int[k];

        for(var i = 0; i < k; i++)
        {
            result[i] = heap.Dequeue();
        }

        Array.Sort(result);
        
        return result;
    }

    /// <summary>
    /// HEAP #2
    /// </summary>
    public IList<int> FindClosestElements2(int[] arr, int k, int x)
    {
        var comparer = Comparer<int>.Create((n1, n2) =>
        {
            if (Math.Abs(n1 - x) == Math.Abs(n2 - x))
            {
                return n2 - n1;
            }

            return Math.Abs(n2 - x) - Math.Abs(n1 - x);
        });

        var heap = new PriorityQueue<int, int>(comparer);

        foreach (var value in arr)
        {
            heap.Enqueue(value, value);

            if (heap.Count > k)
            {
                heap.Dequeue();
            }
        }

        var result = new int[k];

        for (var i = 0; i < k; i++)
        {
            result[i] = heap.Dequeue();
        }

        Array.Sort(result);

        return result;
    }
}
