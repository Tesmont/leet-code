using Helpers;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.Backtracking;

internal class _0046_Permutations
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var nums = new int[] { 1, 2, 3 };
            Test(nums);
        }

        private void Test(int[] nums)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(nums), JsonSerializer.Serialize(nums))
            };

            var result = new _0046_Permutations().Permute(nums);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(nums), JsonSerializer.Serialize(nums))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public IList<IList<int>> Permute(int[] nums)
    {
        var answer = new List<IList<int>>();
        Backtrack(new());

        return answer;

        void Backtrack(HashSet<int> current)
        {
            if (current.Count == nums.Length)
            {
                answer.Add(new List<int>(current));
                return;
            }

            foreach (int num in nums)
            {
                if (!current.Contains(num))
                {
                    current.Add(num);
                    Backtrack(current);
                    current.Remove(num);
                }
            }
        }
    }

    public IList<IList<int>> Permute2(int[] nums)
    {
        var answer = new List<IList<int>>();
        var stack = new Stack<HashSet<int>>();
        stack.Push(new HashSet<int>());

        while (stack.TryPop(out var hashSet))
        {
            if (hashSet.Count == nums.Length)
            {
                answer.Add(new List<int>(hashSet));
                continue;
            }

            foreach (int num in nums)
            {
                if (!hashSet.Contains(num))
                {
                    var newHashSet = new HashSet<int>(hashSet);
                    newHashSet.Add(num);
                    stack.Push(newHashSet);
                }
            }
        }

        return answer;
    }
}
