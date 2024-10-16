using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.Bonus;

internal class _1094_CarPooling
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var trips = new int[][]
            {
                [2, 1, 5],
                [3, 3, 7]
            };
            var capacity = 4;
            Test(trips, capacity);
            Test([[7, 5, 6], [6, 7, 8], [10, 1, 6]], 16);
        }

        private void Test(int[][] trips, int capacity)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(trips), JsonSerializer.Serialize(trips)),
                (nameof(capacity), JsonSerializer.Serialize(capacity))
            };

            var result = new _1094_CarPooling().CarPooling(trips, capacity);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(trips), JsonSerializer.Serialize(trips)),
                (nameof(capacity), JsonSerializer.Serialize(capacity))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public bool CarPooling(int[][] trips, int capacity)
    {
        const int passengerCountIndex = 0;
        const int fromIndex = 1;
        const int toIndex = 2;

        Array.Sort(trips, Comparer<int[]>.Create((x, y) => x[fromIndex].CompareTo(y[fromIndex])));

        //PriorityQueue<(int PassengerCount), (int To)>
        var minHeap = new PriorityQueue<int, int>();

        var currentCapacity = capacity;
        foreach (var trip in trips)
        {
            var passengerCount = trip[passengerCountIndex];
            var from = trip[fromIndex];
            var to = trip[toIndex];

            while(minHeap.TryPeek(out var previousPassengerCount, out var previousTo)
                && previousTo <= from)
            {
                currentCapacity += previousPassengerCount;
                minHeap.Dequeue();
            }

            if (currentCapacity < passengerCount)
            {
                return false;
            }

            currentCapacity -= passengerCount;
            minHeap.Enqueue(passengerCount, to);
        }
        
        return true;
    }

    public bool CarPooling2(int[][] trips, int capacity)
    {
        var minHeap = new PriorityQueue<int, int>(ConvertTrips(trips));

        var currentPassengerCount = 0;
        while(minHeap.TryDequeue(out var passengerCount, out var distance))
        {
            currentPassengerCount += passengerCount;

            while (minHeap.TryPeek(out var passengerCount2, out var distance2)
                && distance == distance2)
            {
                currentPassengerCount += passengerCount2;
                minHeap.Dequeue();
            }

            if (currentPassengerCount > capacity)
            {
                return false;
            }
        }

        return true;

        IEnumerable<(int passengerCount, int timestamp)> ConvertTrips(int[][] trips)
        {
            const int passengerCountIndex = 0;
            const int fromIndex = 1;
            const int toIndex = 2;

            foreach (var trip in trips)
            {
                var passengerCount = trip[passengerCountIndex];
                var from = trip[fromIndex];
                var to = trip[toIndex];

                yield return (passengerCount, from);
                yield return (-passengerCount, to);
            }
        }
    }

    public bool CarPooling3(int[][] trips, int capacity)
    {
        const int passengerCountIndex = 0;
        const int fromIndex = 1;
        const int toIndex = 2;

        var map = new SortedDictionary<int, int>();
        foreach (var trip in trips)
        {
            var passengerCount = trip[passengerCountIndex];
            var from = trip[fromIndex];
            var to = trip[toIndex];

            map[from] = map.TryGetValue(from, out var previousPassengerCount) 
                ? previousPassengerCount + passengerCount
                : passengerCount;

            map[to] = map.TryGetValue(to, out previousPassengerCount)
                ? previousPassengerCount - passengerCount
                : -passengerCount;
        }

        var currentPassengerCount = 0;
        foreach (var kvp in map)
        {
            currentPassengerCount += kvp.Value;
            if (currentPassengerCount > capacity)
            {
                return false;
            }
        }

        return true;
    }

    public bool CarPooling4(int[][] trips, int capacity)
    {
        const int passengerCountIndex = 0;
        const int fromIndex = 1;
        const int toIndex = 2;

        var map = new Dictionary<int, int>();
        foreach (var trip in trips)
        {
            var passengerCount = trip[passengerCountIndex];
            var from = trip[fromIndex];
            var to = trip[toIndex];

            map[from] = map.TryGetValue(from, out var previousPassengerCount)
                ? previousPassengerCount + passengerCount
                : passengerCount;

            map[to] = map.TryGetValue(to, out previousPassengerCount)
                ? previousPassengerCount - passengerCount
                : -passengerCount;
        }

        var currentPassengerCount = 0;
        var currentDistance = 0;
        var stopCount = 0;
        while (stopCount < map.Count)
        {
            if(map.TryGetValue(currentDistance, out var passengerCount))
            {
                currentPassengerCount += passengerCount;
                if (currentPassengerCount > capacity)
                {
                    return false;
                }

                stopCount++;
            }

            currentDistance++;
        }

        return true;
    }

    public bool CarPooling5(int[][] trips, int capacity)
    {
        const int passengerCountIndex = 0;
        const int fromIndex = 1;
        const int toIndex = 2;

        Span<int> map = stackalloc int[1001];
        foreach (var trip in trips)
        {
            var passengerCount = trip[passengerCountIndex];
            var from = trip[fromIndex];
            var to = trip[toIndex];

            map[from] += passengerCount;
            map[to] -= passengerCount;
        }

        var currentPassengerCount = 0;
        foreach(var passengerCount in map)
        {
            currentPassengerCount += passengerCount;
            if (currentPassengerCount > capacity)
            {
                return false;
            }
        }

        return true;
    }
}
