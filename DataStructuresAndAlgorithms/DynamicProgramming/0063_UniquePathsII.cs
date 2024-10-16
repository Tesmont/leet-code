using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.DynamicProgramming;

internal class _0063_UniquePathsII
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var obstacleGrid = new int[][]
            {
                [0, 0, 0],
                [0, 1, 0],
                [0, 0, 0]
            };
            Test(obstacleGrid);
        }

        private void Test(int[][] obstacleGrid)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(obstacleGrid), JsonSerializer.Serialize(obstacleGrid))
            };

            var result = new _0063_UniquePathsII().UniquePathsWithObstacles(obstacleGrid);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(obstacleGrid), JsonSerializer.Serialize(obstacleGrid))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int UniquePathsWithObstacles(int[][] obstacleGrid)
    {   
        var m = obstacleGrid.Length;
        var n = obstacleGrid[0].Length;

        var dp = new int[n];
        dp[0] = 1;

        for (var row = 0; row < m; row++)
        {
            if (obstacleGrid[row][0] == 1)
            {
                dp[0] = 0;
            }

            for (var column = 1; column < n; column++)
            {
                if (obstacleGrid[row][column] == 1)
                {
                    dp[column] = 0;
                    continue;
                }

                dp[column] += dp[column - 1];
            }
        }

        return dp[n - 1];
    }
}
