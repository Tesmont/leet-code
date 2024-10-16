using Helpers;
using System.Text.Json;

namespace TopInterview150.ArrayString;

internal class _0026_RemoveDuplicatesFromSortedArray
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var nums = new int[] { 1, 1, 2 };
            Test(nums);
        }

        private void Test(int[] nums)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(nums), JsonSerializer.Serialize(nums))
            };

            var result = new _0026_RemoveDuplicatesFromSortedArray().RemoveDuplicates(nums);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(nums), JsonSerializer.Serialize(nums))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int RemoveDuplicates(int[] nums)
    {
        var shift = 0;
        var currentValue = nums[0];

        for(var i = 1; i < nums.Length; i++)
        {
            var num = nums[i];
            if(num == currentValue)
            {
                shift++;
                continue;
            }

            currentValue = num;
            nums[i - shift] = num;
        }

        return nums.Length - shift;
    }

    public int RemoveDuplicates2(int[] nums)
    {
        var lastUniqueIndex = 0;

        for (var i = 1; i < nums.Length; i++)
        {
            var num1 = nums[i];
            var num2 = nums[lastUniqueIndex];
            if (num1 == num2)
            {
                continue;
            }

            lastUniqueIndex++;
            nums[lastUniqueIndex] = num1;
        }

        return lastUniqueIndex + 1;
    }
}
