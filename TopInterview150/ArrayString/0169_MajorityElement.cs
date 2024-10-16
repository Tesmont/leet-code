using Helpers;
using System.Text.Json;

namespace TopInterview150.ArrayString;

internal class _0169_MajorityElement
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var nums = new int[] { 3, 2, 3 };
            Test(nums);
        }

        private void Test(int[] nums)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(nums), JsonSerializer.Serialize(nums))
            };

            var result = new _0169_MajorityElement().MajorityElement(nums);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(nums), JsonSerializer.Serialize(nums))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int MajorityElement(int[] nums)
    {
        //https://en.wikipedia.org/wiki/Boyer%E2%80%93Moore_majority_vote_algorithm
        var majorityElement = nums[0];
        var frequency = 1;

        for(var i = 1; i < nums.Length; i++)
        {
            var num = nums[i];
            if(num == majorityElement)
            {
                frequency++;
            }
            else
            {
                if(frequency == 1)
                {
                    majorityElement = num;
                }
                else
                {
                    frequency--;
                }
            }
        }

        return majorityElement;
    }

    public int MajorityElement2(int[] nums)
    {
        if (nums.Length % 2 > 0)
        {
            return nums.Length / 2;
        }

        var left = nums.Length / 2;
        var right = left + 1;

        if (nums[left] == nums[right])
        {
            return nums[left];
        }

        if (nums[left - 1] == nums[left])
        {
            return nums[left];
        }

        return nums[right];
    }
}
