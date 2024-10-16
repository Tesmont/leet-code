using Helpers;

namespace DataStructuresAndAlgorithms.Hashing;

internal class _3005_CountElementsWithMaximumFrequency
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1([1, 2, 2, 3, 1, 4]);
            Test1([1, 2, 3, 4, 5 ]);
            Test1([1, 3, 2, 2, 1, 3, 3]);
            Test1([4, 4, 4, 1, 2, 2]);
            Test1([5, 5, 5, 5, 5, 5]);
        }

        private void Test1(int[] nums)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(nums), nums));

            var result = new _3005_CountElementsWithMaximumFrequency().MaxFrequencyElements(nums);

            printTable.AddProcessedParameters(
                (nameof(nums), nums));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    public int MaxFrequencyElements(int[] nums)
    {
        Span<int> map = stackalloc int[101];

        var maxFrequency = 0;
        var maxFrequencyCount = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            var value = nums[i];
            var frequency = map[value] + 1;
            map[value] = frequency;

            if (frequency > maxFrequency)
            {
                maxFrequency = frequency;
                maxFrequencyCount = frequency;
            }
            else if (frequency == maxFrequency)
            {
                maxFrequencyCount += frequency;
            }
        }

        return maxFrequencyCount;
    }
}
