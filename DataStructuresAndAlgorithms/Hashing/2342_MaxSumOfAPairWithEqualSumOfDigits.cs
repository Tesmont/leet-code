using Helpers;

namespace DataStructuresAndAlgorithms.Hashing;

internal class _2342_MaxSumOfAPairWithEqualSumOfDigits
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1([18, 43, 36, 13, 7]);
            Test1([10, 12, 19, 14]);
            Test1([51, 71, 17, 42]);
            Test1([42, 33, 60]);
        }

        private void Test1(int[] nums)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(nums), nums));

            var result = new _2342_MaxSumOfAPairWithEqualSumOfDigits().MaximumSum(nums);

            printTable.AddProcessedParameters(
                (nameof(nums), nums));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    public int MaximumSum(int[] nums)
    {
        var map = new Dictionary<int, int>();

        var maxSum = -1;
        for (var i = 0; i < nums.Length; i++)
        {
            var currentNum = nums[i];
            var key = GetDigitSum(currentNum);
            if (map.TryGetValue(key, out var maxNum))
            {
                maxSum = Math.Max(maxSum, currentNum + maxNum);
                if (currentNum > maxNum)
                {
                    map[key] = currentNum;

                }
            }
            else
            {
                map[key] = currentNum;
            }
        }

        return maxSum;
    }

    private int GetDigitSum(int num)
    {
        int digitSum = 0;
        while (num > 0)
        {
            digitSum += num % 10;
            num /= 10;
        }

        return digitSum;
    }
}
