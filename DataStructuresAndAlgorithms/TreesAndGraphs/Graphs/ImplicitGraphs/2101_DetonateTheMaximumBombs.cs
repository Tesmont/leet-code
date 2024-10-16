using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.TreesAndGraphs.Graphs.ImplicitGraphs;

internal class _2101_DetonateTheMaximumBombs
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var bombs1 = new int[][]
            {
                [2, 1, 3],
                [6, 1, 4]
            };

            Test(bombs1);

            var bombs2 = new int[][]
            {
                [1,1,100000],
                [100000,100000,1]
            };
            Test(bombs2);
        }

        private void Test(int[][] bombs)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(bombs), JsonSerializer.Serialize(bombs))
            };

            var result = new _2101_DetonateTheMaximumBombs().MaximumDetonation(bombs);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(bombs), JsonSerializer.Serialize(bombs))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int MaximumDetonation(int[][] bombs)
    {
        var graph = CreateGraph(bombs);
        var maxConnectedVertexCount = 0;

        var stack = new Stack<List<int>>();
        var visitedVerticies = new bool[graph.Length];

        for (var vertex = 0; vertex < graph.Length; vertex++)
        {
            var connectedVertexCount = 0;

            stack.Push(graph[vertex]);
            visitedVerticies[vertex] = true;

            while (stack.TryPop(out var connectedVerticies))
            {
                connectedVertexCount++;

                foreach(var connectedVertex in connectedVerticies)
                {
                    if(visitedVerticies[connectedVertex])
                    {
                        continue;
                    }

                    stack.Push(graph[connectedVertex]);
                    visitedVerticies[connectedVertex] = true;
                }
            }

            maxConnectedVertexCount = Math.Max(connectedVertexCount, maxConnectedVertexCount);
            stack.Clear();
            Array.Fill(visitedVerticies, false);
        }

        return maxConnectedVertexCount;
    }

    private List<int>[] CreateGraph(int[][] bombs)
    {
        //(x1 - x2)^2 + (y1 - y2)^2 = d^2

        const int rowIndex = 0;
        const int columnIndex = 1;
        const int radiusIndex = 2;

        var graph = new List<int>[bombs.Length];

        for (var vertexIndex = 0; vertexIndex < graph.Length; vertexIndex++)
        {
            var connectedBombs = new List<int>();
            graph[vertexIndex] = connectedBombs;

            var row1 = bombs[vertexIndex][rowIndex];
            var column1 = bombs[vertexIndex][columnIndex];

            long radius = bombs[vertexIndex][radiusIndex];
            radius = radius * radius;

            for (var connectedVertexIndex = 0; connectedVertexIndex < vertexIndex; connectedVertexIndex++)
            {
                var row2 = bombs[connectedVertexIndex][rowIndex];
                var column2 = bombs[connectedVertexIndex][columnIndex];

                long rowDiff = row1 - row2;
                long columnDiff = column1 - column2;

                var distance = (rowDiff * rowDiff) + (columnDiff * columnDiff);
                if (distance <= radius)
                {
                    connectedBombs.Add(connectedVertexIndex);
                }
            }

            for (var connectedVertexIndex = vertexIndex + 1; connectedVertexIndex < graph.Length; connectedVertexIndex++)
            {
                var row2 = bombs[connectedVertexIndex][rowIndex];
                var column2 = bombs[connectedVertexIndex][columnIndex];

                long rowDiff = row1 - row2;
                long columnDiff = column1 - column2;

                var distance = (rowDiff * rowDiff) + (columnDiff * columnDiff);
                if (distance <= radius)
                {
                    connectedBombs.Add(connectedVertexIndex);
                }
            }
        }

        return graph;
    }
}
