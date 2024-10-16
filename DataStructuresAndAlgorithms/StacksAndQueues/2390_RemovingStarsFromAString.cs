using Helpers;

namespace DataStructuresAndAlgorithms.StacksAndQueues;

internal class _2390_RemovingStarsFromAString
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1("leet**cod*e");
            Test1("erase*****");
            Test1("a*b*c*");
            Test1("ab**c*d*ef*");
        }

        private void Test1(string s)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(s), s));

            var result = new _2390_RemovingStarsFromAString().RemoveStars(s);

            printTable.AddProcessedParameters(
                (nameof(s), s));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    public string RemoveStars(string s)
    {
        var chars = new char[s.Length];
        var newStringLenght = 0;

        for(var i = 0; i < s.Length; i++)
        {
            var ch = s[i];
            if(ch == '*')
            {
                newStringLenght--;
                continue;
            }

            chars[newStringLenght++] = ch;
        }

        return new string(chars, 0, newStringLenght);
    }
}
