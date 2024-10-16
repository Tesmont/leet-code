using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.TreesAndGraphs.Graphs.BFS;

internal class _1293_ShortestPathInGridWithObstaclesElimination
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var grid1 = new int[][]
            {
                [0, 0, 0],
                [1, 1, 0],
                [0, 0, 0],
                [0, 1, 1],
                [0, 0, 0]
            };

            Test1(grid1, 1);
        }

        private void Test1(int[][] grid, int k)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(grid), Environment.NewLine + GraphHelper.ConvertGridToString(grid)),
                (nameof(k), k.ToString())
            };

            var result = new _1293_ShortestPathInGridWithObstaclesElimination().ShortestPath(grid, k);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(grid), Environment.NewLine + GraphHelper.ConvertGridToString(grid)),
                (nameof(k), k.ToString())
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int ShortestPath(int[][] grid, int k)
    {
        var sourceRow = 0;
        var sourceColumn = 0;
        var destinationRow = grid.Length - 1;
        var destinationColumn = grid[destinationRow].Length - 1;

        if (destinationRow == sourceRow
            && destinationColumn == sourceColumn)
        {
            return 0;
        }

        var directions = new (int Row, int Column)[]
        {
            (-1, 0),    //Top
            (1, 0),     //Bottom
            (0, -1),    //Left
            (0, 1),     //Right
        };

        //Contains passed obstacle count
        var cellStates = new int[grid.Length][];
        for (var i = 0; i < grid.Length; i++)
        {
            cellStates[i] = new int[grid[i].Length];
            Array.Fill(cellStates[i], k + 1);
        }

        var queue = new Queue<(int Row, int Column, int ObstaclesPassed)>();
        queue.Enqueue((sourceRow, sourceColumn, 0));
        cellStates[sourceRow][sourceColumn] = 0;

        var level = 0;
        while (queue.Count > 0)
        {
            var cellCount = queue.Count;

            for (var i = 0; i < cellCount; i++)
            {
                var cell = queue.Dequeue();
                if (cell.Row == destinationRow
                    && cell.Column == destinationColumn)
                {
                    //grid[destinationRow][destinationColumn] = 0
                    return level;
                }

                for (var j = 0; j < directions.Length; j++)
                {
                    var direction = directions[j];

                    var newRow = cell.Row + direction.Row;
                    var newColumn = cell.Column + direction.Column;

                    if (newRow < 0
                        || newColumn < 0
                        || newRow >= grid.Length
                        || newColumn >= grid[newRow].Length)
                    {
                        continue;
                    }

                    var newObstaclesPassed = cell.ObstaclesPassed + grid[newRow][newColumn];
                    //We passed this cell with less obstacles before.
                    if (newObstaclesPassed >= cellStates[newRow][newColumn])
                    {
                        continue;
                    }

                    cellStates[newRow][newColumn] = newObstaclesPassed;
                    queue.Enqueue((newRow, newColumn, newObstaclesPassed));
                }
            }

            level++;
        }

        return -1;
    }
}
