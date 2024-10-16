using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.TreesAndGraphs.Graphs.DFS;

internal class _0695_MaxAreaOfIsland
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var grid1 = new int[][]
            {
                [0,0,1,0,0,0,0,1,0,0,0,0,0],
                [0,0,0,0,0,0,0,1,1,1,0,0,0],
                [0,1,1,0,1,0,0,0,0,0,0,0,0],
                [0,1,0,0,1,1,0,0,1,0,1,0,0],
                [0,1,0,0,1,1,0,0,1,1,1,0,0],
                [0,0,0,0,0,0,0,0,0,0,1,0,0],
                [0,0,0,0,0,0,0,1,1,1,0,0,0],
                [0,0,0,0,0,0,0,1,1,0,0,0,0]
            };

            Test1(grid1);
        }

        private void Test1(int[][] grid)
        {
            List<(string Name, string? Value)> parameters =
            [
                (nameof(grid), Environment.NewLine + GraphHelper.ConvertGridToString(grid))
            ];

            var result = new _0695_MaxAreaOfIsland().MaxAreaOfIsland(grid);

            List<(string Name, string? Value)> processedParameters =
            [
                (nameof(grid), Environment.NewLine + GraphHelper.ConvertGridToString(grid))
            ];

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int MaxAreaOfIsland(int[][] grid)
    {
        var stack = new Stack<(int Row, int Column)>();
        var maxIslandSquare = 0;

        for (var row = 0; row < grid.Length; row++)
        {
            for (var column = 0; column < grid[row].Length; column++)
            {
                if (grid[row][column] == 0)
                {
                    continue;
                }

                stack.Push((row, column));
                grid[row][column] = 0;
                var islandSquare = 0;

                while (stack.TryPop(out var cell))
                {
                    islandSquare++;

                    var rowTopCell = cell.Row - 1;
                    var rowBottomCell = cell.Row + 1;
                    var columnLeftCell = cell.Column - 1;
                    var columnRightCell = cell.Column + 1;

                    if (rowTopCell >= 0
                        && grid[rowTopCell][cell.Column] == 1)
                    {
                        stack.Push((rowTopCell, cell.Column));
                        grid[rowTopCell][cell.Column] = 0;
                    }

                    if (rowBottomCell < grid.Length
                        && grid[rowBottomCell][cell.Column] == 1)
                    {
                        stack.Push((rowBottomCell, cell.Column));
                        grid[rowBottomCell][cell.Column] = 0;
                    }

                    if (columnLeftCell >= 0
                        && grid[cell.Row][columnLeftCell] == 1)
                    {
                        stack.Push((cell.Row, columnLeftCell));
                        grid[cell.Row][columnLeftCell] = 0;
                    }

                    if (columnRightCell < grid[cell.Row].Length
                        && grid[cell.Row][columnRightCell] == 1)
                    {
                        stack.Push((cell.Row, columnRightCell));
                        grid[cell.Row][columnRightCell] = 0;
                    }
                }

                maxIslandSquare = Math.Max(maxIslandSquare, islandSquare);
            }
        }

        return maxIslandSquare;
    }
}
