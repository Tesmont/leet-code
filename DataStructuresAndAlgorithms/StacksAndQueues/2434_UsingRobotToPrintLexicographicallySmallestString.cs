using Helpers;
using System.Text;

namespace DataStructuresAndAlgorithms.StacksAndQueues;

internal class _2434_UsingRobotToPrintLexicographicallySmallestString
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1("zza");
            Test1("bac");
            Test1("bdda");
        }

        private void Test1(string s)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(s), s));

            var result = new _2434_UsingRobotToPrintLexicographicallySmallestString().RobotWithString(s);

            printTable.AddProcessedParameters(
                (nameof(s), s));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    public string RobotWithString(string s)
    {
        Span<int> frequency = stackalloc int['z' + 1];

        var t = new char[s.Length];
        var p = new char[s.Length];
        var tIndex = -1;
        var pLenght = 0;

        for(var i = 0; i < s.Length; i++)
        {
            var ch = s[i];

            frequency[ch]++;
        }

        for (var i = 0; i < s.Length; i++)
        {
            var ch = s[i];

            t[++tIndex] = ch;
            frequency[ch]--;

            int smallestInt;
            for (smallestInt = 'a'; smallestInt < 'z'; smallestInt++)
            {
                if (frequency[smallestInt] > 0)
                {
                    break;
                }
            }

            ch = (char)smallestInt;
            while (tIndex >= 0 && t[tIndex] <= ch)
            {
                p[pLenght++] = t[tIndex--];
            }

        }

        return new string(p);
    }
}
