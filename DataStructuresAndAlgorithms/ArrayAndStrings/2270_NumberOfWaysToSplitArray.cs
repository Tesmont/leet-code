using Helpers;

namespace DataStructuresAndAlgorithms.ArrayAndStrings;

internal class _2270_NumberOfWaysToSplitArray
{
    public void Launch()
    {
        Execute([10, 4, -8, 7]);
        Execute([2, 3, 1, 0]);
    }

    private void Execute(int[] nums)
    {
        var processedNums = Helper.DeepClone(nums);
        var result = WaysToSplitArray(nums);

        Helper.PrintTable([
            ("nums", nums),
            ("processedNums", processedNums),
            ("result", result),
            ]);
    }

    public int WaysToSplitArray(int[] nums)
    {
        long lastSum = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            lastSum += nums[i];
        }

        var counts = 0;
        long leftSum = 0;
        for (var i = 0; i < nums.Length - 1; i++)
        {
            leftSum += nums[i];
            var rightSum = lastSum - leftSum;
            if (leftSum >= rightSum)
            {
                counts++;
            }
        }

        return counts;
    }
}
