using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.TreesAndGraphs.Graphs.DFS;

internal class _1466_ReorderRoutesToMakeAllPathsLeadToCityZero
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var connections1 = new int[][]
            {
                [0, 1],
                [1, 3],
                [2, 3],
                [4, 0],
                [4, 5]
            };

            var connections2 = new int[][] { [0, 1], [1, 3], [2, 3], [4, 0], [4, 5] };

            Test1(6, connections1);
            Test1(6, connections2);
        }

        private void Test1(int n, int[][] connections)
        {
            List<(string Name, string? Value)> parameters =
            [
                (nameof(n), n.ToString()),
                (nameof(connections), Environment.NewLine + JsonSerializer.Serialize(connections))
            ];

            var result = new _1466_ReorderRoutesToMakeAllPathsLeadToCityZero().MinReorder(n, connections);

            List<(string Name, string? Value)> processedParameters =
            [
                (nameof(n), n.ToString()),
                (nameof(connections), Environment.NewLine + JsonSerializer.Serialize(connections))
            ];

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    /// <summary>
    /// DFS. Recursion
    /// </summary>
    public int MinReorder(int n, int[][] connections)
    {
        var cityMap = new List<int>[n];
        var roads = new HashSet<(int cityFrom, int cityTo)>();
        var processedCities = new HashSet<int>();

        for(var city = 0; city < n; city++)
        {
            cityMap[city] = new List<int>();
        }

        for (var connectionIndex = 0; connectionIndex < connections.Length; connectionIndex++)
        {
            var connection = connections[connectionIndex];

            cityMap[connection[0]].Add(connection[1]);
            cityMap[connection[1]].Add(connection[0]);

            roads.Add((connection[0], connection[1]));
        }

        var answer = 0;

        Dfs(0);

        return answer;

        void Dfs(int parentCity)
        {
            processedCities.Add(parentCity);
            var childCities = cityMap[parentCity];

            for (var childCityIndex = 0; childCityIndex < childCities.Count; childCityIndex++)
            {
                var childCity = childCities[childCityIndex];
                if (processedCities.Contains(childCity))
                {
                    continue;
                }

                if(!roads.Contains((childCity, parentCity)))
                {
                    answer++;
                }

                Dfs(childCity);
            }
        }
    }

    /// <summary>
    /// DFS. Stack.
    /// </summary>
    public int MinReorder2(int n, int[][] connections)
    {
        var answer = 0;

        var graph = new List<int>[n];
        var roads = new HashSet<(int CityFrom, int CityTo)>();
        var processedCities = new HashSet<int>();

        for (var cityIndex = 0; cityIndex < n; cityIndex++)
        {
            graph[cityIndex] = new List<int>();
        }

        for(var connectionIndex = 0; connectionIndex < connections.Length; connectionIndex++)
        {
            var connection = connections[connectionIndex];

            graph[connection[0]].Add(connection[1]);
            graph[connection[1]].Add(connection[0]);

            roads.Add((connection[0], connection[1]));
        }

        var stack = new Stack<int>();
        stack.Push(0);

        while (stack.TryPop(out var parentCity))
        {
            processedCities.Add(parentCity);

            var childCities = graph[parentCity];
            for(var childCityIndex = 0; childCityIndex < childCities.Count; childCityIndex++)
            {
                var childCity = childCities[childCityIndex];

                if (processedCities.Contains(childCity))
                {
                    continue;
                }

                if (!roads.Contains((childCity, parentCity)))
                {
                    answer++;
                }

                stack.Push(childCity);
            }
        }

        return answer;
    }
}
