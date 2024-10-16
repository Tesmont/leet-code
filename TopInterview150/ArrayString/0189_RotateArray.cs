using Helpers;
using System.Text.Json;

namespace TopInterview150.ArrayString;

internal class _0189_RotateArray
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var nums = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            var k = 500;
            Test(nums, k);
        }

        private void Test(int[] nums, int k)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(nums), JsonSerializer.Serialize(nums)),
                (nameof(k), JsonSerializer.Serialize(k))
            };

            new _0189_RotateArray().Rotate(nums, k);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(nums), JsonSerializer.Serialize(nums)),
                (nameof(k), JsonSerializer.Serialize(k))
            };

            Helper.PrintTable(parameters, processedParameters);
        }
    }

    public void Rotate(int[] nums, int k)
    {
        k %= nums.Length;

        Reverse(0, nums.Length);
        Reverse(0, k);
        Reverse(k, nums.Length - k);

        void Reverse(int startIndex, int length)
        {
            var i = startIndex;
            var j = startIndex + length - 1;
            while (i < j)
            {
                var tmp = nums[i]; 
                nums[i] = nums[j];
                nums[j] = tmp;

                i++;
                j--;
            }
        }
    }

    public void Rotate2(int[] nums, int k)
    {
        k %= nums.Length;

        Array.Reverse(nums, 0, nums.Length);
        Array.Reverse(nums,0, k);
        Array.Reverse(nums, k, nums.Length - k);
    }
}
