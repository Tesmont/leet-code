using Helpers;

namespace DataStructuresAndAlgorithms.StacksAndQueues;

internal class _0232_ImplementQueueUsingStacks
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var myQueue = new MyQueue();

            myQueue.Push(1);
            myQueue.Push(2);
            var val1 = myQueue.Peek();    // returns 1
            var val2 = myQueue.Pop();     // returns 1
            var val3 = myQueue.Empty();   // returns false

            // Print test results
            var printTable = Helper.CreatePrintTable(
                ("Operations", "Results"),
                ("Push(1), Push(2), Peek(), Pop(), Empty()",
                 $"{val1}, {val2}, {val3}")
            );
            Helper.PrintTable(printTable);
        }
    }

    public class MyQueue
    {
        private readonly Stack<int> _pushStack;
        private readonly Stack<int> _popStack;

        public MyQueue()
        {
            _pushStack = new Stack<int>();
            _popStack = new Stack<int>();
        }

        public void Push(int x)
        {
            _pushStack.Push(x);
        }

        public int Pop()
        {
            if (_popStack.Count == 0)
            {
                FeelPopStack();
            }

            return _popStack.Pop();
        }

        public int Peek()
        {
            if (_popStack.Count == 0) 
            {
                FeelPopStack();
            }

            return _popStack.Peek();
        }

        public bool Empty()
        {
            return _pushStack.Count == 0 && _popStack.Count == 0;
        }

        private void FeelPopStack()
        {
            while(_pushStack.TryPop(out var x))
            {
                _popStack.Push(x);
            }
        }
    }
}
