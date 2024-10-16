using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.TreesAndGraphs.Graphs.BFS;

internal class _0909_SnakesAndLadders
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var board1 = new int[][]
            {
                [-1, -1, -1, -1, -1, -1],
                [-1, -1, -1, -1, -1, -1],
                [-1, -1, -1, -1, -1, -1],
                [-1, 35, -1, -1, 13, -1],
                [-1, -1, -1, -1, -1, -1],
                [-1, 15, -1, -1, -1, -1]
            };

            var board2 = new int[][]
            {
                [-1,-1,-1,46,47,-1,-1,-1],
                [51,-1,-1,63,-1,31,21,-1],
                [-1,-1,26,-1,-1,38,-1,-1],
                [-1,-1,11,-1,14,23,56,57],
                [11,-1,-1,-1,49,36,-1,48],
                [-1,-1,-1,33,56,-1,57,21],
                [-1,-1,-1,-1,-1,-1,2,-1],
                [-1,-1,-1,8,3,-1,6,56]
            };

            Test1(board1);
            Test1(board2);
        }

        private void Test1(int[][] board)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(board), Environment.NewLine + GraphHelper.ConvertGridToString(board))
            };

            var result = new _0909_SnakesAndLadders().SnakesAndLadders(board);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(board), Environment.NewLine + GraphHelper.ConvertGridToString(board))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int SnakesAndLadders(int[][] board)
    {
        var n = board.Length;
        var lastCell = n * n;

        var map = BuildMap(board);

        var queue = new Queue<int>();
        queue.Enqueue(1);

        var length = 0;

        while (queue.Count > 0)
        {
            var cellCount = queue.Count;

            for (var i = 0; i < cellCount; i++)
            {
                var cell = queue.Dequeue();

                if (cell == lastCell)
                {
                    return length;
                }

                var lastNextCell = Math.Min(cell + 6, lastCell);
                for (var nextCell = cell + 1; nextCell <= lastNextCell; nextCell++)
                {
                    if (map[nextCell] == -1)
                    {
                        queue.Enqueue(nextCell);
                        map[nextCell] = 0;
                        continue;
                    }

                    if (map[nextCell] == 0)
                    {
                        continue;
                    }

                    var jumpToCell = map[nextCell];
                    map[nextCell] = 0;
                    if (jumpToCell == -1)
                    {
                        queue.Enqueue(jumpToCell);
                        map[jumpToCell] = 0;
                        continue;
                    }

                    if (jumpToCell == 0)
                    {
                        continue;
                    }

                    queue.Enqueue(jumpToCell);
                }
            }

            length++;
        }

        return -1;
    }

    private int[] BuildMap(int[][] board)
    {
        var n = board.Length;
        var map = new int[n * n + 1];

        var cellValue = 1;
        for (var row = n - 1; row >= 0; row--)
        {
            for (var column = 0; column < n; column++)
            {
                map[cellValue++] = board[row][column];
            }

            row--;
            if (row < 0)
            {
                break;
            }

            for (var column = n - 1; column >= 0; column--)
            {
                map[cellValue++] = board[row][column];
            }
        }

        return map;
    }
}
