using Helpers;

namespace DataStructuresAndAlgorithms.ArrayAndStrings;

internal class _0643_MaximumAverageSubarrayI
{
    public void Launch()
    {
        Execute([1, 12, -5, -6, 50, 3], 4);
        Execute([5], 1);
    }

    private void Execute(int[] nums, int k)
    {
        var processedNums = Helper.DeepClone(nums);
        var result = FindMaxAverage(processedNums, k);

        Helper.PrintTable([
            ("nums", nums),
            ("k", k),
            ("processedNums", processedNums),
            ("result", result),
            ]);
    }

    public double FindMaxAverage(int[] nums, int k)
    {
        var currentSum = 0;
        for(var i = 0; i < k; i++)
        {
            currentSum += nums[i];
        }

        var maxSum = currentSum;
        for (var i = k; i < nums.Length; i++)
        {
            currentSum += nums[i] - nums[i - k];
            maxSum = Math.Max(maxSum, currentSum);
        }

        var maxAvg = maxSum / (double)k;

        return maxAvg;
    }
}
