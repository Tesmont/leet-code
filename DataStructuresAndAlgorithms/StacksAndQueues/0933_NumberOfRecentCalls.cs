using Helpers;

namespace DataStructuresAndAlgorithms.StacksAndQueues;

internal class _0933_NumberOfRecentCalls
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var counter = new RecentCounter();

            var val1 = counter.Ping(1);    // returns 1
            var val2 = counter.Ping(100);  // returns 2
            var val3 = counter.Ping(4921); // returns 3
            var val4 = counter.Ping(3002); // returns 3

            // Print test results
            var printTable = Helper.CreatePrintTable(
                ("Operations", "Results"),
                ("Ping(1), Ping(100), Ping(3001), Ping(3002)", $"{val1}, {val2}, {val3}, {val4}")
            );
            Helper.PrintTable(printTable);
        }
    }

    public class RecentCounter
    {
        private readonly Queue<int> _queue;

        public RecentCounter()
        {
            _queue = new Queue<int>();
        }

        public int Ping(int t)
        {
            _queue.Enqueue(t);
            var minValue = t - 3000;

            var firstT = _queue.Peek();
            while (firstT < minValue)
            {
                _queue.Dequeue();
                firstT = _queue.Peek();
            }

            return _queue.Count;
        }
    }
}
