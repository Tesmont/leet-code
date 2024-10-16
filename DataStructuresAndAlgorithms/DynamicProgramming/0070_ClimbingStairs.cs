using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.DynamicProgramming;

internal class _0070_ClimbingStairs
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test(2);
            Test(3);
            Test(4);
            Test(5);
            Test(6);
        }

        private void Test(int n)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(n), JsonSerializer.Serialize(n))
            };

            var result = new _0070_ClimbingStairs().ClimbStairs(n);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(n), JsonSerializer.Serialize(n))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int ClimbStairs(int n)
    {
        var next = 1;
        var nextPlusOne = 0;

        for(var i = 0; i < n; i++)
        {
            var current = next + nextPlusOne;
            nextPlusOne = next;
            next = current;
        }

        return next;
    }
}
