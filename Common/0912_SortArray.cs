using Helpers;
using System.Text.Json;

namespace Common;

internal class _0912_SortArray
{
    internal class Tester
    {
        public void LaunchTests()
        {
            int[] nums = { 5, 2, 9, 1, 5, 6 };
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
            var result = new _0912_SortArray().SortArray(nums);

            // Serialize parameters after the method call
            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(nums), JsonSerializer.Serialize(nums))
            };

            // Serialize the result
            var resultStr = JsonSerializer.Serialize(result);

            // Print the comparison table
            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int[] SortArray(int[] nums)
    {
        return SelectionSort(nums);
    }

    private int[] BubbleSort(int[] nums)
    {
        for(var i = 0; i < nums.Length; i++)
        {
            for(var j = i + 1; j < nums.Length; j++)
            {
                if(nums[i] <= nums[j])
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
        for(var i = 0; i < nums.Length; i++)
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

    private int[] CountingSort(int[] nums)
    {
        const int shift = 5 * 100_000;
        Span<int> counting = stackalloc int[2 * shift + 1];
        for (var i = 0; i < nums.Length; i++)
        {
            counting[nums[i] + shift]++;
        }

        var numsIndex = 0;
        for (var i = 0; i < counting.Length && numsIndex < nums.Length; i++)
        {
            if (counting[i] == 0)
            {
                continue;
            }

            var value = i - shift;
            for(var j = counting[i]; j > 0; j--)
            {
                nums[numsIndex] = value;
                numsIndex++;
            }
        }

        return nums;
    }
}
