using Helpers;

namespace DataStructuresAndAlgorithms.ArrayAndStrings;

internal class _1004_MaxConsecutiveOnesIII
{
    public void Launch()
    {
        Execute([1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0], 2);
        Execute([0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1], 3);
    }

    private void Execute(int[] nums, int k)
    {
        var processedNums = Helper.DeepClone(nums);
        var result = LongestOnes(processedNums, k);

        Helper.PrintTable([
            ("nums", nums),
            ("k", k),
            ("processedNums", processedNums),
            ("result", result),
            ]);
    }

    public int LongestOnes(int[] nums, int k)
    {
        var leftIndex = 0;
        var rightIndex = 0;

        for (; rightIndex < nums.Length; rightIndex++)
        {
            if (nums[rightIndex] == 0)
            {
                k--;
            }

            if (k < 0)
            {
                k += 1 - nums[leftIndex];
                leftIndex++;
            }
        }

        var windowLenght = rightIndex - leftIndex;

        return windowLenght;
    }
}
