using Helpers;
using System.Text.Json;
using System.Xml;

namespace TopInterview150.ArrayString;

internal class _0080_RemoveDuplicatesFromSortedArrayII
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var nums = new int[] { 1, 1, 1, 2, 2, 3 };
            Test(nums);
        }

        private void Test(int[] nums)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(nums), JsonSerializer.Serialize(nums))
            };

            var result = new _0080_RemoveDuplicatesFromSortedArrayII().RemoveDuplicates(nums);

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
        if (nums.Length < 3)
        {
            return nums.Length;
        }

        var insertIndex = 2;
        for(var i = 2; i < nums.Length; i++)
        {
            var num1 = nums[i];
            var num2 = nums[insertIndex - 2];

            if (num1 == num2)
            {
                continue;
            }

            nums[insertIndex++] = num1;
        }

        return insertIndex;
    }
}
