using Helpers;
using System.Text;

namespace DataStructuresAndAlgorithms.Hashing;

internal class _0451_SortCharactersByFrequency
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1("tree");
            Test1("cccaaa");
            Test1("Aabb");
            Test1("dabc");
        }

        private void Test1(string s)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(s), s));

            var result = new _0451_SortCharactersByFrequency().FrequencySortV2(s);

            printTable.AddProcessedParameters(
                (nameof(s), s));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    public string FrequencySort(string s)
    {
        var map = new Dictionary<char, int>();

        for (var i = 0; i < s.Length; i++)
        {
            var num = s[i];
            map[num] = map.TryGetValue(num, out var dictValue) ? dictValue + 1 : 1;
        }

        var sortedKeyValuePairs = map
            .OrderByDescending(kvp => kvp.Value);

        var resultBuilder = new StringBuilder(s.Length);
        foreach (var kvp in sortedKeyValuePairs)
        {
            for(var i = 0; i < kvp.Value; i++)
            {
                resultBuilder.Append(kvp.Key);
            }
        }

        return resultBuilder.ToString();
    }

    public string FrequencySortV2(string s)
    {
        var map = new Dictionary<char, int>();

        var maxFrequency = 1;
        for (var i = 0; i < s.Length; i++)
        {
            var num = s[i];
            if (map.TryGetValue(num, out var frequency))
            {
                frequency++;
                maxFrequency = Math.Max(maxFrequency, frequency);
                map[num] = frequency;
            }
            else
            {
                map[num] = 1;
            }
        }

        var countingSort = new List<char>?[maxFrequency + 1];
        foreach (var kvp in map)
        {
            var letters = countingSort[kvp.Value];
            if (letters != null)
            {
                letters.Add(kvp.Key);
            }
            else
            {
                countingSort[kvp.Value] = new List<char> { kvp.Key };
            }
        }


        var resultBuilder = new StringBuilder(s.Length);
        for (int i = countingSort.Length - 1; i >= 0; i--)
        {
            var letters = countingSort[i];
            if(letters == null)
            {
                continue;
            }
            for (var j = 0; j < letters.Count; j++)
            {
                for(var k = 0; k < i; k++)
                {
                    resultBuilder.Append(letters[j]);
                }
            }
        }

        return resultBuilder.ToString();
    }
}
