using Helpers;
using System.Text.Json;
using Xunit;

namespace DataStructuresAndAlgorithms.Heaps;

internal class _1046_LastStoneWeight
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var stones = new int[] { 2, 7, 4, 1, 8, 1 };
            Test(stones);
        }

        private void Test(int[] stones)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(stones), JsonSerializer.Serialize(stones))
            };

            var result = new _1046_LastStoneWeight().LastStoneWeight(stones);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(stones), JsonSerializer.Serialize(stones))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int LastStoneWeight(int[] stones)
    {
        var priorityQueueSource = stones.Select(i => ((byte)0, i));
        var comparer = Comparer<int>.Create((x, y) => y.CompareTo(x));
        var priorityQueue = new PriorityQueue<byte, int>(priorityQueueSource, comparer);

        while (priorityQueue.TryDequeue(out _, out var stone1))
        {
            if(!priorityQueue.TryDequeue(out _, out var stone2))
            {
                return stone1;
            }

            if(stone1 == stone2)
            {
                continue;
            }

            var newStone = stone1 - stone2;
            priorityQueue.Enqueue(0, newStone);
        }

        if (priorityQueue.Count != 0)
            return priorityQueue.Dequeue();

        return 0;
    }

    public int LastStoneWeight2(int[] stones)
    {
        var priorityQueueSource = stones.Select(i => (i, i));
        var comparer = Comparer<int>.Create((x, y) => y.CompareTo(x));
        var priorityQueue = new PriorityQueue<int, int>(priorityQueueSource, comparer);

        while (priorityQueue.Count > 1)
        {
            int stone1 = priorityQueue.Dequeue();
            int stone2 = priorityQueue.Dequeue();

            if (stone1 == stone2)
            {
                continue;
            }

            var newStone = stone1 - stone2;
            priorityQueue.Enqueue(newStone, newStone);
        }

        if (priorityQueue.Count != 0)
        {
            return priorityQueue.Dequeue();
        }

        return 0;
    }
}
