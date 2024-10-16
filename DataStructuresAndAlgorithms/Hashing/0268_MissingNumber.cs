using Helpers;

namespace DataStructuresAndAlgorithms.Hashing;

internal class _0268_MissingNumber
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1([3, 0, 1]);
            Test1([0, 1]);
            Test1([9, 6, 4, 2, 3, 5, 7, 0, 1]);
        }

        private void Test1(int[] nums)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(nums), nums));

            var result = new _0268_MissingNumber().MissingNumberV2(nums);

            printTable.AddProcessedParameters(
                (nameof(nums), nums));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    public int MissingNumber(int[] nums)
    {
        var length = nums.Length;
        var flags = new bool[length + 1];

        for (var i = 0; i < length; i++)
        {
            flags[nums[i]] = true;
        }

        for (var i = 0; i <= length; i++)
        {
            if (!flags[i])
            {
                return i;
            }
        }

        return -1;
    }

    public int MissingNumberV2(int[] nums)
    {
        var length = nums.Length;
        var expectedSum = length * (length + 1) / 2;
        var calculatedSum = 0;
        for (var i = 0; i < length; i++)
        {
            calculatedSum += nums[i];
        }

        return expectedSum - calculatedSum;
    }
}

