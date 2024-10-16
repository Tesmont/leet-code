using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.DynamicProgramming;

internal class _0198_HouseRobber
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var nums = new int[] { 2, 7, 9, 3, 1 };
            Test(nums);
        }

        private void Test(int[] nums)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(nums), JsonSerializer.Serialize(nums))
            };

            var result = new _0198_HouseRobber().Rob(nums);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(nums), JsonSerializer.Serialize(nums))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int Rob(int[] nums)
    {
        if(nums.Length == 0)
        {
            return 0;
        }

        if (nums.Length == 1)
        {
            return nums[0];
        }

        if (nums.Length == 2)
        {
            return Math.Max(nums[0], nums[1]);
        }

        if(nums.Length == 3)
        {
            nums[0] += nums[2];
            return Math.Max(nums[0], nums[1]);
        }

        nums[^3] += nums[^1];

        for (var i = nums.Length - 4; i >= 0; i--)
        {
            var child1 = nums[i] + nums[i + 2];
            var child2 = nums[i] + nums[i + 3];
            nums[i] = Math.Max(child1, child2);
        }

        return Math.Max(nums[0], nums[1]);
    }

    public int Rob2(int[] nums)
    {
        if (nums.Length == 0)
        {
            return 0;
        }

        var next = nums[^1];
        var nextPlusOne = 0;

        for (var i = nums.Length - 2; i >= 0; i++)
        {
            var current = nextPlusOne + nums[i];
            current = Math.Max(current, next);

            nextPlusOne = next;
            next = current;
        }

        return next;
    }
}
