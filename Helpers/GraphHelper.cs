using System.Text;

namespace Helpers;

public static class GraphHelper
{
    public static string ConvertGridToString<T>(IList<IList<T>> grid)
    {
        var stringGrid = new string[grid.Count][];
        for (var i = 0; i < grid.Count; i++)
        {
            stringGrid[i] = grid[i]?.Select(i => i?.ToString() ?? string.Empty).ToArray() ?? [];
        }

        return ConvertGridToString(stringGrid);
    }

    public static string ConvertGridToString(IList<IList<string>> grid)
    {
        var result = new StringBuilder();
        result.AppendLine("[");
        foreach (var row in grid)
        {
            result.Append("  [");
            result.Append(string.Join(", ", row.Select(c => c.ToString())));
            result.AppendLine("],");
        }
        result.AppendLine("]");

        return result.ToString();
    }
}
