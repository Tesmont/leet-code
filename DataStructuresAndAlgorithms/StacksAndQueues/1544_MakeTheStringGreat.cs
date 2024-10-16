using Helpers;

namespace DataStructuresAndAlgorithms.StacksAndQueues;

internal class _1544_MakeTheStringGreat
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1("leEeetcode");
            Test1("abBAcC");
            Test1("s");
            Test1("Ss");
            Test1("mM");
        }

        private void Test1(string s)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(s), s));

            var result = new _1544_MakeTheStringGreat().MakeGood(s);

            printTable.AddProcessedParameters(
                (nameof(s), s));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    public string MakeGood(string s)
    {
        const int difference = 'a' - 'A';

        var stack = new char[s.Length];
        var stackLenght = 0;

        for (var i = 0; i < s.Length; i++)
        {
            var currentLetter = s[i];

            if (stackLenght == 0)
            {
                stack[stackLenght++] = currentLetter;
                continue;
            }

            var previousLetter = stack[stackLenght - 1];

            if (Math.Abs(currentLetter - previousLetter) == difference)
            {
                //bad segment
                //remove it
                stackLenght--;
                continue;
            }

            stack[stackLenght++] = currentLetter;
        }

        return new string(stack, 0, stackLenght);
    }
}
