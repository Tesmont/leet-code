using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.DynamicProgramming;

internal class _0300_LongestIncreasingSubsequence
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var nums = new int[] { 10, 9, 2, 5, 3, 7, 101, 18 };
            Test(nums);
        }

        private void Test(int[] nums)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(nums), JsonSerializer.Serialize(nums))
            };

            var result = new _0300_LongestIncreasingSubsequence().LengthOfLIS(nums);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(nums), JsonSerializer.Serialize(nums))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    /// <summary>
    /// DP
    /// O(N^2)
    /// </summary>
    public int LengthOfLIS(int[] nums)
    {
        var dp = new int[nums.Length];
        Array.Fill(dp, 1);

        for (var i = 1; i <= nums.Length; i++)
        {
            var num1 = nums[i];
            for (int j = 0; j < i; j++)
            {
                var num2 = nums[j];
                if (num1 > num2)
                {
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
            }
        }

        return dp.Max();
    }
}
