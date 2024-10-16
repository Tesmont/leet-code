using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.TreesAndGraphs.Graphs.DFS;

internal class _0841_KeysAndRooms
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var rooms1 = new List<IList<int>>
            {
                new List<int> { 1 },
                new List<int> { 2 },
                new List<int> { 3 },
                new List<int>()
            };

            Test1(rooms1);
        }

        private void Test1(IList<IList<int>> rooms)
        {
            List<(string Name, string? Value)> parameters =
            [
                (nameof(rooms), Environment.NewLine + JsonSerializer.Serialize(rooms))
            ];

            var result = new _0841_KeysAndRooms().CanVisitAllRooms(rooms);

            List<(string Name, string? Value)> processedParameters =
            [
                (nameof(rooms), Environment.NewLine + JsonSerializer.Serialize(rooms))
            ];

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    /// <summary>
    /// DFS. Stack
    /// </summary>
    public bool CanVisitAllRooms(IList<IList<int>> rooms)
    {
        var visitedRooms = new bool[rooms.Count];
        visitedRooms[0] = true;

        var stack = new Stack<IList<int>>();
        stack.Push(rooms[0]);

        while(stack.TryPop(out var keys))
        {
            for (var i = 0; i < keys.Count; i++)
            {
                var key = keys[i];
                if (visitedRooms[key])
                {
                    continue;
                }

                stack.Push(rooms[key]);
                visitedRooms[key] = true;
            }
        }

        return visitedRooms.All(i => i);
    }
}
