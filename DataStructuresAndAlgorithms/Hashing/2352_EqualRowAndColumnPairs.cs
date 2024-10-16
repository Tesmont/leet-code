using Helpers;

namespace DataStructuresAndAlgorithms.Hashing;

internal class _2352_EqualRowAndColumnPairs
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1([[3, 2, 1], [1, 7, 6], [2, 7, 7]]);
            Test1([[3, 1, 2, 2], [1, 4, 4, 5], [2, 4, 2, 2], [2, 4, 2, 2]]);
        }

        private void Test1(int[][] grid)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(grid), grid));

            var result = new _2352_EqualRowAndColumnPairs().EqualPairs(grid);

            printTable.AddProcessedParameters(
                (nameof(grid), grid));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    public int EqualPairs(int[][] grid)
    {
        var columns = new Dictionary<int[], int>(new IntArrayEqualityComparer());
        var rows = new Dictionary<int[], int>(new IntArrayEqualityComparer());

        for(var columnIndex = 0; columnIndex < grid.Length; columnIndex++)
        {
            rows[grid[columnIndex]] = rows.TryGetValue(grid[columnIndex], out var rowCount) ? rowCount + 1 : 1;
        }

        for (var rowIndex = 0; rowIndex < grid[0].Length; rowIndex++)
        {
            var column = new int[grid.Length];
            for (var columnIndex = 0; columnIndex < grid.Length; columnIndex++)
            {
                column[columnIndex] = grid[columnIndex][rowIndex];
            }

            columns[column] = columns.TryGetValue(column, out var columnCount) ? columnCount + 1 : 1;
        }

        var counts = 0;
        foreach (var row in rows)
        {
            if(!columns.TryGetValue(row.Key, out var columnCount))
            {
                continue;
            }

            counts += row.Value * columnCount;
        }

        return counts;
    }

    public int EqualPairsV2(int[][] grid)
    {
        var columns = new Dictionary<string, int>();
        var rows = new Dictionary<string, int>();

        for (var columnIndex = 0; columnIndex < grid.Length; columnIndex++)
        {
            var key = string.Join(" ", grid[columnIndex]);
            rows[key] = rows.TryGetValue(key, out var rowCount) ? rowCount + 1 : 1;
        }

        for (var rowIndex = 0; rowIndex < grid[0].Length; rowIndex++)
        {
            var column = new int[grid.Length];
            for (var columnIndex = 0; columnIndex < grid.Length; columnIndex++)
            {
                column[columnIndex] = grid[columnIndex][rowIndex];
            }

            var key = string.Join(" ", column);
            columns[key] = columns.TryGetValue(key, out var columnCount) ? columnCount + 1 : 1;
        }

        var counts = 0;
        foreach (var row in rows)
        {
            if (!columns.TryGetValue(row.Key, out var columnCount))
            {
                continue;
            }

            counts += row.Value * columnCount;
        }
        
        return counts;
    }
}

public class IntArrayEqualityComparer : IEqualityComparer<int[]>
{
    public bool Equals(int[]? x, int[]? y)
    {
        if (x == null && y == null)
        {
            return true;
        }

        if (x == null || y == null)
        {
            return false;
        }

        return x.SequenceEqual(y);
    }

    public int GetHashCode(int[] obj)
    {
        var hashCode = new HashCode();
        foreach (var item in obj)
        {
            hashCode.Add(item);
        }

        return hashCode.ToHashCode();
    }
}