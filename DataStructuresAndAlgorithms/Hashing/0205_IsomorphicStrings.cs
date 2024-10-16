using Helpers;

namespace DataStructuresAndAlgorithms.Hashing;

internal class _0205_IsomorphicStrings
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1("egg", "add");
            Test1("foo", "bar");
            Test1("paper", "title");
        }

        private void Test1(string s, string t)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(s), s),
                (nameof(t), t));

            var result = new _0205_IsomorphicStrings().IsIsomorphic(s, t);

            printTable.AddProcessedParameters(
                (nameof(s), s),
                (nameof(t), t));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    public bool IsIsomorphic(string s, string t)
    {
        Span<int> sMap = stackalloc int[256];
        Span<int> tMap = stackalloc int[256];
        sMap.Fill(-1);
        tMap.Fill(-1);

        for (var i = 0; i < s.Length; i++)
        {
            var sLetter = s[i];
            var tLetter = t[i];

            var sMappedLetter = sMap[sLetter];
            var tMappedLetter = tMap[tLetter];
            if (sMappedLetter == -1 && tMappedLetter == -1)
            {
                sMap[sLetter] = tLetter;
                tMap[tLetter] = sLetter;
                continue;
            }

            if(sMappedLetter != tLetter || tMappedLetter != sLetter)
            {
                return false;
            }
        }

        return true;
    }
}
