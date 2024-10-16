using Helpers;

namespace DataStructuresAndAlgorithms.StacksAndQueues;

internal class _0020_ValidParentheses
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1("()");
            Test1("()[]{}");
            Test1("(]");
            Test1("([)]");
            Test1("{[]}");
        }

        private void Test1(string s)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(s), s));

            var result = new _0020_ValidParentheses().IsValid(s);

            printTable.AddProcessedParameters(
                (nameof(s), s));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    private static Dictionary<char, char> _map = new Dictionary<char, char>()
    {
        { ')', '(' },
        { '}', '{' },
        { ']', '[' }
    };

    public bool IsValid(string s)
    {
        var stack = new Stack<char>();
        for(var i = 0; i < s.Length; i++)
        {
            var parenthesis = s[i];
            if(!_map.TryGetValue(parenthesis, out var openParenthesis))
            {
                stack.Push(parenthesis);
                continue;
            }

            if(!stack.TryPop(out parenthesis)
                || parenthesis != openParenthesis)
            {
                return false;
            }
        }

        return stack.Count == 0;
    }
}
