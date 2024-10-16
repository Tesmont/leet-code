using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.TreesAndGraphs.Graphs.DFS;

internal class _1557_MinimumNumberOfVerticesToReachAllNodes
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var edges1 = new List<IList<int>>
            {
                new List<int> { 0, 1 },
                new List<int> { 0, 2 },
                new List<int> { 2, 5 },
                new List<int> { 3, 4 },
                new List<int> { 4, 2 }
            };

            Test1(6, edges1);
        }

        private void Test1(int n, IList<IList<int>> edges)
        {
            List<(string Name, string? Value)> parameters =
            [
                (nameof(n), n.ToString()),
                (nameof(edges), Environment.NewLine + JsonSerializer.Serialize(edges))
            ];

            var result = new _1557_MinimumNumberOfVerticesToReachAllNodes().FindSmallestSetOfVertices(n, edges);

            List<(string Name, string? Value)> processedParameters =
            [
                (nameof(n), n.ToString()),
                (nameof(edges), Environment.NewLine + JsonSerializer.Serialize(edges))
            ];

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public IList<int> FindSmallestSetOfVertices(int n, IList<IList<int>> edges)
    {
        var verticies = new bool[n];
        for (var edgeIndex = 0; edgeIndex < edges.Count; edgeIndex++)
        {
            var childVertex = edges[edgeIndex][1];

            verticies[childVertex] = true;
        }

        var result = new List<int>(n);

        for (var vertex = 0; vertex < verticies.Length; vertex++)
        {
            if (verticies[vertex])
            {
                continue;
            }

            result.Add(vertex);
        }

        return result;
    }
}
