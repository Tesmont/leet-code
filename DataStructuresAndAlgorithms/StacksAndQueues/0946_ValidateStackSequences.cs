using Helpers;

namespace DataStructuresAndAlgorithms.StacksAndQueues;

internal class _0946_ValidateStackSequences
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1([0], [0]);
            Test1([1, 2, 3, 4, 5], [4, 5, 3, 2, 1]);
            Test1([1, 2, 3, 4, 5], [4, 3, 5, 1, 2]);
        }

        private void Test1(int[] pushed, int[] popped)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(pushed), string.Join(", ", pushed)),
                (nameof(popped), string.Join(", ", popped)));

            var result = new _0946_ValidateStackSequences().ValidateStackSequences(pushed, popped);

            printTable.AddProcessedParameters(
                (nameof(pushed), string.Join(", ", pushed)),
                (nameof(popped), string.Join(", ", popped)));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    public bool ValidateStackSequences(int[] pushed, int[] popped)
    {
        var stack = new int[pushed.Length];
        var stackIndex = -1;
        var pushIndex = 0;
        var popIndex = 0;

        for (; pushIndex < pushed.Length; pushIndex++)
        {
            stackIndex++;
            stack[stackIndex] = pushed[pushIndex];

            while (stackIndex >= 0
                && popIndex != popped.Length
                && stack[stackIndex] == popped[popIndex])
            {
                stackIndex--;
                popIndex++;
            }
        }

        return popIndex == pushed.Length;
    }
}
