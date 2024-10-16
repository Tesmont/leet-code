using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.TreesAndGraphs.Graphs.ImplicitGraphs;

internal class _0399_EvaluateDivision
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var equations1 = new List<IList<string>>
            {
                new List<string> { "a", "b" },
                new List<string> { "b", "c" }
            };
            var values1 = new double[] { 2.0, 3.0 };
            var queries1 = new List<IList<string>>
            {
                new List<string> { "a", "c" },
                new List<string> { "b", "a" },
                new List<string> { "a", "e" },
                new List<string> { "a", "a" },
                new List<string> { "x", "x" }
            };

            Test1(equations1, values1, queries1);
        }

        private void Test1(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(equations), JsonSerializer.Serialize(equations)),
                (nameof(values), JsonSerializer.Serialize(values)),
                (nameof(queries), JsonSerializer.Serialize(queries))
            };

            var result = new _0399_EvaluateDivision().CalcEquation(equations, values, queries);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(equations), JsonSerializer.Serialize(equations)),
                (nameof(values), JsonSerializer.Serialize(values)),
                (nameof(queries), JsonSerializer.Serialize(queries))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
    {
        var graph = CreateGraph(equations, values);
        var result = new double[queries.Count];

        for (int i = 0; i < queries.Count(); i++)
        {
            var query = queries[i];

            if (!graph.ContainsKey(query[0]) || !graph.ContainsKey(query[1]))
            { 
                result[i] = -1.0;
            }
            else if (query[0] == query[1])
            {
                result[i] = 1.0;
            }
            else
            {
                result[i] = DFS(graph, query);
            }
        }

        return result;
    }

    private Dictionary<string, Dictionary<string, double>> CreateGraph(IList<IList<string>> equations, double[] values)
    {
        var graph = new Dictionary<string, Dictionary<string, double>>();
        for (var i = 0; i < equations.Count; i++)
        {
            var equation = equations[i];

            if(!graph.TryGetValue(equation[0], out var value))
            {
                value = new Dictionary<string, double>();
                graph[equation[0]] = value;
            }

            value.Add(equation[1], values[i]);

            if (!graph.TryGetValue(equation[1], out value))
            {
                value = new Dictionary<string, double>();
                graph[equation[1]] = value;
            }

            value.Add(equation[0], 1 / values[i]);
        }

        return graph;
    }

    private double DFS(Dictionary<string, Dictionary<string, double>> graph, IList<string> query)
    {
        var visitedVerticies = new HashSet<string>();
        var stack = new Stack<(string Vertex, double Ratio)>();
        stack.Push((query[0], 1.0));
        visitedVerticies.Add(query[0]);

        while(stack.TryPop(out var tuple))
        {
            if(tuple.Vertex == query[1])
            {
                return tuple.Ratio;
            }

            var connectedVerticies = graph[tuple.Vertex];
            foreach (var connectedVertex in connectedVerticies)
            {
                if(visitedVerticies.Contains(connectedVertex.Key))
                {
                    continue;
                }

                stack.Push((connectedVertex.Key, tuple.Ratio * connectedVertex.Value));
                visitedVerticies.Add(connectedVertex.Key);
            }
        }

        return -1;
    }
}
