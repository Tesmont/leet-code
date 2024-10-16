using Helpers;

namespace DataStructuresAndAlgorithms.Hashing;

internal class _1133_LargestUniqueNumber
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1([5, 7, 3, 9, 4, 9, 8, 3, 1]);
            Test1([9, 9, 8, 8]);
        }

        private void Test1(int[] nums)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(nums), nums));

            var result = new _1133_LargestUniqueNumber().LargestUniqueNumber(nums);

            printTable.AddProcessedParameters(
                (nameof(nums), nums));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    public int LargestUniqueNumber(int[] nums)
    {
        var numsMap = new Dictionary<int, int>();

        for(var i = 0; i < nums.Length; i++)
        {
            var num = nums[i];
            numsMap[num] = numsMap.TryGetValue(num, out var mapValue)
                ? mapValue + 1
                : 1;
        }

        var maxNum = -1;
        foreach(var kvp in numsMap) 
        {
            if(kvp.Value != 1)
            {
                continue;
            }

            maxNum = Math.Max(maxNum, kvp.Key);
        }

        return maxNum;
    }
}

