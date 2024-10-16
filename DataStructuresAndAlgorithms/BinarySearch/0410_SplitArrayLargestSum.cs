using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.BinarySearch;

internal class _0410_SplitArrayLargestSum
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var nums = new int[] { 1, 4, 4 };
            var k = 3;
            Test(nums, k);
        }

        private void Test(int[] nums, int k)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(nums), JsonSerializer.Serialize(nums)),
                (nameof(k), JsonSerializer.Serialize(k))
            };

            var result = new _0410_SplitArrayLargestSum().SplitArray(nums, k);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(nums), JsonSerializer.Serialize(nums)),
                (nameof(k), JsonSerializer.Serialize(k))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int SplitArray(int[] nums, int k)
    {
        var min = nums.Max();
        var max = nums.Sum();

        while (min < max)
        {
            var mid = min + (max - min) / 2;

            var subArrayCount = SplitArray(mid);
            if(subArrayCount <= k)
            {
                max = mid;
            }
            else
            {
                min = mid + 1;
            }
        }

        return min;

        int SplitArray(int limit)
        {
            var subArrayCount = 0;
            var currentSum = 0;

            foreach(var num in nums)
            {
                currentSum += num;

                if(currentSum > limit)
                {
                    subArrayCount++;
                    currentSum = num;
                }
            }

            return subArrayCount + 1;
        }
    }
}
