using Helpers;
using System.Data;

namespace DataStructuresAndAlgorithms.Hashing;

internal class _1512_NumberOfGoodPairs
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1([1, 2, 3, 1, 1, 3]);
            Test1([1, 1, 1, 1]);
            Test1([1, 2, 3]);
        }

        private void Test1(int[] nums)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(nums), nums));

            var result = new _1512_NumberOfGoodPairs().NumIdenticalPairs(nums);

            printTable.AddProcessedParameters(
                (nameof(nums), nums));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    public int NumIdenticalPairs(int[] nums)
    {
        var map = new Dictionary<int, int>();
        var goodPairCount = 0;

        for(var i = 0; i < nums.Length; i++)
        {
            var num = nums[i];
            if(!map.TryGetValue(num, out var frequency))
            {
                map[num] = 1;
                continue;
            }

            goodPairCount += frequency;
            map[num] = frequency + 1;
        }

        return goodPairCount;
    }

    public int NumIdenticalPairsV2(int[] nums)
    {
        Span<int> map = stackalloc int[101];
        var goodPairCount = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            var num = nums[i];
            var frequency = map[num];
            goodPairCount += frequency;
            map[num] = frequency + 1;
        }

        return goodPairCount;
    }
}
