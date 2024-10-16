using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.BinarySearch;

internal class _1631_PathWithMinimumEffort
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var heights = new int[][]
            {
                [1,2,3],
                [3,8,4],
                [5,3,5]
            };
            Test(heights);
        }

        private void Test(int[][] heights)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(heights), JsonSerializer.Serialize(heights))
            };

            var result = new _1631_PathWithMinimumEffort().MinimumEffortPath(heights);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(heights), JsonSerializer.Serialize(heights))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int MinimumEffortPath(int[][] heights)
    {
        var minEffort = 0;
        var maxEffort = heights.SelectMany(i => i).Max();

        while (minEffort < maxEffort)
        {
            var midEffort = minEffort + (maxEffort - minEffort) / 2;

            if (TryReachWithEffort(heights, midEffort))
            {
                maxEffort = midEffort;
            }
            else
            {
                minEffort = midEffort + 1;
            }
        }

        return maxEffort;

        bool TryReachWithEffort(int[][] heights, int effortLimit)
        {
            var moveDirections = new (int rowShift, int columnShift)[]
            {
                (-1, 0), (0, -1), (0, 1), (1, 0)
            };

            var rowCount = heights.Length;
            var columnCount = heights[0].Length;

            var startRow = 0;
            var startColumn = 0;

            var destinationRow = rowCount - 1;
            var destinationColumn = columnCount - 1;

            var visitedVerticies = new bool[rowCount, columnCount];
            visitedVerticies[startRow, startColumn] = true;

            var stack = new Stack<(int row, int column)>();
            stack.Push((startRow, startColumn));

            while (stack.TryPop(out var cell))
            {
                if (cell.row == destinationRow
                    && cell.column == destinationColumn)
                {
                    return true;
                }

                foreach (var moveDirection in moveDirections)
                {
                    var nextRow = cell.row + moveDirection.rowShift;
                    var nextColumn = cell.column + moveDirection.columnShift;

                    if (nextRow < 0 || nextRow == rowCount || nextColumn < 0 || nextColumn == columnCount
                        || visitedVerticies[nextRow, nextColumn])
                    {
                        continue;
                    }

                    var effort = Math.Abs(heights[cell.row][cell.column] - heights[nextRow][nextColumn]);
                    if (effort > effortLimit)
                    {
                        continue;
                    }

                    stack.Push((nextRow, nextColumn));
                    visitedVerticies[nextRow, nextColumn] = true;
                }
            }

            return false;
        }
    }
}
