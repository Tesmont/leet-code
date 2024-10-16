using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.TreesAndGraphs.Graphs.BFS;

internal class _1129_ShortestPathWithAlternatingColors
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var redEdges = new int[][]
            {
                [0, 1],
                [1, 2]
            };

            var blueEdges = new int[][]
            {
                [2, 3],
                [3, 4]
            };

            Test1(5, redEdges, blueEdges);
        }

        private void Test1(int n, int[][] redEdges, int[][] blueEdges)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(n), n.ToString()),
                (nameof(redEdges), Environment.NewLine + JsonSerializer.Serialize(redEdges)),
                (nameof(blueEdges), Environment.NewLine + JsonSerializer.Serialize(blueEdges))
            };

            var result = new _1129_ShortestPathWithAlternatingColors().ShortestAlternatingPaths(n, redEdges, blueEdges);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(n), n.ToString()),
                (nameof(redEdges), Environment.NewLine + JsonSerializer.Serialize(redEdges)),
                (nameof(blueEdges), Environment.NewLine + JsonSerializer.Serialize(blueEdges))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int[] ShortestAlternatingPaths(int n, int[][] redEdges, int[][] blueEdges)
    {
        const int red = 0;
        const int blue = 1;

        var redGraph = BuildGraph(n, redEdges);
        var blueGraph = BuildGraph(n, blueEdges);

        var graphs = new List<int>[2][];
        graphs[red] = redGraph;
        graphs[blue] = blueGraph;

        var queue = new Queue<(int Vertex, int Color)>();
        queue.Enqueue((0, red));
        queue.Enqueue((0, blue));

        var visitedVertcices = new bool[n, 2];
        visitedVertcices[0, red] = true;
        visitedVertcices[0, blue] = true;

        var result = new int[n];
        Array.Fill(result, int.MaxValue, 1, n - 1);

        var level = 0;
        while (queue.Count > 0)
        {
            var vertexCount = queue.Count;
            level++;

            for (var i = 0; i < vertexCount; i++)
            {
                var (Vertex, Color) = queue.Dequeue();
                var nextColor = Color ^ 1;
                var graph = graphs[Color];
                for (var j = 0; j < graph[Vertex].Count; j++)
                {
                    var connectedVertex = graph[Vertex][j];

                    if (visitedVertcices[connectedVertex, nextColor])
                    {
                        continue;
                    }

                    queue.Enqueue((connectedVertex, nextColor));
                    visitedVertcices[connectedVertex, nextColor] = true;
                    result[connectedVertex] = Math.Min(level, result[connectedVertex]);
                }
            }
        }

        for(var i = 0; i < n; i++)
        {
            if (result[i] == int.MaxValue)
            {
                result[i] = -1;
            }
        }

        return result;
    }

    private List<int>[] BuildGraph(int n, int[][] edges)
    {
        var graph = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            graph[i] = new List<int>();
        }

        for (var i = 0; i < edges.Length; i++)
        {
            var edge = edges[i];
            graph[edge[0]].Add(edge[1]);
        }

        return graph;
    }
}
