using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.Backtracking;

internal class _0079_WordSearch
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var board = new char[][]
            {
                ['A', 'B', 'C', 'E'],
                ['S', 'F', 'C', 'S'],
                ['A', 'D', 'E', 'E']
            };
            var word = "ABCCED";
            Test(board, word);
        }

        private void Test(char[][] board, string word)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(board), JsonSerializer.Serialize(board)),
                (nameof(word), JsonSerializer.Serialize(word))
            };

            var result = new _0079_WordSearch().Exist(board, word);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(board), JsonSerializer.Serialize(board)),
                (nameof(word), JsonSerializer.Serialize(word))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public bool Exist(char[][] board, string word)
    {
        var rowCount = board.Length;
        var columnCount = board[0].Length;
        var visitedCells = new bool[rowCount, columnCount];
        var directions = new (int rowShift, int columnShift)[4] 
        { 
            (-1, 0), (0, -1), (0, 1), (1, 0) 
        };

        for(var row = 0; row < rowCount; row++)
        {
            for(var column = 0; column < columnCount; column++)
            {
                visitedCells[row, column] = true;

                var result = Backtrack(row, column, 0);
                if(result)
                {
                    return true;
                }

                visitedCells[row, column] = false;
            }
        }

        return false;

        bool Backtrack(int row, int column, int letterIndex)
        {
            if(board[row][column] != word[letterIndex])
            {
                return false;
            }

            var newLetterIndex = letterIndex + 1;

            if (newLetterIndex == word.Length)
            {
                return true;
            }

            foreach (var direction in directions)
            {
                var newRow = row + direction.rowShift;
                if(newRow < 0 || newRow == rowCount)
                {
                    continue;
                }

                var newColumn = column + direction.columnShift;
                if (newColumn < 0 || newColumn == columnCount)
                {
                    continue;
                }

                if (visitedCells[newRow, newColumn])
                {
                    continue;
                }

                visitedCells[newRow, newColumn] = true;

                var result = Backtrack(newRow, newColumn, newLetterIndex);
                if(result)
                {
                    return true;
                }

                visitedCells[newRow, newColumn] = false;
            }

            return false;
        }
    }
}
