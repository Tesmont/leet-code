using Helpers;
using System.Net.Http.Headers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.TreesAndGraphs.Graphs.DFS;

internal class _2368_ReachableNodesWithRestrictions
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var edges1 = new int[][]
            {
                [0, 1],
                [1, 2],
                [2, 3],
                [0, 4]
            };

            var restricted1 = new int[] { 2, 3 };

            Test1(5, edges1, restricted1);
        }

        private void Test1(int n, int[][] edges, int[] restricted)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(n), n.ToString()),
                (nameof(edges), Environment.NewLine + JsonSerializer.Serialize(edges)),
                (nameof(restricted), Environment.NewLine + JsonSerializer.Serialize(restricted))
            };

            var result = new _2368_ReachableNodesWithRestrictions().ReachableNodes(n, edges, restricted);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(n), n.ToString()),
                (nameof(edges), Environment.NewLine + JsonSerializer.Serialize(edges)),
                (nameof(restricted), Environment.NewLine + JsonSerializer.Serialize(restricted))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int ReachableNodes(int n, int[][] edges, int[] restricted)
    {
        var graph = CreateGraph(n, edges);
        var visitedNodes = CreateVisitedNodes(n, restricted);

        var stack = new Stack<List<int>>();
        stack.Push(graph[0]);
        visitedNodes[0] = true;

        var reachableNodeCount = 1;

        while (stack.TryPop(out var connectedNodes)) 
        {

            for (var i = 0; i < connectedNodes.Count; i++) 
            { 
                var connectedNode = connectedNodes[i];
                if (visitedNodes[connectedNode])
                {
                    continue;
                }

                stack.Push(graph[connectedNode]);
                visitedNodes[connectedNode] = true;
                reachableNodeCount++;
            }
        }
        
        return reachableNodeCount;
    }

    private List<int>[] CreateGraph(int n, int[][] edges)
    {
        var graph = new List<int>[n];
        for (var i = 0; i < n; i++)
        {
            graph[i] = [];
        }

        for (var i = 0; i < edges.Length; i++)
        {
            var edge = edges[i];
            graph[edge[0]].Add(edge[1]);
            graph[edge[1]].Add(edge[0]);
        }

        return graph;
    }

    private bool[] CreateVisitedNodes(int n, int[] restricted)
    {
        var visitedNodes = new bool[n];
        for (var i = 0; i < restricted.Length; i++)
        {
            visitedNodes[restricted[i]] = true;
        }

        return visitedNodes;
    }
}
