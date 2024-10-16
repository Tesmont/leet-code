using Helpers;
using System.Text.Json;

namespace TopInterview150.ArrayString;

internal class _0027_RemoveElement
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var nums = new int[] { 3, 2, 2, 3 };
            var val = 3;
            Test(nums, val);
        }

        private void Test(int[] nums, int val)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(nums), JsonSerializer.Serialize(nums)),
                (nameof(val), JsonSerializer.Serialize(val))
            };

            var result = new _0027_RemoveElement().RemoveElement(nums, val);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(nums), JsonSerializer.Serialize(nums)),
                (nameof(val), JsonSerializer.Serialize(val))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int RemoveElement(int[] nums, int val)
    {
        var shift = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            var num = nums[i];
            if(num == val) 
            { 
                shift++;
                continue;
            }

            nums[i - shift] = num;
        }

        return nums.Length - shift;
    }

    public int RemoveElement2(int[] nums, int val)
    {
        var left = 0;
        var lenght = nums.Length;
        while (left < lenght)
        {
            var leftNum = nums[left];
            if(leftNum == val)
            {
                nums[left] = nums[lenght - 1];
                lenght--;
            }
            else
            {
                left++;
            }
        }

        return lenght;
    }
}
