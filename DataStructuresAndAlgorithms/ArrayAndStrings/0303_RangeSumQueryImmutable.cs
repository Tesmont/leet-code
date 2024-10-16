using Helpers;

namespace DataStructuresAndAlgorithms.ArrayAndStrings;

internal class _0303_RangeSumQueryImmutable
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1([-2, 0, 3, -5, 2, -1], 0, 2);
            Test1([-2, 0, 3, -5, 2, -1], 2, 5);
            Test1([-2, 0, 3, -5, 2, -1], 0, 5);
        }

        private void Test1(int[] nums, int left, int right)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(nums), nums),
                (nameof(left), left),
                (nameof(right), right));

            var numArray = new _0303_RangeSumQueryImmutable(nums);
            var result = numArray.SumRange(left, right);

            printTable.AddProcessedParameters(
                (nameof(nums), nums),
                (nameof(left), left),
                (nameof(right), right));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    private readonly int[] _prefixSums;

    public _0303_RangeSumQueryImmutable(int[] nums)
    {
        _prefixSums = new int[nums.Length + 1];
        var sum = 0;
        for(var i  = 0; i < nums.Length; i++)
        {
            sum += nums[i];
            _prefixSums[i + 1] = sum;
        }
    }

    public int SumRange(int left, int right)
    {
        return _prefixSums[right + 1] - _prefixSums[left];
    }
}

