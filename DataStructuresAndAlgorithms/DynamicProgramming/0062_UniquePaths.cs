using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.DynamicProgramming;

internal class _0062_UniquePaths
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test(3, 7);
            Test(2, 7);
        }

        private void Test(int m, int n)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(m), JsonSerializer.Serialize(m)),
                (nameof(n), JsonSerializer.Serialize(n))
            };

            var result = new _0062_UniquePaths().UniquePaths2(m, n);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(m), JsonSerializer.Serialize(m)),
                (nameof(n), JsonSerializer.Serialize(n))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    /// <summary>
    /// BFS. Out of memory
    /// </summary>
    public int UniquePaths(int m, int n)
    {
        var matrix = new int[m, n];
        (int x, int y) destinationPoint = (m - 1, n - 1);
        Span<(int xShift, int yShift)> directions = [(0, 1), (1, 0)];

        var queue = new Queue<(int x, int y)>();
        queue.Enqueue((0, 0));

        var pathCount = 1;

        while (queue.TryDequeue(out var point))
        {
            if(point == destinationPoint)
            {
                continue;
            }

            var count = 0;
            foreach (var direction in directions) 
            { 
                var newX = point.x + direction.xShift;
                var newY = point.y + direction.yShift;

                if(newX == m
                    || newY == n)
                {
                    continue;
                }

                count++;
                queue.Enqueue((newX, newY));
            }

            if(count == 2)
            {
                pathCount++;
            }
        }
        
        return pathCount;
    }

    public int UniquePaths2(int m, int n)
    {
        Span<int> dp = new int[n];
        dp.Fill(1);

        for (var row = 1; row < m; row++)
        {
            for(var column = 1; column < n; column++)
            {
                dp[column] += dp[column - 1];
            }
        }

        return dp[n - 1];
    }
}
