using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.Heaps.TopK;

internal class _0703_KthLargestElementInAStream
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var k = 3;
            var nums = new int[] { 4, 5, 8, 2 };
            var kthLargest = new KthLargest(k, nums);

            var result1 = kthLargest.Add(3); // returns 4
            var result2 = kthLargest.Add(5); // returns 5
            var result3 = kthLargest.Add(10); // returns 5
            var result4 = kthLargest.Add(9); // returns 8
            var result5 = kthLargest.Add(4); // returns 8

            Test(k, nums, [3, 5, 10, 9, 4], [result1, result2, result3, result4, result5]);
        }

        private void Test(int k, int[] nums, int[] valuesToAdd, int[] results)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(k), JsonSerializer.Serialize(k)),
                (nameof(nums), JsonSerializer.Serialize(nums)),
                (nameof(valuesToAdd), JsonSerializer.Serialize(valuesToAdd))
            };

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(k), JsonSerializer.Serialize(k)),
                (nameof(nums), JsonSerializer.Serialize(nums)),
                (nameof(valuesToAdd), JsonSerializer.Serialize(valuesToAdd)),
                (nameof(results), JsonSerializer.Serialize(results))
            };

            var resultStr = JsonSerializer.Serialize(results);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

public class KthLargest
{
    private readonly int _k;
    private PriorityQueue<int, int> _heap;

    public KthLargest(int k, int[] nums)
    {
        var heapSource = nums.Select(i => (i, i));
        _heap = new PriorityQueue<int, int>(heapSource);

        while(_heap.Count > k)
        {
            _heap.Dequeue();
        }
        _k = k;
    }

    public int Add(int val)
    {
        if (_heap.Count < _k)
        {
            _heap.Enqueue(val, val);
        }
        else
        {
            _heap.EnqueueDequeue(val, val);
        }

        return _heap.Peek();
    }
}
}
