using Helpers;
using System.Text;

namespace DataStructuresAndAlgorithms.Hashing;

internal class _0049_GroupAnagrams
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1(["eat", "tea", "tan", "ate", "nat", "bat"]);
            Test1([""]);
            Test1(["a"]);
        }

        private void Test1(string[] strs)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(strs), strs));

            var result = new _0049_GroupAnagrams().GroupAnagramsV2(strs);

            printTable.AddProcessedParameters(
                (nameof(strs), strs));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        var groups = new Dictionary<string, IList<string>>();

        for(var i = 0; i < strs.Length; i++)
        {
            var sortedChars = strs[i].ToCharArray();
            Array.Sort(sortedChars);
            var sortedString = new string(sortedChars);

            if (groups.TryGetValue(sortedString, out var groupedStrings))
            {
                groupedStrings.Add(strs[i]);
            }
            else
            {
                groups[sortedString] = new List<string> { strs[i] };
            }
        }

        return groups.Values.ToList();
    }

    public IList<IList<string>> GroupAnagramsV2(string[] strs)
    {
        var groups = new Dictionary<string, IList<string>>();

        var counts = new int[26];
        var keyBuilder = new StringBuilder(counts.Length * 2);

        for (var i = 0; i < strs.Length; i++)
        {
            for (var j = 0; j < strs[i].Length; j++)
            {
                counts[strs[i][j] - 'a']++;
            }
            for (var j = 0; j < counts.Length; j++)
            {
                keyBuilder.Append('#');
                keyBuilder.Append(counts[j]);
            }
            var key = keyBuilder.ToString();

            if (groups.TryGetValue(key, out var groupedStrings))
            {
                groupedStrings.Add(strs[i]);
            }
            else
            {
                groups[key] = new List<string> { strs[i] };
            }

            Array.Fill(counts, 0);
            keyBuilder.Clear();
        }

        return groups.Values.ToList();
    }
}
