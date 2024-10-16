using Helpers;

namespace DataStructuresAndAlgorithms.ArrayAndStrings;

internal class _2090_KRadiusSubarrayAverages
{
    public void Launch()
    {
        Execute([7, 4, 3, 9, 1, 8, 5, 2, 6], 3);
        Execute([100000], 0);
        Execute([8], 100000);
    }

    private void Execute(int[] nums, int k)
    {
        var processedNums = (int[])nums.Clone();
        var result = GetAverages(processedNums, k);

        Helper.PrintTable([
            ("nums", nums),
            ("k", k),
            ("processedNums", processedNums),
            ("result", result),
            ]);
    }

    public int[] GetAverages(int[] nums, int k)
    {
        if (k == 0)
        {
            return nums;
        }

        var length = nums.Length;
        var windowLength = k * 2 + 1;
        int[] averages = new int[length];
        Array.Fill(averages, -1);

        if (windowLength > length)
        {
            return averages;
        }

        long windowSum = 0;
        for (var i = 0; i < windowLength; i++)
        {
            windowSum += nums[i];
        }
        averages[k] = (int) (windowSum / windowLength);

        for (var i = windowLength; i < length; i++)
        {
            windowSum = windowSum - nums[i - windowLength] + nums[i];
            averages[i - k] = (int) (windowSum / windowLength);
        }

        return averages;
    }
}
