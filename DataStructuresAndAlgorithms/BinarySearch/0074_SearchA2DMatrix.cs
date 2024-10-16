using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.BinarySearch;

internal class _0074_SearchA2DMatrix
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var matrix = new int[][]
            {
                [1,3,5,7],[10,11,16,20],[23,30,34,60]
            };
            var target = 3;
            Test(matrix, target);
        }

        private void Test(int[][] matrix, int target)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(matrix), JsonSerializer.Serialize(matrix)),
                (nameof(target), JsonSerializer.Serialize(target))
            };

            var result = new _0074_SearchA2DMatrix().SearchMatrix(matrix, target);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(matrix), JsonSerializer.Serialize(matrix)),
                (nameof(target), JsonSerializer.Serialize(target))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public bool SearchMatrix(int[][] matrix, int target)
    {
        var rows = matrix.Length;
        var columns = matrix[0].Length;
        var length = rows * columns;

        var left = 0L;
        var right = length - 1L;

        while (left <= right)
        {
            var mid = (left + right) / 2;

            var row = mid / columns;
            var column = mid % columns;

            var value = matrix[row][column];

            if(value == target)
            {
                return true;
            }

            if(value > target)
            {
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }

        }

        return false;
    }
}
