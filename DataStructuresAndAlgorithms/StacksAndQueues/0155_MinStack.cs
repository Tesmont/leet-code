using Helpers;

namespace DataStructuresAndAlgorithms.StacksAndQueues;

internal class _0155_MinStack
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var minStack = new MinStack();

            minStack.Push(-2);
            minStack.Push(0);
            minStack.Push(-1);
            var min1 = minStack.GetMin();
            minStack.Pop();
            var top = minStack.Top();    
            var min2 = minStack.GetMin();

            // Print test results
            var printTable = Helper.CreatePrintTable(
                ("Operations", "Results"),
                ("Push(-2), Push(0), Push(-3), GetMin(), Pop(), Top(), GetMin()",
                 $"{min1}, {top}, {min2}")
            );
            Helper.PrintTable(printTable);
        }
    }

public class MinStack
{
    private readonly Stack<int> _stack = new();
    private readonly Stack<int> _decreasingStack = new();

    public void Push(int val)
    {
        _stack.Push(val);

        if (!_decreasingStack.TryPeek(out var min)
            || val <= min)
        {
            _decreasingStack.Push(val);
        }
    }

    public void Pop()
    {
        if (!_stack.TryPop(out var val))
        {
            return;
        }

        if (_decreasingStack.Peek() == val)
        {
            _decreasingStack.Pop();
        }
    }

    public int Top()
    {
        return _stack.TryPeek(out var val)
            ? val
            : -1;
    }

    public int GetMin()
    {
        return _decreasingStack.TryPeek(out var min)
            ? min
            : -1;
    }
}
}
