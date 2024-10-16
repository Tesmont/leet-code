using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.TreesAndGraphs.Graphs.DFS;

internal class _1971_FindIfPathExistsInGraph
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var edges1 = new int[][]
            {
                [0, 1],
                [1, 2],
                [2, 0]
            };

            var edges2 = new int[][]
            {
                [4,3],[1,4],[4,8],[1,7],[6,4],[4,2],[7,4],[4,0],[0,9],[5,4]
            };

            var edges3 = new int[][]
            {
                [0,7],[0,8],[6,1],[2,0],[0,4],[5,8],[4,7],[1,3],[3,5],[6,5]
            };

            Test1(3, edges1, 0, 2);
            Test1(10, edges2, 5, 9);
            Test1(10, edges3, 7, 5);
        }

        private void Test1(int n, int[][] edges, int source, int destination)
        {
            List<(string Name, string? Value)> parameters =
            [
                (nameof(n), n.ToString()),
                (nameof(edges), Environment.NewLine + JsonSerializer.Serialize(edges)),
                (nameof(source), source.ToString()),
                (nameof(destination), destination.ToString())
            ];

            var result = new _1971_FindIfPathExistsInGraph().ValidPath(n, edges, source, destination);

            List<(string Name, string? Value)> processedParameters =
            [
                (nameof(n), n.ToString()),
                (nameof(edges), Environment.NewLine + JsonSerializer.Serialize(edges)),
                (nameof(source), source.ToString()),
                (nameof(destination), destination.ToString())
            ];

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public bool ValidPath(int n, int[][] edges, int source, int destination)
    {
        if (source == destination)
        {
            return true;
        }

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

        var stack = new Stack<List<int>>();
        var visitedVerticies = new bool[n];

        stack.Push(graph[source]);
        visitedVerticies[source] = true;

        while (stack.TryPop(out var childVerticies))
        {
            for (var vertexIndex = 0; vertexIndex < childVerticies.Count; vertexIndex++)
            {
                var childVertex = childVerticies[vertexIndex];
                if (visitedVerticies[childVertex])
                {
                    continue;
                }

                if(childVertex == destination)
                {
                    return true;
                }

                stack.Push(graph[childVertex]);
                visitedVerticies[childVertex] = true;
            }
        }

        return false;
    }
}
