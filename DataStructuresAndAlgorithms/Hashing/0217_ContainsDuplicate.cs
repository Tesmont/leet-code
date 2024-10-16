using Helpers;

namespace DataStructuresAndAlgorithms.Hashing;

internal class _0217_ContainsDuplicate
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1([1, 2, 3, 1]);
            Test1([1, 2, 3, 4]);
            Test1([1, 1, 1, 3, 3, 4, 3, 2, 4, 2]);
        }

        private void Test1(int[] nums)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(nums), nums));

            var result = new _0217_ContainsDuplicate().ContainsDuplicate(nums);

            printTable.AddProcessedParameters(
                (nameof(nums), nums));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    public bool ContainsDuplicate(int[] nums)
    {
        var map = new HashSet<int>();
        for(var i = 0; i < nums.Length; i++)
        {
            if(!map.Add(nums[i]))
            {
                return true;
            }
        }

        return false;
    }
}
