using Helpers;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.Heaps.TopK;

internal class _0215_KthLargestElementInAnArray
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var nums = new int[] { 3, 2, 1, 5, 6, 4 };
            var k = 2;
            Test(nums, k);
        }

        private void Test(int[] nums, int k)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(nums), JsonSerializer.Serialize(nums)),
                (nameof(k), JsonSerializer.Serialize(k))
            };

            var result = new _0215_KthLargestElementInAnArray().FindKthLargest(nums, k);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(nums), JsonSerializer.Serialize(nums)),
                (nameof(k), JsonSerializer.Serialize(k))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int FindKthLargest(int[] nums, int k)
    {
        var heap = new PriorityQueue<int, int>();

        foreach(var value in nums)
        {
            heap.Enqueue(value, value);

            if(heap.Count > k)
            {
                heap.Dequeue();
            }
        }

        return heap.Dequeue();
    }
}
