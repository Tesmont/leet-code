using Helpers;
using System.Text;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.TreesAndGraphs.Graphs.ImplicitGraphs;

internal class _0127_WordLadder
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var beginWord = "hit";
            var endWord = "cog";
            var wordList = new List<string> { "hot", "dot", "dog", "lot", "log", "cog" };
            Test(beginWord, endWord, wordList);
        }

        private void Test(string beginWord, string endWord, IList<string> wordList)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(beginWord), JsonSerializer.Serialize(beginWord)),
                (nameof(endWord), JsonSerializer.Serialize(endWord)),
                (nameof(wordList), JsonSerializer.Serialize(wordList))
            };

            var result = new _0127_WordLadder().LadderLength(beginWord, endWord, wordList);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(beginWord), JsonSerializer.Serialize(beginWord)),
                (nameof(endWord), JsonSerializer.Serialize(endWord)),
                (nameof(wordList), JsonSerializer.Serialize(wordList))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    /// <summary>
    /// BFS
    /// </summary>
    public int LadderLength(string beginWord, string endWord, IList<string> wordList)
    {
        var combinationMap = BuildCombinationMap(wordList);

        var queue = new Queue<string>();
        var visitedVerticies = new HashSet<string>();

        queue.Enqueue(beginWord);
        visitedVerticies.Add(beginWord);

        var sequenceLenght = 1;

        while (queue.Count > 0)
        {
            var vertexCount = queue.Count;

            for (var vertexCounter = 0; vertexCounter < vertexCount; vertexCounter++)
            {
                var vertex = queue.Dequeue();

                if(vertex == endWord)
                {
                    return sequenceLenght;
                }

                foreach(var vertexKey in GetVertexKeys(vertex))
                {
                    if(!combinationMap.TryGetValue(vertexKey, out var connectedVerticies))
                    {
                        continue;
                    }

                    foreach(var connectedVertex in connectedVerticies)
                    {
                        if(!visitedVerticies.Add(connectedVertex))
                        {
                            continue;
                        }

                        queue.Enqueue(connectedVertex);
                    }
                }
            }

            sequenceLenght++;
        }

        return 0;
    }

    private Dictionary<string, List<string>> BuildCombinationMap(IList<string> availableVerticies)
    {
        var combinationMap = new Dictionary<string, List<string>>();

        foreach (var availableVertex in availableVerticies)
        {
            foreach(var availableVertexKey in GetVertexKeys(availableVertex))
            {
                if(!combinationMap.TryGetValue(availableVertexKey, out var combinations))
                {
                    combinations = new List<string>();
                    combinationMap[availableVertexKey] = combinations;
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
