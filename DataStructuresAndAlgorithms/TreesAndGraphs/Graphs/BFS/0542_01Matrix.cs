using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.TreesAndGraphs.Graphs.BFS;

internal class _0542_01Matrix
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var mat = new int[][]
            {
                [0, 0, 0],
                [0, 1, 0],
                [1, 1, 1]
            };

            Test1(mat);
        }

        private void Test1(int[][] mat)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(mat), Environment.NewLine + GraphHelper.ConvertGridToString(mat))
            };

            var result = new _0542_01Matrix().UpdateMatrix(mat);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(mat), Environment.NewLine + GraphHelper.ConvertGridToString(mat))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int[][] UpdateMatrix(int[][] mat)
    {
        var directions = new (int Row, int Column)[]
        {
            (-1, 0),    //Top
            (1, 0),     //Bottom
            (0, -1),    //Left
            (0, 1),     //Right
        };

        var visitedCells = new bool[mat.Length][];
        var queue = new Queue<(int Row, int Column)>();

        for (var row = 0; row < mat.Length; row++)
        {
            visitedCells[row] = new bool[mat[row].Length];

            for (var column = 0; column < mat[row].Length; column++)
            {
                if (mat[row][column] == 0)
                {
                    queue.Enqueue((row, column));
                    visitedCells[row][column] = true;
                }
            }
        }

        var level = 0;
        while (queue.Count > 0)
        {
            var cellCount = queue.Count;
            level++;

            for (var i = 0; i < cellCount; i++)
            {
                var cell = queue.Dequeue();

                for (var j = 0; j < directions.Length; j++)
                {
                    var direction = directions[j];

                    var row = cell.Row + direction.Row;
                    var column = cell.Column + direction.Column;
                    if (row < 0
                        || column < 0
                        || row >= mat.Length
                        || column >= mat[row].Length
                        || visitedCells[row][column])
                    {
                        continue;
                    }

                    queue.Enqueue((row, column));
                    mat[row][column] = level;
                    visitedCells[row][column] = true;
                }
            }
        }

        return mat;
    }
}
