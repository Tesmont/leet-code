using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.BinarySearch;

internal class _1231_DivideChocolate
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var sweetness = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var k = 5;
            Test(sweetness, k);
        }

        private void Test(int[] sweetness, int k)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(sweetness), JsonSerializer.Serialize(sweetness)),
                (nameof(k), JsonSerializer.Serialize(k))
            };

            var result = new _1231_DivideChocolate().MaximizeSweetness(sweetness, k);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(sweetness), JsonSerializer.Serialize(sweetness)),
                (nameof(k), JsonSerializer.Serialize(k))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int MaximizeSweetness(int[] sweetness, int k)
    {
        var min = sweetness.Min();
        var max = sweetness.Sum() / (k + 1);

        while (min < max)
        {
            var mid = min + (max - min) / 2;

            var pieceCount = CutTheBar(mid);
            if (pieceCount <= k)
            {
                max = mid;
            }
            else
            {
                min = mid + 1;
            }
        }

        return max;

        int CutTheBar(int pieceLimit)
        {
            var pieceCount = 0;
            var pieceSweetness = 0;

            for (var i = 0; i < sweetness.Length; i++)
            {
                pieceSweetness += sweetness[i];

                if (pieceSweetness <= pieceLimit)
                {
                    continue;
                }

                pieceCount++;
                pieceSweetness = 0;
            }

            return pieceCount;
        }
    }
}
