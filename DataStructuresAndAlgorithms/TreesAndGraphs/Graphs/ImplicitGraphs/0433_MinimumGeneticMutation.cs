using Helpers;
using System.Text;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.TreesAndGraphs.Graphs.ImplicitGraphs;

internal class _0433_MinimumGeneticMutation
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var startGene = "AACCGGTT";
            var endGene = "AACCGGTA";
            var bank = new string[] { "AACCGGTA" };

            Test1(startGene, endGene, bank);
        }

        private void Test1(string startGene, string endGene, string[] bank)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(startGene), JsonSerializer.Serialize(startGene)),
                (nameof(endGene), JsonSerializer.Serialize(endGene)),
                (nameof(bank), JsonSerializer.Serialize(bank))
            };

            var result = new _0433_MinimumGeneticMutation().MinMutation(startGene, endGene, bank);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(startGene), JsonSerializer.Serialize(startGene)),
                (nameof(endGene), JsonSerializer.Serialize(endGene)),
                (nameof(bank), JsonSerializer.Serialize(bank))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    /// <summary>
    /// BFS
    /// </summary>
    public int MinMutation(string startGene, string endGene, string[] bank)
    {
        var combinationMap = GetCombinationMap(bank);

        var visitedVertcies = new HashSet<string>();
        var queue = new Queue<string>();

        visitedVertcies.Add(startGene);
        queue.Enqueue(startGene);

        var step = 0;
        while (queue.Count > 0)
        {
            var vertexCount = queue.Count;

            for (var vertexCounter = 0; vertexCounter < vertexCount; vertexCounter++)
            {
                var vertex = queue.Dequeue();

                if(vertex == endGene)
                {
                    return step;
                }

                foreach (var vertexKey in GetVertexKeys(vertex))
                {
                    if(!combinationMap.TryGetValue(vertexKey, out var availableVerticies))
                    {
                        continue;
                    }

                    foreach (var availableVertex in availableVerticies)
                    {
                        if (visitedVertcies.Contains(availableVertex))
                        {
                            continue;
                        }

                        queue.Enqueue(availableVertex);
                        visitedVertcies.Add(availableVertex);
                    }
                }
            }

            step++;
        }

        return -1;
    }

    private Dictionary<string, List<string>> GetCombinationMap(string[] availableVerticies)
    {
        var combinationMap = new Dictionary<string, List<string>>();

        foreach (var availableVertex in availableVerticies)
        {
            var vertexKeyBuilder = new StringBuilder(availableVertex);

            foreach(var vertexKey in GetVertexKeys(availableVertex))
            {
                if (!combinationMap.TryGetValue(vertexKey, out var combinations))
                {
                    combinations = new List<string>();
                    combinationMap[vertexKey] = combinations;
                }

                combinations.Add(availableVertex);
            }
        }

        return combinationMap;
    }

    private IEnumerable<string> GetVertexKeys(string vertex)
    {
        var vertexKeyBuilder = new StringBuilder(vertex);
        for (var i = 0; i < vertex.Length; i++)
        {
            vertexKeyBuilder[i] = '*';
            var vertexKey = vertexKeyBuilder.ToString();
            vertexKeyBuilder[i] = vertex[i];

            yield return vertexKey;
        }
    }
}
