using Helpers;

namespace DataStructuresAndAlgorithms.StacksAndQueues;

internal class _0844_BackspaceStringCompare
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1("ab#c", "ad#c");
            Test1("ab##", "c#d#");
            Test1("a##c", "#a#c");
            Test1("a#c", "b");
        }

        private void Test1(string s, string t)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(s), s),
                (nameof(t), t));

            var result = new _0844_BackspaceStringCompare().BackspaceCompare(s, t);

            printTable.AddProcessedParameters(
                (nameof(s), s),
                (nameof(t), t));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    public bool BackspaceCompare(string s, string t)
    {
        var processedS = ProcessString(s);
        var processedT = ProcessString(t);
        
        return processedS.stack.Take(processedS.stackLenght).SequenceEqual(processedT.stack.Take(processedT.stackLenght));
    }

    private (char[] stack, int stackLenght) ProcessString(string str)
    {
        var stack = new char[str.Length];
        var stackLenght = 0;

        for(var i = 0; i < str.Length; i++)
        {
            var currentChar = str[i];
            if(currentChar == '#')
            {
                if(stackLenght > 0)
                {
                    stackLenght--;
                }
                continue;
            }

            stack[stackLenght++] = currentChar;
        }

        return (stack, stackLenght);
    }
}
