using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.DynamicProgramming;

internal class _0064_MinimumPathSum
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var grid = new int[][]
            {
                [1, 3, 1],
                [1, 5, 1],
                [4, 2, 1]
            };
            Test(grid);

            Test(
            [
                [1, 2, 3],
                [4, 5, 6]
            ]);
        }

        private void Test(int[][] grid)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(grid), JsonSerializer.Serialize(grid))
            };

            var result = new _0064_MinimumPathSum().MinPathSum(grid);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(grid), JsonSerializer.Serialize(grid))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int MinPathSum(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;

        Span<int> dp = new int[n];
        dp.Slice(1).Fill(int.MaxValue);

        for (var row = 0; row < m; row++)
        {
            dp[0] = dp[0] + grid[row][0];

            for (var column = 1; column < n; column++)
            {
                var minPath = Math.Min(dp[column], dp[column - 1]);
                dp[column] = minPath + grid[row][column];
            }
        }

        return dp[n - 1];
    }
}
