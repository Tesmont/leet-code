using Helpers;

namespace DataStructuresAndAlgorithms.StacksAndQueues;

internal class _0225_ImplementStackUsingQueues
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var myStack = new MyStack();

            myStack.Push(1);
            myStack.Push(2);
            var top = myStack.Top();      // returns 2
            var pop = myStack.Pop();      // returns 2
            var isEmpty = myStack.Empty(); // returns false

            // Print test results
            var printTable = Helper.CreatePrintTable(
                ("Operations", "Results"),
                ("Push(1), Push(2), Top(), Pop(), Empty()",
                 $"{top}, {pop}, {isEmpty}")
            );
            Helper.PrintTable(printTable);
        }
    }

    public class MyStack
    {
        private readonly Queue<int> _queue = new();

        public void Push(int x)
        {
            _queue.Enqueue(x);
            var lenght = _queue.Count();
            while (lenght > 1)
            {
                x = _queue.Dequeue();
                _queue.Enqueue(x);
                lenght--;
            }
        }

        public int Pop()
        {
            return _queue.Dequeue();
        }

        public int Top()
        {
            return _queue.Peek();
        }

        public bool Empty()
        {
            return _queue.Count == 0;
        }
    }
}
