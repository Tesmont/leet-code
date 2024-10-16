using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.BinarySearch;

internal class _2389_LongestSubsequenceWithLimitedSum
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var nums = new int[] { 4, 5, 2, 1 };
            var queries = new int[] { 0, 1, 2, 3, 4, 5, 10, 21 };
            Test(nums, queries);
        }

        private void Test(int[] nums, int[] queries)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(nums), JsonSerializer.Serialize(nums)),
                (nameof(queries), JsonSerializer.Serialize(queries))
            };

            var result = new _2389_LongestSubsequenceWithLimitedSum().AnswerQueries(nums, queries);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(nums), JsonSerializer.Serialize(nums)),
                (nameof(queries), JsonSerializer.Serialize(queries))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int[] AnswerQueries(int[] nums, int[] queries)
    {
        Array.Sort(nums);

        var prefixSum = new int[nums.Length];
        var currentSum = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            currentSum += nums[i];
            prefixSum[i] = currentSum;
        }

        var result = new int[queries.Length];
        for(var i = 0; i < queries.Length; i++)
        {
            var index = BinarySearch(prefixSum, queries[i]);
            if(index == prefixSum.Length)
            {
                result[i] = prefixSum.Length;
                continue;
            }

            if (prefixSum[index] == queries[i])
            {
                result[i] = index + 1;
                continue;
            }

            result[i] = index;
        }

        return result;
    }

    private int BinarySearch(int[] arr, int target)
    {
        var left = 0L;
        var right = arr.LongLength;

        while (left < right)
        {
            var mid = (left + right) / 2;

            if (arr[mid] >= target)
            {
                right = mid;
            }
            else
            {
                left = mid + 1;
            }
        }

        return (int)left;
    }
}
