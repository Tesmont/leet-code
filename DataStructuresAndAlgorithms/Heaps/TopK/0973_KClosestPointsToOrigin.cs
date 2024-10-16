using Helpers;
using System.Net;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.Heaps.TopK;

internal class _0973_KClosestPointsToOrigin
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var points = new int[][]
            {
[3,3],[5,-1],[-2,4]
            };
            var k = 2;
            Test(points, k);
        }

        private void Test(int[][] points, int k)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(points), JsonSerializer.Serialize(points)),
                (nameof(k), JsonSerializer.Serialize(k))
            };

            var result = new _0973_KClosestPointsToOrigin().KClosest(points, k);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(points), JsonSerializer.Serialize(points)),
                (nameof(k), JsonSerializer.Serialize(k))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int[][] KClosest(int[][] points, int k)
    {
        var comparer = Comparer<int>.Create((x, y) => y.CompareTo(x));
        var heap = new PriorityQueue<int[], int>(comparer);

        foreach(var point in points)
        {
            var distance = point[0] * point[0] + point[1] * point[1];

            heap.Enqueue(point, distance);

            if(heap.Count > k)
            {
                heap.Dequeue();
            }
        }

        var result = new int[heap.Count][];
        for (var i = 0; i < result.Length; i++)
        {
            result[i] = heap.Dequeue();
        }

        return result;
    }
}
