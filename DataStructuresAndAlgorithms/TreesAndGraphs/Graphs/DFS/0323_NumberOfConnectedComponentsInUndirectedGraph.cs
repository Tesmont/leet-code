using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.TreesAndGraphs.Graphs.DFS;

internal class _0323_NumberOfConnectedComponentsInUndirectedGraph
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var edges1 = new int[][]
            {
                [0, 1],
                [1, 2],
                [3, 4]
            };

            Test1(5, edges1);
        }

        private void Test1(int n, int[][] edges)
        {
            List<(string Name, string? Value)> parameters =
            [
                (nameof(n), n.ToString()),
                (nameof(edges), Environment.NewLine + JsonSerializer.Serialize(edges))
            ];

            var result = new _0323_NumberOfConnectedComponentsInUndirectedGraph().CountComponents(n, edges);

            List<(string Name, string? Value)> processedParameters =
            [
                (nameof(n), n.ToString()),
                (nameof(edges), Environment.NewLine + JsonSerializer.Serialize(edges))
            ];

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int CountComponents(int n, int[][] edges)
    {
        var graph = CreateGraph(n, edges);

        var visitedVerticies = new bool[n];
        var stack = new Stack<List<int>>();
        var componentCount = 0;

        for (var vertex = 0; vertex < n; vertex++)
        {
            if (visitedVerticies[vertex])
            {
                continue;
            }

            stack.Push(graph[vertex]);
            visitedVerticies[vertex] = true;
            componentCount++;

            while (stack.TryPop(out var connectedVerticies))
            {
                for (var vertexIndex = 0; vertexIndex < connectedVerticies.Count; vertexIndex++)
                {
                    var connectedVertex = connectedVerticies[vertexIndex];
                    if (visitedVerticies[connectedVertex])
                    {
                        continue;
                    }

                    stack.Push(graph[connectedVertex]);
                    visitedVerticies[connectedVertex] = true;
                }
            }
        }

        return componentCount;
    }

    private List<int>[] CreateGraph(int n, int[][] edges)
    {
        var graph = new List<int>[n];
        for (var vertex = 0; vertex < n; vertex++)
        {
            graph[vertex] = [];
        }

        for (var edgeIndex = 0; edgeIndex < edges.Length; edgeIndex++)
        {
            var edge = edges[edgeIndex];
            graph[edge[0]].Add(edge[1]);
            graph[edge[1]].Add(edge[0]);
        }


        return graph;
    }
}
