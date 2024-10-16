using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.Backtracking;

internal class _0022_GenerateParentheses
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var n = 3;
            Test(n);
        }

        private void Test(int n)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(n), JsonSerializer.Serialize(n))
            };

            var result = new _0022_GenerateParentheses().GenerateParenthesis(n);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(n), JsonSerializer.Serialize(n))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public IList<string> GenerateParenthesis(int n)
    {
        var result = new List<string>();
        var buffer = new char[n * 2];

        Backtrack(0, 0);

        return result;

        void Backtrack(int openedCount, int closedCount)
        {
            if (closedCount == n)
            {
                result.Add(new string(buffer));
                return;
            }

            var bufferIndex = openedCount + closedCount;
            if(closedCount < openedCount)
            {
                buffer[bufferIndex] = ')';
                Backtrack(openedCount, closedCount + 1);
            }

            if (openedCount < n)
            {
                buffer[bufferIndex] = '(';
                Backtrack(openedCount + 1, closedCount);
            }
        }
    }
}
