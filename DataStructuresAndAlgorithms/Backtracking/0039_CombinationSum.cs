using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.Backtracking;

internal class _0039_CombinationSum
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var candidates = new int[] { 2, 3, 6, 7 };
            var target = 7;
            Test(candidates, target);
        }

        private void Test(int[] candidates, int target)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(candidates), JsonSerializer.Serialize(candidates)),
                (nameof(target), JsonSerializer.Serialize(target))
            };

            var result = new _0039_CombinationSum().CombinationSum(candidates, target);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(candidates), JsonSerializer.Serialize(candidates)),
                (nameof(target), JsonSerializer.Serialize(target))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        Array.Sort(candidates);

        var result = new List<IList<int>>();
        var stack = new Stack<(List<int> values, int sum, int candidateIndex)>();
        stack.Push((new(), 0, 0));

        while(stack.TryPop(out var tuple))
        {
            if (tuple.sum == target)
            {
                result.Add(tuple.values);
                continue;
            }

            if(tuple.sum > target
                || tuple.candidateIndex == candidates.Length)
            {
                continue;
            }

            for(var i = tuple.candidateIndex; i < candidates.Length; i++) 
            {
                var candidate = candidates[i];

                var newValues = new List<int>(tuple.values);
                newValues.Add(candidate);

                var newSum = tuple.sum + candidate;

                stack.Push((newValues, newSum, i));
            }
        }

        return result;
    }
}
