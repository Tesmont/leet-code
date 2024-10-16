using Helpers;

namespace DataStructuresAndAlgorithms.Hashing;

internal class _1657_DetermineIfTwoStringsAreClose
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1("abc", "bca");
            Test1("a", "aa");
            Test1("cabbba", "abbccc");
            Test1("cabbba", "aabbss");
        }

        private void Test1(string word1, string word2)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(word1), word1),
                (nameof(word2), word2));

            var result = new _1657_DetermineIfTwoStringsAreClose().CloseStrings(word1, word2);

            printTable.AddProcessedParameters(
                (nameof(word1), word1),
                (nameof(word2), word2));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    public bool CloseStrings(string word1, string word2)
    {
        if(word1.Length != word2.Length)
        {
            return false;
        }

        Span<int> wordMap1 = stackalloc int[26];
        Span<int> wordMap2 = stackalloc int[26];

        for(var i = 0; i < word1.Length; i++)
        {
            var letter = word1[i] - 'a';
            wordMap1[letter]++;
        }

        for (var i = 0; i < word2.Length; i++)
        {
            var letter = word2[i] - 'a';
            wordMap2[letter]++;
        }

        for (int i = 0; i < 26; i++)
        {
            if ((wordMap1[i] == 0 && wordMap2[i] > 0) 
                || (wordMap2[i] == 0 && wordMap1[i] > 0))
            {
                return false;
            }
        }

        wordMap1.Sort();
        wordMap2.Sort();

        return wordMap1.SequenceEqual(wordMap2);
    }
}
