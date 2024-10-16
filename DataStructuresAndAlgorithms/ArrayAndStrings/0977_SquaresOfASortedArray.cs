using Helpers;

namespace DataStructuresAndAlgorithms.ArrayAndStrings;

internal class _0977_SquaresOfASortedArray
{
    public void Launch()
    {
        Execute([-4, -1, 0, 3, 10]);
        Execute([-7, -3, 2, 3, 11]);
        Execute([-5, -3, -2, -1]);
    }

    private void Execute(int[] nums)
    {
        var processedNums = Helper.DeepClone(nums);
        var result = SortedSquaresV2(processedNums);

        Helper.PrintTable([
            ("nums", nums),
            ("processedNums", processedNums),
            ("result", result),
            ]);
    }

    public int[] SortedSquaresV1(int[] nums)
    {
        var lenght = nums.Length;
        var leftIndex = 0;
        var rightIndex = lenght - 1;

        var result = new int[lenght];
        for (var i = lenght - 1; i >= 0; i--)
        {
            var leftValue = Math.Abs(nums[leftIndex]);
            var rightValue = Math.Abs(nums[rightIndex]);
            if (leftValue < rightValue)
            {
                result[i] = rightValue * rightValue;
                rightIndex--;
            }
            else
            {
                result[i] = leftValue * leftValue;
                leftIndex++;
            }
        }

        return result;
    }

    public int[] SortedSquaresV2(int[] nums)
    {
        var lenght = nums.Length;
        var leftIndex = 0;
        var rightIndex = lenght - 1;

        var result = new int[lenght];
        for (var i = lenght - 1; i >= 0; i--)
        {
            var leftValue = nums[leftIndex] * nums[leftIndex];
            var rightValue = nums[rightIndex] * nums[rightIndex];
            if (leftValue < rightValue)
            {
                result[i] = rightValue;
                rightIndex--;
            }
            else
            {
                result[i] = leftValue;
                leftIndex++;
            }
        }

        return result;
    }
}
