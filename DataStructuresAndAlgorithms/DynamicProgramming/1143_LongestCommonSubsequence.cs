using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.DynamicProgramming;

internal class _1143_LongestCommonSubsequence
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test("abcde", "ace");
        }

        private void Test(string text1, string text2)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(text1), JsonSerializer.Serialize(text1)),
                (nameof(text2), JsonSerializer.Serialize(text2))
            };

            var result = new _1143_LongestCommonSubsequence().LongestCommonSubsequence(text1, text2);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(text1), JsonSerializer.Serialize(text1)),
                (nameof(text2), JsonSerializer.Serialize(text2))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int LongestCommonSubsequence(string text1, string text2)
    {
        var n = text1.Length;
        var m = text2.Length;
        var dp = new int[n + 1, m + 1];

        for (var i = n - 1; i >= 0; i--)
        {
            for (var j = m - 1; j >= 0; j--)
            {
                var letter1 = text1[i];
                var letter2 = text2[j];

                var currentLenght = letter1 == letter2
                    ? 1 + dp[i + 1, j + 1]
                    : Math.Max(dp[i + 1, j], dp[i, j + 1]);

                dp[i, j] = currentLenght;
            }
        }

        return dp[0, 0];
    }

    public int LongestCommonSubsequence2(string text1, string text2)
    {
        var n = text1.Length;
        var m = text2.Length;
        var currentColumn = new int[m + 1];
        var previousColumn = new int[m + 1];

        for (var i = n - 1; i >= 0; i--)
        {
            for (var j = m - 1; j >= 0; j--)
            {
                var letter1 = text1[i];
                var letter2 = text2[j];

                currentColumn[j] = letter1 == letter2
                    ? 1 + previousColumn[j + 1]
                    : Math.Max(previousColumn[j], currentColumn[j + 1]);
            }

            var temp = previousColumn;
            previousColumn = currentColumn;
            currentColumn = temp;
        }

        return previousColumn[0];
    }
}
