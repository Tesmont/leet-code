using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.Heaps;

internal class _1962_RemoveStonesToMinimizeTheTotal
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var piles = new int[] { 5, 4, 9 };
            var k = 2;
            Test(piles, k);
        }

        private void Test(int[] piles, int k)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(piles), JsonSerializer.Serialize(piles)),
                (nameof(k), JsonSerializer.Serialize(k))
            };

            var result = new _1962_RemoveStonesToMinimizeTheTotal().MinStoneSum(piles, k);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(piles), JsonSerializer.Serialize(piles)),
                (nameof(k), JsonSerializer.Serialize(k))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int MinStoneSum(int[] piles, int k)
    {
        var comparer = Comparer<int>.Create((x, y) => y.CompareTo(x));
        var sourceForHeap = piles.Select(i => (i, i));
        var heap = new PriorityQueue<int, int>(sourceForHeap, comparer);

        var sum = piles.Sum();
        
        for(var i = 0; i < k; i++)
        {
            var value = heap.Dequeue();
            var difference = value / 2;
            value -= difference;
            sum -= difference;
            heap.Enqueue(value, value);
        }

        return sum;
    }
}
