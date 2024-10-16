using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.Backtracking;

internal class _0967_NumbersWithSameConsecutiveDifferences
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var n = 3;
            var k = 0;
            Test(n, k);
        }

        private void Test(int n, int k)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(n), JsonSerializer.Serialize(n)),
                (nameof(k), JsonSerializer.Serialize(k))
            };

            var result = new _0967_NumbersWithSameConsecutiveDifferences().NumsSameConsecDiff(n, k);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(n), JsonSerializer.Serialize(n)),
                (nameof(k), JsonSerializer.Serialize(k))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int[] NumsSameConsecDiff(int n, int k)
    {
        var result = new List<int>();
        for(var i = 1; i <= 9; i++)
        {
            Backtrack(i, 1, i);
        }

        return result.ToArray();

        void Backtrack(int value, int valueLength, int lastInteger)
        {
            if (valueLength == n)
            {
                result.Add(value);

                return;
            }

            value *= 10;
            valueLength++;

            var child1 = lastInteger - k;
            if(child1 >= 0)
            {
                Backtrack(value + child1, valueLength, child1);
            }

            var child2 = lastInteger + k;
            if (child2 <= 9 && child2 != child1)
            {
                Backtrack(value + child2, valueLength, child2);
            }
        }
    }
}
