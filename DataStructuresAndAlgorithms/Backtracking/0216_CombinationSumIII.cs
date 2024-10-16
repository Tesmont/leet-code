using Helpers;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.Backtracking;

internal class _0216_CombinationSumIII
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var k = 3;
            var n = 7;
            Test(k, n);
        }

        private void Test(int k, int n)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(k), JsonSerializer.Serialize(k)),
                (nameof(n), JsonSerializer.Serialize(n))
            };

            var result = new _0216_CombinationSumIII().CombinationSum3(k, n);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(k), JsonSerializer.Serialize(k)),
                (nameof(n), JsonSerializer.Serialize(n))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public IList<IList<int>> CombinationSum3(int k, int n)
    {
        var result = new List<IList<int>>();
        var usedDigits = new bool[10];
        BackTrack(0, 0, 1);

        return result;

        void BackTrack(int lenght, int sum, int startDigit)
        {
            if(lenght == k)
            {
                if(sum == n)
                {
                    result.Add(PeekUsedDigits());
                }

                return;
            }

            if (sum > n)
            {
                return;
            }

            lenght++;
            for (var digit = startDigit; digit <= 9; digit++)
            {
                if (usedDigits[digit])
                {
                    continue;
                }

                usedDigits[digit] = true;
                BackTrack(lenght, sum + digit, digit + 1);
                usedDigits[digit] = false;
            }
        }

        int[] PeekUsedDigits()
        {
            var array = new int[k];
            var arrayIndex = 0;
            for(var i = 0; i < usedDigits.Length; i++)
            {
                if(usedDigits[i])
                {
                    array[arrayIndex++] = i;
                }
            }

            return array;
        }
    }
}
