using Helpers;

namespace DataStructuresAndAlgorithms.ArrayAndStrings;

internal class _0283_MoveZero
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1([ 0, 1, 0, 3, 12 ]);
            Test1([ 0 ]);
            Test1([ 1 ]);
        }

        private void Test1(int[] nums)
        {
            var printTable = Helper.CreatePrintTable((nameof(nums), nums));

            new _0283_MoveZero().MoveZeroes(nums);

            printTable.AddProcessedParameters((nameof(nums), nums));

            Helper.PrintTable(printTable);
        }
    }

    public void MoveZeroes(int[] nums)
    {
        var leftIndex = 0;
        var rightIndex = 0;

        for (; rightIndex < nums.Length; rightIndex++)
        {
            if (nums[rightIndex] != 0)
            {
                (nums[leftIndex], nums[rightIndex]) = (nums[rightIndex], nums[leftIndex]);
                leftIndex++;
            }
        }
    }
}
