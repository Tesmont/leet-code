using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.DynamicProgramming;

internal class _0746_MinCostClimbingStairs
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var cost = new int[] { 10, 15, 20 };
            Test(cost);
        }

        private void Test(int[] cost)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(cost), JsonSerializer.Serialize(cost))
            };

            var result = new _0746_MinCostClimbingStairs().MinCostClimbingStairs2(cost);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(cost), JsonSerializer.Serialize(cost))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int MinCostClimbingStairs(int[] cost)
    {
        for (var i = 3; i <= cost.Length; i++)
        {
            var sum1 = cost[^i] + cost[^(i - 1)];
            var sum2 = cost[^i] + cost[^(i - 2)];
            cost[^i] = Math.Min(sum1, sum2);
        }

        return Math.Min(cost[0], cost[1]);
    }

    public int MinCostClimbingStairs2(int[] cost)
    {
        var next = cost[^1];
        var nextPlusOne = 0;

        for (var i = 2; i <= cost.Length; i++)
        {
            var current = Math.Min(next, nextPlusOne);
            current += cost[^i];

            nextPlusOne = next;
            next = current;
        }

        return Math.Min(next, nextPlusOne);
    }
}
