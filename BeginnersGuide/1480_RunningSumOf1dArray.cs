using Helpers;

namespace Common;

internal class _1480_RunningSumOf1dArray
{
    public void Launch()
    {
        Execute([1, 2, 3, 4]);
        Execute([1, 1, 1, 1, 1]);
        Execute([3, 1, 2, 10, 1]);
    }

    private void Execute(int[] nums)
    {
        var processedNums = (int[])nums.Clone();
        var result = RunningSum(processedNums);

        Helper.PrintTable([
            ("nums", nums),
            ("processedNums", processedNums),
            ("result", result),
            ]);
    }

    public int[] RunningSum(int[] nums)
    {
        var lenght = nums.Length;
        var sum = nums[0];
        for (var i = 1; i < lenght; i++)
        {
            sum += nums[i];
            nums[i] = sum;
        }

        return nums;
    }
}
