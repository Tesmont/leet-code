using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.Bonus;

internal class _2575_FindTheDivisibilityArrayOfAString
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var word = "1010";
            var m = 10;
            Test(word, m);
        }

        private void Test(string word, int m)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(word), JsonSerializer.Serialize(word)),
                (nameof(m), JsonSerializer.Serialize(m))
            };

            var result = new _2575_FindTheDivisibilityArrayOfAString().DivisibilityArray(word, m);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(word), JsonSerializer.Serialize(word)),
                (nameof(m), JsonSerializer.Serialize(m))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int[] DivisibilityArray(string word, int m)
    {
        var answer = new int[word.Length];

        var remainder = 0L;
        for(var i = 0; i < word.Length; i++)
        {
            var digit = word[i] - '0';
            remainder = digit == 0
                ? (remainder * 10) % m
                : (remainder * 10 + digit) % m;
            answer[i] = remainder == 0 
                ? 1 
                : 0;
        }
        
        return answer;
    }
}
