using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.Backtracking;

internal class _0077_Combinations
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var n = 4;
            var k = 2;
            Test(n, k);
        }

        private void Test(int n, int k)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(n), JsonSerializer.Serialize(n)),
                (nameof(k), JsonSerializer.Serialize(k))
            };

            var result = new _0077_Combinations().Combine(n, k);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(n), JsonSerializer.Serialize(n)),
                (nameof(k), JsonSerializer.Serialize(k))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public IList<IList<int>> Combine(int n, int k)
    {
        var result = new List<IList<int>>();
        var buffer = new HashSet<int>(k);
        Backtrack(1);

        return result;
        
        void Backtrack(int index)
        {
            if(buffer.Count == k)
            {
                result.Add(new List<int>(buffer));
                return;
            }

            for(var i = index; i <= n; i++)
            {
                if(buffer.Contains(i))
                {
                    continue;
                }

                buffer.Add(i);
                Backtrack(i + 1);
                buffer.Remove(i);
            }
        }
    }
}
