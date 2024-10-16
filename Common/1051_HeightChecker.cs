using Helpers;
using System.Text.Json;

namespace Common;

internal class _1051_HeightChecker
{
    internal class Tester
    {
        public void LaunchTests()
        {
            int[] heights = { 1, 1, 4, 2, 1, 3 };
            Test(heights);
        }

        private void Test(int[] heights)
        {
            // Serialize parameters before the method call
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(heights), JsonSerializer.Serialize(heights))
            };

            // Call the method to test
            var result = new _1051_HeightChecker().HeightChecker(heights);

            // Serialize parameters after the method call
            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(heights), JsonSerializer.Serialize(heights))
            };

            // Serialize the result
            var resultStr = JsonSerializer.Serialize(result);

            // Print the comparison table
            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int HeightChecker(int[] heights)
    {
        var sortedHeights = new int[heights.Length];
        heights.CopyTo(sortedHeights, 0);

        BubbleSort(sortedHeights);

        var count = 0;
        for(var i = 0; i < heights.Length; i++)
        {
            if(heights[i] != sortedHeights[i])
            {
                count++;
            }
        }
        
        return count;
    }

    private int[] BubbleSort(int[] nums)
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

        return nums;
    }

    private int[] SelectionSort(int[] nums)
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

        return nums;
    }
}
