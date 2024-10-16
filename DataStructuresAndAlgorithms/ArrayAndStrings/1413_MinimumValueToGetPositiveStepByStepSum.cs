using Helpers;

namespace DataStructuresAndAlgorithms.ArrayAndStrings;

internal class _1413_MinimumValueToGetPositiveStepByStepSum
{
    public void Launch()
    {
        Execute([-3, 2, -3, 4, 2]);
        Execute([1, 2]);
        Execute([1, -2, -3]);
        Execute([2, 3, 4, 6]);
    }

    private void Execute(int[] nums)
    {
        var processedNums = (int[])nums.Clone();
        var result = MinStartValue(processedNums);

        Helper.PrintTable([
            ("nums", nums),
            ("processedNums", processedNums),
            ("result", result),
            ]);
    }

    public int MinStartValue(int[] nums)
    {
        var sum = 0;
        var minSum = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
            minSum = Math.Min(minSum, sum);
        }

        return -minSum + 1;
    }
}
