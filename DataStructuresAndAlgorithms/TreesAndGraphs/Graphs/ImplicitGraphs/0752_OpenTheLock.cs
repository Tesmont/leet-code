using Helpers;
using System.Runtime.Serialization.Formatters;
using System.Security.AccessControl;
using System.Text;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.TreesAndGraphs.Graphs.ImplicitGraphs;

internal class _0752_OpenTheLock
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var deadends1 = new string[] { "0201", "0101", "0102", "1212", "2002" };
            var target1 = "0202";

            Test1(deadends1, target1);
        }

        private void Test1(string[] deadends, string target)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(deadends), JsonSerializer.Serialize(deadends)),
                (nameof(target), target)
            };

            var result = new _0752_OpenTheLock().OpenLock(deadends, target);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(deadends), JsonSerializer.Serialize(deadends)),
                (nameof(target), target)
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int OpenLock(string[] deadends, string target)
    {
        const string startVertex = "0000";
        var visitedVerticies = deadends.ToHashSet();

        if (visitedVerticies.Contains(startVertex))
        {
            return -1;
        }

        var queue = new Queue<string>();
        queue.Enqueue(startVertex);

        var level = 0;
        while (queue.Count > 0)
        {
            var vertexCount = queue.Count;

            for (var i = 0; i < vertexCount; i++)
            {
                var vertex = queue.Dequeue();

                if(vertex == target)
                {
                    return level;
                }

                var vertexBuilder = new StringBuilder(vertex);

                for (var j = 0; j < vertex.Length; j++)
                {
                    const int shift = 48;
                    var value = vertex[j] - shift;

                    var incementedValue = (value + 1) % 10;
                    vertexBuilder[j] = (char)(incementedValue + shift);
                    var incrementedVertex = vertexBuilder.ToString();
                    if(visitedVerticies.Add(incrementedVertex))
                    {
                        queue.Enqueue(incrementedVertex);
                    }

                    var decrementedValue = (value - 1 + 10) % 10;
                    vertexBuilder[j] = (char)(decrementedValue + shift);
                    var decrementedVertex = vertexBuilder.ToString();
                    if (visitedVerticies.Add(decrementedVertex))
                    {
                        queue.Enqueue(decrementedVertex);
                    }

                    vertexBuilder[j] = vertex[j];
                }
            }

            level++;
        }

        return -1;
    }
}
