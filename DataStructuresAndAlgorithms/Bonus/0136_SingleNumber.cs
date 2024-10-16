using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.Bonus;

internal class _0136_SingleNumber
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var nums = new int[] { 4, 1, 2, 1, 2 };
            Test(nums);
        }

        private void Test(int[] nums)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(nums), JsonSerializer.Serialize(nums))
            };

            var result = new _0136_SingleNumber().SingleNumber(nums);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(nums), JsonSerializer.Serialize(nums))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int SingleNumber(int[] nums)
    {
        var value = 0;
        foreach (var num in nums)
        {
            value ^= num;
        }
        
        return value;
    }
}
