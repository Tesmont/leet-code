using Helpers;

namespace DataStructuresAndAlgorithms.Hashing;

internal class _0930_BinarySubarraysWithSum
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1([1, 0, 1, 0, 1], 2);
            Test1([0, 0, 0, 0, 0], 0);
            Test1([0, 0, 0, 0, 1], 2);
            Test1([0, 1, 1, 1, 1], 3);
        }

        private void Test1(int[] nums, int goal)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(nums), nums),
                (nameof(goal), goal));

            var result = new _0930_BinarySubarraysWithSum().NumSubarraysWithSumV2(nums, goal);

            printTable.AddProcessedParameters(
                (nameof(nums), nums),
                (nameof(goal), goal));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    public int NumSubarraysWithSum(int[] nums, int goal)
    {
        var map = new Dictionary<int, int>()
        {
            { 0, 1 }
        };

        var subarrayCount = 0;
        var sum = 0;
        for(var i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
            var difference = sum - goal;
            if (map.TryGetValue(difference, out var frequency))
            {
                subarrayCount += frequency;
            }

            map[sum] = map.TryGetValue(sum, out frequency) ? frequency + 1 : 1;
        }

        return subarrayCount;
    }

    public int NumSubarraysWithSumV2(int[] nums, int goal)
    { 
        return NumSubarraysWithSumLess(nums, goal) - NumSubarraysWithSumLess(nums, goal - 1);
    }

    private int NumSubarraysWithSumLess(int[] nums, int goal)
    {
        var leftIndex = 0;
        var rightIndex = 0;
        var subarrayCount = 0;
        var sum = 0;
        for(; rightIndex < nums.Length; rightIndex++)
        {
            sum += nums[rightIndex];

            while (leftIndex <= rightIndex && sum > goal)
            {
                sum -= nums[leftIndex];
                leftIndex++;
            }

            subarrayCount += rightIndex - leftIndex + 1;
        }

        return subarrayCount;
    }
}
