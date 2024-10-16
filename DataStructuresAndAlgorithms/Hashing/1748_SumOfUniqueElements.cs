using Helpers;

namespace DataStructuresAndAlgorithms.Hashing;

internal class _1748_SumOfUniqueElements
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1([1, 2, 3, 2]);
            Test1([1, 1, 1, 1]);
            Test1([1, 2, 3, 4, 5]);
        }

        private void Test1(int[] nums)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(nums), nums));

            var result = new _1748_SumOfUniqueElements().SumOfUnique(nums);

            printTable.AddProcessedParameters(
                (nameof(nums), nums));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    public int SumOfUnique(int[] nums)
    {
        Span<int> map = stackalloc int[101];

        var sum = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            var num = nums[i];
            var count = map[num];
            if(count == 0)
            {
                sum += num;
            } 
            else if(count == 1)
            {
                sum -= num;
            }
            map[num] = count + 1;
        }

        return sum;
    }
}
