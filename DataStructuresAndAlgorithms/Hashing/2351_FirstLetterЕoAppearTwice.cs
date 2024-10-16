using Helpers;

namespace DataStructuresAndAlgorithms.Hashing;

internal class _2351_FirstLetterToAppearTwice
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1("abccbaacz");
            Test1("abcdd");
            Test1("aabbcc");
        }

        private void Test1(string s)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(s), s));

            var result = new _2351_FirstLetterToAppearTwice().RepeatedCharacter(s);

            printTable.AddProcessedParameters(
                (nameof(s), s));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    public char RepeatedCharacter(string s)
    {
        var hash = new HashSet<char>();
        for (int i = 0; i < s.Length; i++)
        {
            if (!hash.Add(s[i]))
            {
                return s[i];
            }
        }

        return default;
    }
}

