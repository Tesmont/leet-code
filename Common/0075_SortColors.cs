using Helpers;
using System.Text.Json;

namespace Common;

internal class _0075_SortColors
{
    internal class Tester
    {
        public void LaunchTests()
        {
            int[] nums = { 2, 0, 2, 1, 1, 0 };
            Test(nums);
        }

        private void Test(int[] nums)
        {
            // Serialize parameters before the method call
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(nums), JsonSerializer.Serialize(nums))
            };

            // Call the method to test
            new _0075_SortColors().SortColors(nums);

            // Serialize parameters after the method call
            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(nums), JsonSerializer.Serialize(nums))
            };

            // As SortColors is void, there is no result value to serialize
            var resultStr = "void";

            // Print the comparison table
            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public void SortColors(int[] nums)
    {
        SelectionSort(nums);
    }

    private void BubbleSort(int[] nums)
    {
        for (var i = 0; i < nums.Length; i++)
        {
            for (var j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] <= nums[j])
                {
                    continue;
                }

                var tmp = nums[i];
                nums[i] = nums[j];
                nums[j] = tmp;
            }
        }
    }

    private void SelectionSort(int[] nums)
    {
        for (var i = 0; i < nums.Length; i++)
        {
            var minIndex = i;
            for (var j = i + 1; j < nums.Length; j++)
            {
                if (nums[j] < nums[minIndex])
                {
                    minIndex = j;
                }
            }

            var tmp = nums[i];
            nums[i] = nums[minIndex];
            nums[minIndex] = tmp;
        }
    }
}
