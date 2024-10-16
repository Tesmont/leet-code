using Helpers;

namespace DataStructuresAndAlgorithms.Hashing;

internal class _0290_WordPattern
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1("abba", "dog cat cat dog");
            Test1("abba", "dog cat cat fish");
            Test1("aaaa", "dog cat cat dog");
            Test1("abba", "dog dog dog dog");
            Test1("abc", "b c a");
        }

        private void Test1(string pattern, string s)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(pattern), pattern),
                (nameof(s), s));

            var result = new _0290_WordPattern().WordPatternV2(pattern, s);

            printTable.AddProcessedParameters(
                (nameof(pattern), pattern),
                (nameof(s), s));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    public bool WordPattern(string pattern, string s)
    {
        var patternMap = new Dictionary<char, string>();
        var sMap = new Dictionary<string, char>();

        var words = s.Split(' ');
        if (words.Length != pattern.Length)
        {
            return false;
        }

        for (var i = 0; i < pattern.Length; i++)
        {
            var letter = pattern[i];
            var word = words[i];

            if (!patternMap.TryGetValue(letter, out var mappedWord))
            {
                mappedWord = word;
                patternMap[letter] = word;
            }

            if (!sMap.TryGetValue(word, out var mappedLetter))
            {
                mappedLetter = letter;
                sMap[word] = letter;
            }

            if (mappedLetter != letter || mappedWord != word)
            {
                return false;
            }
        }

        return true;
    }

    public bool WordPatternV2(string pattern, string s)
    {
        var map = new Dictionary<string, int>();

        var words = s.Split(' ');
        if (words.Length != pattern.Length)
        {
            return false;
        }

        for (var i = 0; i < pattern.Length; i++)
        {
            var letter = pattern[i].ToString();
            var word = words[i];

            if (!map.TryGetValue(letter, out var letterIndex))
            {
                letterIndex = i;
                map[letter] = i;
            }

            if (!map.TryGetValue(word, out var wordIndex))
            {
                wordIndex = i;
                map[word] = i;
            }

            if (letterIndex != wordIndex)
            {
                return false;
            }
        }

        return true;
    }
}
