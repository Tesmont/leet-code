using DataStructuresAndAlgorithms.ArrayAndStrings;
using Helpers;
using System.Net.Http.Headers;

namespace DataStructuresAndAlgorithms.Hashing;

internal class _0525_ContiguousArray
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1([0, 1]);
            Test1([0, 1, 0]);
            Test1([0, 0, 1, 1, 0, 1]);
        }

        private void Test1(int[] nums)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(nums), nums));

            var result = new _0525_ContiguousArray().FindMaxLength(nums);

            printTable.AddProcessedParameters(
                (nameof(nums), nums));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    public int FindMaxLength(int[] nums)
    {
        var map = new Dictionary<int, int>()
        {
            { 0, -1 }
        };

        var maxlength = 0;
        var sum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            var value = nums[i] == 1 ? 1 : -1;
            sum = sum + value;
            if (map.ContainsKey(sum))
            {
                maxlength = Math.Max(maxlength, map[sum] - i);
            }
            else
            {
                map[sum] = i;
            }
        }
        return maxlength;
    }
}
