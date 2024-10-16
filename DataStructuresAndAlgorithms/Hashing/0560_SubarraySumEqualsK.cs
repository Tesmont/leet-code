using Helpers;

namespace DataStructuresAndAlgorithms.Hashing;

internal class _0560_SubarraySumEqualsK
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1([1, 1, 1], 2);
            Test1([1, 2, 3], 3);
            Test1([3, 4, 7, 2, -3, 1, 4, 2], 7);
            Test1([1, -1, 0], 0);

            Test1([0, 0, 0, 1, 1, 1, 0, 0, 0, -1, 0, 1, 0], 3);
        }

        private void Test1(int[] nums, int k)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(nums), nums),
                (nameof(k), k));

            var result = new _0560_SubarraySumEqualsK().SubarraySum(nums, k);

            printTable.AddProcessedParameters(
                (nameof(nums), nums),
                (nameof(k), k));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    public int SubarraySum(int[] nums, int k)
    {
        var subarrayCount = 0;
        var prefixSums = new Dictionary<int, int>()
        {
            { 0, 1 }
        };

        var windowSum = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            windowSum += nums[i];
            var difference = windowSum - k;
            if (prefixSums.TryGetValue(difference, out var differencesCount))
            {
                subarrayCount += differencesCount;
            }

            prefixSums[windowSum] = prefixSums.TryGetValue(windowSum, out var windowsSumsCount) 
                ? windowsSumsCount + 1
                : 1;
        }

        return subarrayCount;
    }
}
