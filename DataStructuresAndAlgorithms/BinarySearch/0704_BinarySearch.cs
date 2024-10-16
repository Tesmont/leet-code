using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.BinarySearch;

internal class _0704_BinarySearch
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var nums = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var target = 1;
            Test(nums, target);
        }

        private void Test(int[] nums, int target)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(nums), JsonSerializer.Serialize(nums)),
                (nameof(target), JsonSerializer.Serialize(target))
            };

            var result = new _0704_BinarySearch().Search(nums, target);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(nums), JsonSerializer.Serialize(nums)),
                (nameof(target), JsonSerializer.Serialize(target))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int Search(int[] nums, int target)
    {
        var left = 0L;
        var right = nums.LongLength - 1;

        while (left <= right)
        {
            var mid = (left + right) / 2;

            if (nums[mid] == target)
            {
                return (int)mid;
            }

            if (nums[mid] > target)
            {
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }

        return -1;
    }

    /// <summary>
    /// Lower bound
    /// </summary>
    public int Search2(int[] nums, int target)
    {
        if (nums.Length == 0)
        {
            return -1;
        }

        var left = 0L;
        var right = nums.LongLength - 1;

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

        if (nums[left] == target)
        {
            return (int)left;
        }
        else
        {
            return -1;
        }
    }
}
