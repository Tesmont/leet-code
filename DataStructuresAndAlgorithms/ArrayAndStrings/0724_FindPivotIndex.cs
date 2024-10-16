using Helpers;

namespace DataStructuresAndAlgorithms.ArrayAndStrings;

internal class _0724_FindPivotIndex
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1([1, 7, 3, 6, 5, 6]);
            Test1([1, 2, 3]);
            Test1([2, 1, -1]);

            Test1([-1, -1, 0, 0, -1, -1]);
        }

        private void Test1(int[] nums)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(nums), nums));

            var result = new _0724_FindPivotIndex().PivotIndex(nums);

            printTable.AddProcessedParameters(
                (nameof(nums), nums));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    public int PivotIndex(int[] nums)
    {
        var totalSum = 0;
        for(var i = 0; i < nums.Length; i++)
        {
            totalSum += nums[i];
        }

        var leftSum = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            var rightSum = totalSum - leftSum - nums[i];
            if (leftSum == rightSum)
            {
                return i;
            }

            leftSum += nums[i];
        }

        return -1;
    }
}

