using Helpers;

namespace DataStructuresAndAlgorithms.StacksAndQueues;

internal class _1047_RemoveAllAdjacentDuplicatesInString
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1("aaaaaaaaa");
            Test1("abbaca");
            Test1("abbacca");
            Test1("azxxzy");
            Test1("a");
            Test1("aa");
            Test1("abccba");
        }

        private void Test1(string s)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(s), s));

            var result = new _1047_RemoveAllAdjacentDuplicatesInString().RemoveDuplicates(s);

            printTable.AddProcessedParameters(
                (nameof(s), s));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    public string RemoveDuplicates(string s)
    {
        var stack = new char[s.Length];
        var stackLenght = 0;
        for (var i = 0; i < s.Length; i++)
        {
            var currentChar = s[i];

            if(stackLenght == 0)
            {
                stack[stackLenght++] = currentChar;
                continue;
            }

            var previousChar = stack[stackLenght - 1];

            if (currentChar != previousChar)
            {
                stack[stackLenght++] = currentChar;
                continue;
            }

            stackLenght--;
        }

        return new string(stack, 0, stackLenght);
    }
}
