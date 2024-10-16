using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.TreesAndGraphs.Graphs.BFS;

internal class _1091_ShortestPathInBinaryMatrix
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var grid1 = new int[][]
            {
                [0, 1, 1],
                [1, 0, 1],
                [1, 1, 0]
            };

            var grid2 = new int[][]
            {
                [0,0,0],
                [1,1,0],
                [1,1,0]
            };

            var grid3 = new int[][]
            {
                [1,0,0],
                [1,1,0],
                [1,1,0]
            };

            //Test1(grid1);
            //Test1(grid2);
            Test1(grid3);
        }

        private void Test1(int[][] grid)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(grid), Environment.NewLine + GraphHelper.ConvertGridToString(grid))
            };

            var result = new _1091_ShortestPathInBinaryMatrix().ShortestPathBinaryMatrix(grid);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(grid), Environment.NewLine + GraphHelper.ConvertGridToString(grid))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    /// <summary>
    /// BFS.
    /// </summary>
    public int ShortestPathBinaryMatrix(int[][] grid)
    {
        var sourceRow = 0;
        var sourceColumn = 0;
        var destinationRow = grid.Length - 1;
        var destinationColumn = grid[destinationRow].Length - 1;

        if (grid[sourceRow][sourceColumn] == 1
            || grid[destinationRow][destinationColumn] == 1)
        {
            return -1;
        }

        var directions = new (int Row, int Column)[]
        {
            (-1, -1),   (-1, 0),    (-1, 1),
            (0, -1),  /*(0, 0),*/   (0, 1),
            (1, -1),    (1, 0),     (1, 1),
        };

        var queue = new Queue<(int Row, int Column)>();
        queue.Enqueue((sourceRow, sourceColumn));
        grid[sourceRow][sourceColumn] = 1;

        var stepCount = 0;

        while (queue.Count > 0)
        {
            stepCount++;
            var cellsOnStep = queue.Count;

            for (var i = 0; i < cellsOnStep; i++)
            {
                var cell = queue.Dequeue();

                if (cell.Row == destinationRow
                    && cell.Column == destinationColumn)
                {
                    return stepCount;
                }

                for (var j = 0; j < directions.Length; j++)
                {
                    var row = cell.Row + directions[j].Row;
                    var column = cell.Column + directions[j].Column;

                    if (row < 0
                        || column < 0
                        || row >= grid.Length
                        || column >= grid[row].Length
                        || grid[row][column] == 1)
                    {
                        continue;
                    }

                    queue.Enqueue((row, column));
                    grid[row][column] = 1;
                }
            }
        }

        return -1;
    }
}
