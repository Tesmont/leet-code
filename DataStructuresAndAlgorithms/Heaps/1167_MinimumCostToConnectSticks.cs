using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.Heaps;

internal class _1167_MinimumCostToConnectSticks
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var sticks = new int[] { 1, 8, 3, 5 };
            Test(sticks);
        }

        private void Test(int[] sticks)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(sticks), JsonSerializer.Serialize(sticks))
            };

            var result = new _1167_MinimumCostToConnectSticks().ConnectSticks(sticks);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(sticks), JsonSerializer.Serialize(sticks))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int ConnectSticks(int[] sticks)
    {
        var heap = new PriorityQueue<int, int>(sticks.Select(i => (i, i)));

        var cost = 0;

        while (heap.Count > 1)
        {
            var stick1 = heap.Dequeue();
            var stick2 = heap.Dequeue();

            stick1 += stick2;
            cost += stick1;

            heap.Enqueue(stick1, stick1);
        }

        return cost;
    }
}
