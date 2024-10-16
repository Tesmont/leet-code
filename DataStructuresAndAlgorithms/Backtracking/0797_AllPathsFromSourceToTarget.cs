using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.Backtracking;

internal class _0797_AllPathsFromSourceToTarget
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var graph = new int[][]
            {
                [1, 2],
                [3],
                [3],
                []
            };
            Test(graph);
        }

        private void Test(int[][] graph)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(graph), JsonSerializer.Serialize(graph))
            };

            var result = new _0797_AllPathsFromSourceToTarget().AllPathsSourceTarget(graph);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(graph), JsonSerializer.Serialize(graph))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
    {
        var startVertex = 0;
        var endVertex = graph.Length - 1;

        var result = new List<IList<int>>();
        var stack = new Stack<(List<int> path, bool[] visitedVerticies)>();

        var path = new List<int>()
        { 
            startVertex
        };
        var visitedVerticies = new bool[graph.Length];
        visitedVerticies[startVertex] = true;

        stack.Push((path, visitedVerticies));

        while(stack.TryPop(out var tuple))
        {
            var lastVertex = tuple.path.Last();
            if (lastVertex == endVertex)
            {
                result.Add(tuple.path);
                continue;
            }

            var availabaleVerticies = graph[lastVertex];
            foreach(var availabaleVertex in availabaleVerticies)
            {
                if(tuple.visitedVerticies[availabaleVertex])
                {
                    continue;
                }

                var newPath = new List<int>(tuple.path);
                newPath.Add(availabaleVertex);
                var newVisitedVerticies = new bool[graph.Length];
                newVisitedVerticies[availabaleVertex] = true;
                Array.Copy(tuple.visitedVerticies, newVisitedVerticies, graph.Length);

                stack.Push((newPath, newVisitedVerticies));
            }
        }

        return result;
    }
}
