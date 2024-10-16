using Helpers;

namespace DataStructuresAndAlgorithms.ArrayAndStrings;

internal class _0209_MinimumSizeSubarraySum
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1(7, [2, 3, 1, 2, 4, 3]);
            Test1(4, [1, 4, 4]);
            Test1(11, [1, 1, 1, 1, 1, 1, 1, 1]);
        }

        private void Test1(int target, int[] nums)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(target), target),
                (nameof(nums), nums));

            var result = new _0209_MinimumSizeSubarraySum().MinSubArrayLen(target, nums);

            printTable.AddProcessedParameters(
                (nameof(target), target),
                (nameof(nums), nums));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    public int MinSubArrayLen(int target, int[] nums)
    {
        var minLenght = int.MaxValue;
        var leftIndex = 0;
        var sum = 0;

        for(var rightIndex = 0; rightIndex < nums.Length; rightIndex++)
        {
            sum += nums[rightIndex];

            while(sum >= target)
            {
                minLenght = Math.Min(minLenght, rightIndex - leftIndex + 1);
                sum -= nums[leftIndex];
                leftIndex++;
            }
        }

        return minLenght == int.MaxValue ? 0 : minLenght;
    }
}
