using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.TreesAndGraphs.Graphs.BFS;

internal class _1926_NearestExitFromEntranceInMaze
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var maze1 = new char[][]
            {
                ['+', '+', '.', '+'],
                ['.', '.', '.', '+'],
                ['+', '+', '+', '.']
            };

            var entrance1 = new int[] { 1, 2 };

            var maze2 = new char[][]
            {
                ['+', '+', '+'],
                ['.', '.', '.'],
                ['+', '+', '+']
            };
            var entrance2 = new int[] { 1, 0 };


            Test1(maze1, entrance1);
            Test1(maze2, entrance2);
        }

        private void Test1(char[][] maze, int[] entrance)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(maze), Environment.NewLine + GraphHelper.ConvertGridToString(maze)),
                (nameof(entrance), Environment.NewLine + JsonSerializer.Serialize(entrance))
            };

            var result = new _1926_NearestExitFromEntranceInMaze().NearestExit(maze, entrance);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(maze), Environment.NewLine + GraphHelper.ConvertGridToString(maze)),
                (nameof(entrance), Environment.NewLine + JsonSerializer.Serialize(entrance))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int NearestExit(char[][] maze, int[] entrance)
    {
        var lastRowIndex = maze.Length - 1;
        var lastColumnIndex = maze[0].Length - 1;

        var directions = new (int Row, int Column)[]
        {
            (-1, 0),  (0, -1), (0, 1), (1, 0)
        };

        var queue = new Queue<(int Row, int Column)>();

        maze[entrance[0]][entrance[1]] = '|';
        for (var j = 0; j < directions.Length; j++)
        {
            var direction = directions[j];
            var newRow = entrance[0] + direction.Row;
            var newColumn = entrance[1] + direction.Column;

            if (newRow < 0
                || newColumn < 0
                || newRow > lastRowIndex
                || newColumn > lastColumnIndex
                || maze[newRow][newColumn] != '.')
            {
                continue;
            }

            queue.Enqueue((newRow, newColumn));
            maze[newRow][newColumn] = '|';
        }
        var pathLenght = 1;

        while (queue.Count > 0)
        {
            var cellCount = queue.Count;

            for (int i = 0; i < cellCount; i++)
            {
                var cell = queue.Dequeue();

                if (cell.Row == 0
                    || cell.Column == 0
                    || cell.Row == lastRowIndex
                    || cell.Column == lastColumnIndex)
                {
                    return pathLenght;
                }

                for (var j = 0; j < directions.Length; j++)
                {
                    var direction = directions[j];
                    var newRow = cell.Row + direction.Row;
                    var newColumn = cell.Column + direction.Column;

                    if (maze[newRow][newColumn] != '.')
                    {
                        continue;
                    }

                    queue.Enqueue((newRow, newColumn));
                    maze[newRow][newColumn] = '|';
                }
            }

            pathLenght++;
        }

        return -1;
    }
}
