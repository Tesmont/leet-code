using Helpers;

namespace DataStructuresAndAlgorithms.ArrayAndStrings;

internal class _0713_SubarrayProductLessThanK
{
    public void Launch()
    {
        Execute([10, 5, 2, 6], 100);
        Execute([10, 5, 2, 6, 1], 100);
        Execute([1, 2, 3], 0);
    }

    private void Execute(int[] nums, int k)
    {
        var processedNums = Helper.DeepClone(nums);
        var result = NumSubarrayProductLessThanK(processedNums, k);

        Helper.PrintTable([
            ("nums", nums),
            ("k", k),
            ("processedNums", processedNums),
            ("result", result),
            ]);
    }

    public int NumSubarrayProductLessThanK(int[] nums, int k)
    {
        if (k <= 1)
        {
            return 0;
        }

        int leftIndex = 0;
        var windowProduct = 1;
        int result = 0;

        for (int rightIndex = 0; rightIndex < nums.Length; rightIndex++)
        {
            windowProduct *= nums[rightIndex];
            while (windowProduct >= k)
            {
                windowProduct /= nums[leftIndex];
                leftIndex++;
            }

            result += rightIndex - leftIndex + 1;
        }

        return result;
    }
}
