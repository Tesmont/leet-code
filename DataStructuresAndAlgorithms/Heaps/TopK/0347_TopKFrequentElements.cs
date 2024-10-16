using Helpers;
using System.Globalization;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.Heaps.TopK;

internal class _0347_TopKFrequentElements
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var nums = new int[] { 1, 1, 1, 2, 2, 3 };
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

            var result = new _0347_TopKFrequentElements().TopKFrequent(nums, k);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(nums), JsonSerializer.Serialize(nums)),
                (nameof(k), JsonSerializer.Serialize(k))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int[] TopKFrequent(int[] nums, int k)
    {
        var frequencyMap = new Dictionary<int, int>();
        for(var i = 0; i < nums.Length; i++)
        {
            if(frequencyMap.TryGetValue(nums[i], out var frequency))
            {
                frequency++;
            }

            frequencyMap[nums[i]] = frequency;
        }

        var heap = new PriorityQueue<int, int>();

        foreach (var kvp in frequencyMap)
        {
            heap.Enqueue(kvp.Key, kvp.Value);

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
        
        return result;
    }
}
