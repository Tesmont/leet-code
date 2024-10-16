using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.BinarySearch;

internal class _1283_FindTheSmallestDivisorGivenAThreshold
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var nums = new int[] { 1, 2, 5, 9 };
            var threshold = 6;
            Test(nums, threshold);
        }

        private void Test(int[] nums, int threshold)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(nums), JsonSerializer.Serialize(nums)),
                (nameof(threshold), JsonSerializer.Serialize(threshold))
            };

            var result = new _1283_FindTheSmallestDivisorGivenAThreshold().SmallestDivisor(nums, threshold);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(nums), JsonSerializer.Serialize(nums)),
                (nameof(threshold), JsonSerializer.Serialize(threshold))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int SmallestDivisor(int[] nums, int threshold)
    {
        var min = 1;
        var max = nums.Max();

        while (min < max)
        {
            var mid = min + (max - min) / 2;

            var sum = CalculateSum(mid);
            if(sum <= threshold)
            {
                max = mid;
            }
            else
            {
                min = mid + 1;
            }
        }

        return min;

        int CalculateSum(int divisor)
        {
            var sum = 0;
            foreach(var num in nums)
            {
                //Math.Ceiling
                sum += (num - 1) / divisor + 1;
            }

            return sum;
        }
    }
}
