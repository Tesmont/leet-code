using Helpers;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithms.Hashing;

internal class _1941_CheckIfAllCharactersHaveEqualNumberOfOccurrences
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1("abacbc");
            Test1("aaabb");
        }

        private void Test1(string s)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(s), s));

            var result = new _1941_CheckIfAllCharactersHaveEqualNumberOfOccurrences().AreOccurrencesEqual(s);

            printTable.AddProcessedParameters(
                (nameof(s), s));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    public bool AreOccurrencesEqual(string s)
    {
        var dict = new Dictionary<char, int>();
        for (var i = 0; i < s.Length; i++)
        {
            if (dict.TryGetValue(s[i], out var count))
            {
                dict[s[i]] = count + 1;
            }
            else
            {
                dict[s[i]] = 1;
            }
        }

        {
            int count = dict.Values.First();
            foreach (int value in dict.Values)
            {
                if (value != count)
                {
                    return false;
                }
            }
        }

        return true;
    }
}

