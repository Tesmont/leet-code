using Helpers;

namespace DataStructuresAndAlgorithms.Hashing;

internal class _0791_CustomSortString
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1("cba", "abcd");
            Test1("bcafg", "abcd");
            Test1("kqep", "pekeq");
        }

        private void Test1(string order, string s)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(order), order),
                (nameof(s), s));

            var result = new _0791_CustomSortString().CustomSortString(order, s);

            printTable.AddProcessedParameters(
                (nameof(order), order),
                (nameof(s), s));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    public string CustomSortString(string order, string s)
    {
        Span<int> map = stackalloc int[26];
        map.Fill(-1);
        for (var i = 0; i < order.Length; i++)
        {
            var mapIndex = order[i] - 'a';
            map[mapIndex] = 0;
        }

        var orderedChars = new char[s.Length];
        var index = orderedChars.Length - 1;
        for (var i = index; i >= 0; i--)
        {
            var mapIndex = s[i] - 'a';
            var letterCount = map[mapIndex];
            if (letterCount >= 0)
            {
                map[mapIndex] = letterCount + 1;
                continue;
            }

            orderedChars[index] = s[i];
            index--;
        }

        index = 0;
        for (var i = 0; i < order.Length; i++)
        {
            var mapIndex = order[i] - 'a';
            var letterCount = map[mapIndex];
            Array.Fill(orderedChars, order[i], index, letterCount);
            index += letterCount;
        }

        return new string(orderedChars);
    }
}
