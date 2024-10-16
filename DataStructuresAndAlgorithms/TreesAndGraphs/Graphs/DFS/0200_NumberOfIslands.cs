using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.TreesAndGraphs.Graphs.DFS;

internal class _0200_NumberOfIslands
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var grid1 = new char[][]
            {
                ['1', '1', '1', '1', '0'],
                ['1', '1', '0', '1', '0'],
                ['1', '1', '0', '0', '0'],
                ['0', '0', '0', '0', '0']
            };

            var grid2 = new char[][]
            {
                ['1', '1', '0', '0', '0'],
                ['1', '1', '0', '0', '0'],
                ['0', '0', '1', '0', '0'],
                ['0', '0', '0', '1', '1']
            };

            Test1(grid1);
            Test1(grid2);
        }

        private void Test1(char[][] grid)
        {
            List<(string Name, string? Value)> parameters =
            [
                (nameof(grid), Environment.NewLine + GraphHelper.ConvertGridToString(grid))
            ];

            var result = new _0200_NumberOfIslands().NumIslands(grid);

            List<(string Name, string? Value)> processedParameters =
            [
                (nameof(grid), Environment.NewLine + GraphHelper.ConvertGridToString(grid))
            ];

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    /// <summary>
    /// DFS. Recursion
    /// Time: O(m*n).
    /// Space: O(m*n).
    /// </summary>
    public int NumIslands(char[][] grid)
    {
        var cellStates = new bool[grid.Length][];
        for (var i = 0; i < grid.Length; i++)
        {
            cellStates[i] = new bool[grid[i].Length];
        }

        var islandCount = 0;
        for (var i = 0; i < grid.Length; i++)
        {
            for (var j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == '0'
                    || cellStates[i][j])
                {
                    continue;
                }

                islandCount++;
                ProcessIsland(i, j);
            }
        }

        return islandCount;

        void ProcessIsland(int i, int j)
        {
            cellStates[i][j] = true;

            var iTopCell = i - 1;
            var iBottomCell = i + 1;
            var jLeftCell = j - 1;
            var jRightCellIndex = j + 1;

            if (iTopCell >= 0
                && grid[iTopCell][j] == '1'
                && !cellStates[iTopCell][j])
            {
                ProcessIsland(iTopCell, j);
            }

            if (iBottomCell < grid.Length
                && grid[iBottomCell][j] == '1'
                && !cellStates[iBottomCell][j])
            {
                ProcessIsland(iBottomCell, j);
            }

            if (jLeftCell >= 0
                && grid[i][jLeftCell] == '1'
                && !cellStates[i][jLeftCell])
            {
                ProcessIsland(i, jLeftCell);
            }

            if (jRightCellIndex < grid[i].Length
                && grid[i][jRightCellIndex] == '1'
                && !cellStates[i][jRightCellIndex])
            {
                ProcessIsland(i, jRightCellIndex);
            }
        }

    }

    /// <summary>
    /// DFS. Stack
    /// Time: O(m*n).
    /// Space: O(m*n).
    /// </summary>
    public int NumIslandsV2(char[][] grid)
    {
        var stack = new Stack<(int X, int Y)>();

        var islandCount = 0;

        //wrong namings, but works
        for (var x = 0; x < grid.Length; x++)
        {
            for (var y = 0; y < grid[x].Length; y++)
            {
                if(grid[x][y] == '0')
                {
                    continue;
                }

                islandCount++;
                stack.Push((x, y));
                grid[x][y] = '0';

                while(stack.TryPop(out var cell))
                {
                    var xTopCell = cell.X - 1;
                    var xBottomCell = cell.X + 1;
                    var yLeftCell = cell.Y - 1;
                    var yRightCell = cell.Y + 1;

                    if (xTopCell >= 0
                        && grid[xTopCell][cell.Y] == '1')
                    {
                        stack.Push((xTopCell, cell.Y));
                        grid[xTopCell][cell.Y] = '0';
                    }

                    if (xBottomCell < grid.Length
                        && grid[xBottomCell][cell.Y] == '1')
                    {
                        stack.Push((xBottomCell, cell.Y));
                        grid[xBottomCell][cell.Y] = '0';
                    }

                    if (yLeftCell >= 0
                        && grid[cell.X][yLeftCell] == '1')
                    {
                        stack.Push((cell.X, yLeftCell));
                        grid[cell.X][yLeftCell] = '0';
                    }

                    if (yRightCell < grid[cell.X].Length
                        && grid[cell.X][yRightCell] == '1')
                    {
                        stack.Push((cell.X, yRightCell));
                        grid[cell.X][yRightCell] = '0';
                    }
                }
            }
        }

        return islandCount;
    }
}
