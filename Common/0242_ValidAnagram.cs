using Helpers;
using System.Text.Json;

namespace Common;

internal class _0242_ValidAnagram
{
    internal class Tester
    {
        public void LaunchTests()
        {
            string s = "anagram";
            string t = "nagaram";
            Test(s, t);
        }

        private void Test(string s, string t)
        {
            // Serialize parameters before the method call
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(s), JsonSerializer.Serialize(s)),
                (nameof(t), JsonSerializer.Serialize(t))
            };

            // Call the method to test
            var result = new _0242_ValidAnagram().IsAnagram(s, t);

            // Serialize parameters after the method call
            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(s), JsonSerializer.Serialize(s)),
                (nameof(t), JsonSerializer.Serialize(t))
            };

            // Serialize the result
            var resultStr = JsonSerializer.Serialize(result);

            // Print the comparison table
            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length)
        {
            return false;
        }

        Span<int> sum = stackalloc int['z' + 1];
        for (var i = 0; i < s.Length; i++)
        {
            sum[s[i]]++;
            sum[t[i]]--;
        }

        for (var i = 'a'; i < sum.Length; i++)
        {
            if (sum[i] != 0)
            {
                return false;
            }
        }

        return true;
    }
}
