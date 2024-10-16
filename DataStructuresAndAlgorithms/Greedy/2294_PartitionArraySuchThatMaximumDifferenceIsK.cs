using DataStructuresAndAlgorithms.ArrayAndStrings;
using Helpers;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.Greedy;

internal class _2294_PartitionArraySuchThatMaximumDifferenceIsK
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var nums = new int[] { 3, 6, 1, 2, 5 };
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

            var result = new _2294_PartitionArraySuchThatMaximumDifferenceIsK().PartitionArray(nums, k);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(nums), JsonSerializer.Serialize(nums)),
                (nameof(k), JsonSerializer.Serialize(k))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int PartitionArray(int[] nums, int k)
    {
        Span<bool> countingSortedNums = stackalloc bool[100001];
        for(var i = 0; i < nums.Length; i++)
        {
            countingSortedNums[nums[i]] = true;
        }

        var subsequenceCount = 0;
        var min = -countingSortedNums.Length;

        for(var i = 0; i < countingSortedNums.Length; i++)
        {
            if (!countingSortedNums[i])
            {
                continue;
            }

            if (i - min > k)
            {
                min = i;
                subsequenceCount++;
            }
        }

        return subsequenceCount;
    }
}
