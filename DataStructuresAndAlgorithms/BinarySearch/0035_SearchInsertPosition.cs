using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.BinarySearch;

internal class _0035_SearchInsertPosition
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var nums = new int[] { };
            var target = 5;
            Test(nums, target);
        }

        private void Test(int[] nums, int target)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(nums), JsonSerializer.Serialize(nums)),
                (nameof(target), JsonSerializer.Serialize(target))
            };

            var result = new _0035_SearchInsertPosition().SearchInsert(nums, target);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(nums), JsonSerializer.Serialize(nums)),
                (nameof(target), JsonSerializer.Serialize(target))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int SearchInsert(int[] nums, int target)
    {
        Array.Sort(nums);

        var left = 0L;
        var right = nums.LongLength;

        while (left < right)
        {
            var mid = (left + right) / 2;
            if (nums[mid] >= target)
            {
                right = mid;
            }
            else
            {
                left = mid + 1;
            }
        }


        return (int)left;
    }
}
