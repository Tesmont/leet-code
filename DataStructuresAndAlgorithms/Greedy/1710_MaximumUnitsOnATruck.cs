using DataStructuresAndAlgorithms.TreesAndGraphs.Graphs.DFS;
using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.Greedy;

internal class _1710_MaximumUnitsOnATruck
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var boxTypes = new int[][]
            {
                [1, 3],
                [2, 2],
                [3, 1]
            };
            var truckSize = 4;
            Test(boxTypes, truckSize);
        }

        private void Test(int[][] boxTypes, int truckSize)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(boxTypes), JsonSerializer.Serialize(boxTypes)),
                (nameof(truckSize), JsonSerializer.Serialize(truckSize))
            };

            var result = new _1710_MaximumUnitsOnATruck().MaximumUnits(boxTypes, truckSize);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(boxTypes), JsonSerializer.Serialize(boxTypes)),
                (nameof(truckSize), JsonSerializer.Serialize(truckSize))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int MaximumUnits(int[][] boxTypes, int truckSize)
    {
        const int boxCountIndex = 0;
        const int unitCountIndex = 1;

        var comparer = Comparer<int[]>.Create((x, y) => 
        {
            var unitCount1 = x[unitCountIndex];
            var unitCount2 = y[unitCountIndex];

            return unitCount1 - unitCount2;
        });

        Array.Sort(boxTypes, comparer);

        var unitCountInTruckCount = 0;

        for(var i = boxTypes.Length - 1; i >= 0; i--)
        {
            var boxCount = boxTypes[i][boxCountIndex];
            var unitCount = boxTypes[i][unitCountIndex];

            if (boxCount >= truckSize)
            {
                unitCountInTruckCount += truckSize * unitCount;
                return unitCountInTruckCount;
            }

            unitCountInTruckCount += boxCount * unitCount;
            truckSize -= boxCount;
        }

        return unitCountInTruckCount;
    }
}
