using Helpers;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.DynamicProgramming;

internal class _0931_MinimumFallingPathSum
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var matrix = new int[][]
            {
                [2, 1, 3],
                [6, 5, 4],
                [7, 8, 9]
            };
            Test(matrix);
            Test([
                [100, -42, -46, -41], 
                [31, 97, 10, -10], 
                [-58, -51, 82, 89], 
                [51, 81, 69, -51]]);
            Test([
                [-51, -35, 74],
                [-62, 14, -53],
                [94, 61, -10]]);
        }

        private void Test(int[][] matrix)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(matrix), JsonSerializer.Serialize(matrix))
            };

            var result = new _0931_MinimumFallingPathSum().MinFallingPathSum3(matrix);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(matrix), JsonSerializer.Serialize(matrix))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    /// <summary>
    /// DP
    /// </summary>
    public int MinFallingPathSum(int[][] matrix)
    {
        var m = matrix.Length;
        var n = matrix[0].Length;

        var previousRow = new int[n];
        var currentRow = new int[n];
        Array.Copy(matrix[0], previousRow, n);

        for (var row = 1; row < m; row++)
        {
            var min = Math.Min(previousRow[0], previousRow[1]);
            currentRow[0] = min + matrix[row][0];

            var column = 1;
            for (; column < n - 1; column++)
            {
                min = Math.Min(previousRow[column - 1], previousRow[column]);
                min = Math.Min(min, previousRow[column + 1]);
                currentRow[column] = min + matrix[row][column];
            }

            min = Math.Min(previousRow[column - 1], previousRow[column]);
            currentRow[column] = min + matrix[row][column];

            var buf = previousRow;
            previousRow = currentRow;
            currentRow = buf;
        }

        return previousRow.Min();
    }

    /// <summary>
    /// DP + Monotonic function
    /// </summary>
    public int MinFallingPathSum2(int[][] matrix)
    {
        var m = matrix.Length;
        var n = matrix[0].Length;

        var dp = new int[n];
        Array.Copy(matrix[0], dp, n);

        var monotonicFunction = new LinkedList<(int Value, int Index)>();

        for (var row = 1; row < m; row++)
        {
            monotonicFunction.Clear();
            monotonicFunction.AddLast((dp[0], 0));

            var column = 0;
            for (; column < n - 1; column++)
            {
                AddValue(column);
                RemoveExcessValue(column);

                dp[column] = monotonicFunction.First!.Value.Value + matrix[row][column];
            }

            RemoveExcessValue(column);
            dp[column] = monotonicFunction.First!.Value.Value + matrix[row][column];
        }

        return dp.Min();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void AddValue(int column)
        {
            var index = column + 1;
            var value = dp[index];
            while (monotonicFunction.Last?.Value.Value >= value)
            {
                monotonicFunction.RemoveLast();
            }

            monotonicFunction.AddLast((value, index));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void RemoveExcessValue(int column)
        {
            if (monotonicFunction.First!.Value.Index == column - 2)
            {
                monotonicFunction.RemoveFirst();
            }
        }
    }

    /// <summary>
    /// DP + Min heap
    /// </summary>
    public int MinFallingPathSum3(int[][] matrix)
    {
        var m = matrix.Length;
        var n = matrix[0].Length;

        var dp = new int[n];
        Array.Copy(matrix[0], dp, n);

        //PriorityQueue<(int Index), (int Value)>
        var monotonicFunction = new PriorityQueue<int, int>();

        for (var row = 1; row < m; row++)
        {
            monotonicFunction.Clear();
            monotonicFunction.Enqueue(0, dp[0]);

            var value = 0;
            var column = 0;
            for (; column < n - 1; column++)
            {
                AddValue(column);
                RemoveExcessValue(column);

                monotonicFunction.TryPeek(out _, out value);
                dp[column] = value + matrix[row][column];
            }

            RemoveExcessValue(column);
            monotonicFunction.TryPeek(out _, out value);
            dp[column] = value + matrix[row][column];
        }

        return dp.Min();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void AddValue(int column)
        {
            var index = column + 1;
            var value = dp[index];
            monotonicFunction.Enqueue(index, value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void RemoveExcessValue(int column)
        {
            while (true)
            {
                monotonicFunction.TryPeek(out var index, out _);
                if (index >= column - 1)
                {
                    break;
                }

                monotonicFunction.Dequeue();
            }
        }
    }
}
