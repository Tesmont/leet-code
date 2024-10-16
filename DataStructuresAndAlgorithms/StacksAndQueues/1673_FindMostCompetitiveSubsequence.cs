using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.StacksAndQueues;

internal class _1673_FindMostCompetitiveSubsequence
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1([71, 18, 52, 29, 55, 73, 24, 42, 66, 8, 80, 2], 3);
            Test1([4, 3, 2, 1], 2);

            Test1([3, 5, 2, 6], 2);
            Test1([2, 4, 3, 3, 5, 4, 9, 6], 4);
            Test1([1, 2, 3, 4, 5], 3);
        }

        private void Test1(int[] nums, int k)
        {
            List<(string Name, string? Value)> parameters =
            [
                (nameof(nums), JsonSerializer.Serialize(nums)),
                (nameof(k), k.ToString())
            ];

            var result = new _1673_FindMostCompetitiveSubsequence().MostCompetitive3(nums, k);

            List<(string Name, string? Value)> processedParameters =
            [
                (nameof(nums), JsonSerializer.Serialize(nums)),
                (nameof(k), k.ToString())
            ];

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    //Time: O(n) Space: O(n)
    public int[] MostCompetitive(int[] nums, int k)
    {
        var increasingStack = new int[nums.Length];
        var stackLength = 0;
        var availableRemovingCount = nums.Length - k;

        for (var i = 0; i < nums.Length; i++)
        {
            var num = nums[i];
            while(stackLength > 0
                && increasingStack[stackLength - 1] > num
                && availableRemovingCount > 0)
            {
                stackLength--;
                availableRemovingCount--;
            }

            increasingStack[stackLength] = num;
            stackLength++;
        }

        return increasingStack.AsSpan().Slice(0, k).ToArray();
    }

    //Time: O(n) Space: O(k)
    public int[] MostCompetitive2(int[] nums, int k)
    {
        var increasingStack = new int[k];
        var stackLength = 0;
        var availableRemovingCount = nums.Length - k;

        for (var i = 0; i < nums.Length; i++)
        {
            var num = nums[i];
            while (stackLength > 0
                && increasingStack[stackLength - 1] > num
                && availableRemovingCount > 0)
            {
                stackLength--;
                availableRemovingCount--;
            }

            if(stackLength == k)
            {
                availableRemovingCount--;
                continue;
            }

            increasingStack[stackLength] = num;
            stackLength++;
        }

        return increasingStack.AsSpan().Slice(0, k).ToArray();
    }

    //Time: O(n) Space: O(1)
    public int[] MostCompetitive3(int[] nums, int k)
    {
        var stackLength = 1;
        var availableRemovingCount = nums.Length - k;

        for (var i = 1; i < nums.Length; i++)
        {
            var num = nums[i];
            while (stackLength > 0
                && nums[stackLength - 1] > num
                && availableRemovingCount > 0)
            {
                stackLength--;
                availableRemovingCount--;
            }

            nums[stackLength] = num;
            stackLength++;
        }

        return nums.AsSpan()[..k].ToArray();
    }
}
