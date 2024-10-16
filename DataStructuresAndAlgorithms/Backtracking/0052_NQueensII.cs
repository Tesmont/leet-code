using Helpers;
using System.Drawing;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.Backtracking;

internal class _0052_NQueensII
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var n = 4;
            Test(n);
        }

        private void Test(int n)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(n), JsonSerializer.Serialize(n))
            };

            var result = new _0052_NQueensII().TotalNQueens(n);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(n), JsonSerializer.Serialize(n))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int TotalNQueens(int n)
    {
        var result = 0;
        var fobiddenCells = new int[n, n];
        BackTrack(0, 0);

        return result;

        void BackTrack(int row, int queenCount)
        {
            if (queenCount == n)
            {
                result++;
                return;
            }

            if(row == n)
            {
                return;
            }

            for(var column = 0; column < n; column++)
            {
                if(fobiddenCells[row, column] > 0)
                {
                    continue;
                }

                MarkCells(row, column, 1);
                BackTrack(row + 1, queenCount + 1);
                MarkCells(row, column, -1);
            }
        }

        void MarkCells(int row, int column, int flag)
        {
            //With optimization. Skip useless cells from previous rows.

            //for (var i = 0; i < n; i++)
            for (var i = row; i < n; i++)
            {
                //Horizontal line
                //fobiddenCells[row, i] += flag;

                //Vertical line
                fobiddenCells[i, column] += flag;
            }

            // Main diagonal
            //var currentRow = row - 1;
            //var currentColumn = column - 1;
            //while (currentRow >= 0 && currentColumn >= 0)
            //{
            //    fobiddenCells[currentRow, currentColumn] += flag;
            //    currentRow--;
            //    currentColumn--;
            //}

            var currentRow = row + 1;
            var currentColumn = column + 1;
            while (currentRow < n && currentColumn < n)
            {
                fobiddenCells[currentRow, currentColumn] += flag;
                currentRow++;
                currentColumn++;
            }

            //Secondary diagonal
            //currentRow = row - 1;
            //currentColumn = column + 1;
            //while (currentRow >= 0 && currentColumn < n)
            //{
            //    fobiddenCells[currentRow, currentColumn] += flag;
            //    currentRow--;
            //    currentColumn++;
            //}

            currentRow = row + 1;
            currentColumn = column - 1;
            while (currentRow < n && currentColumn >= 0)
            {
                fobiddenCells[currentRow, currentColumn] += flag;
                currentRow++;
                currentColumn--;
            }
        }
    }

    public int TotalNQueens2(int n)
    {
        var result = 0;
        var fobiddenColumns = new int[n];
        var forbiddenMainDiagonals = new int[2 * n + 1];
        var forbiddenSecondaryDiagonals = new int[2 * n + 1];
        BackTrack(0, 0);

        return result;

        void BackTrack(int row, int queenCount)
        {
            if (queenCount == n)
            {
                result++;
                return;
            }

            if (row == n)
            {
                return;
            }

            for (var column = 0; column < n; column++)
            {
                if (fobiddenColumns[column] > 0)
                {
                    continue;
                }

                var mainDiagonalDifference = row - column + n;
                if (forbiddenMainDiagonals[mainDiagonalDifference] > 0)
                {
                    continue;
                }

                var secondaryDiagonalSum = row + column;
                if (forbiddenSecondaryDiagonals[secondaryDiagonalSum] > 0)
                {
                    continue;
                }

                fobiddenColumns[column]++;
                forbiddenMainDiagonals[mainDiagonalDifference]++;
                forbiddenSecondaryDiagonals[secondaryDiagonalSum]++;

                BackTrack(row + 1, queenCount + 1);

                fobiddenColumns[column]--;
                forbiddenMainDiagonals[mainDiagonalDifference]--;
                forbiddenSecondaryDiagonals[secondaryDiagonalSum]--;
            }
        }
    }
}
