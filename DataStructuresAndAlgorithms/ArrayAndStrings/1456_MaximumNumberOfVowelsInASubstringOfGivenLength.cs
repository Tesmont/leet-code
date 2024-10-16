using Helpers;

namespace DataStructuresAndAlgorithms.ArrayAndStrings;

internal class _1456_MaximumNumberOfVowelsInASubstringOfGivenLength
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1("abciiidef", 3);
            Test1("aeiou", 2);
            Test1("leetcode", 3);
        }

        private void Test1(string s, int k)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(s), s),
                (nameof(k), k)
                );

            var result = new _1456_MaximumNumberOfVowelsInASubstringOfGivenLength().MaxVowels(s, k);

            printTable.AddProcessedParameters(
                (nameof(s), s),
                (nameof(k), k)
                );

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    private static bool IsVowel(in char ch)
    {
        return ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u';
    }

    private static bool[] _isVowel;

    static _1456_MaximumNumberOfVowelsInASubstringOfGivenLength()
    {
        _isVowel = new bool[256];
        _isVowel['a'] = true;
        _isVowel['e'] = true;
        _isVowel['i'] = true;
        _isVowel['o'] = true;
        _isVowel['u'] = true;
    }

    public int MaxVowels(string s, int k)
    {
        var rightIndex = 0;
        var windowVowelCount = 0;
        for(; rightIndex < k; rightIndex++) 
        {
            if (IsVowel(s[rightIndex]))
            {
                windowVowelCount++;
            }
        }
        var maxWindowVowelCount = windowVowelCount;

        for (; rightIndex < s.Length; rightIndex++)
        {
            if (IsVowel(s[rightIndex]))
            {
                windowVowelCount++;
            }
            if (IsVowel(s[rightIndex - k]))
            {
                windowVowelCount--;
            }

            maxWindowVowelCount = Math.Max(maxWindowVowelCount, windowVowelCount);
        }

        return maxWindowVowelCount;
    }
}