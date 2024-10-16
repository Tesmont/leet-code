using Helpers;

namespace DataStructuresAndAlgorithms.StacksAndQueues;

internal class _0346_MovingAverageFromDataStream
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var movingAverage = new MovingAverage(3);

            var val1 = movingAverage.Next(1);   // returns 1.0
            var val2 = movingAverage.Next(10);  // returns 5.5
            var val3 = movingAverage.Next(3);   // returns 4.66667
            var val4 = movingAverage.Next(5);   // returns 6.0

            // Print test results
            var printTable = Helper.CreatePrintTable(
                ("Operations", "Results"),
                ("Next(1), Next(10), Next(3), Next(5)", $"{val1}, {val2}, {val3}, {val4}")
            );
            Helper.PrintTable(printTable);
        }
    }

    public class MovingAverage
    {
        private readonly int[] _queue;
        private readonly int _size;
        private int _index;
        private int _count;
        private int _totalSum;

        public MovingAverage(int size)
        {
            _queue = new int[size];

            _index = 0;
            _count = 0;
            _totalSum = 0;
            _size = size;
        }

        public double Next(int val)
        {
            _index++;
            if(_index == _size)
            {
                _index = 0;
            }

            _totalSum += val;
            _totalSum -= _queue[_index];

            _queue[_index] = val;

            _count++;
            return (double)_totalSum / Math.Min(_count, _queue.Length);
        }
    }

    public class MovingAverage2
    {
        private readonly Queue<int> _queue;
        private readonly int _size;
        private int _total;

        public MovingAverage2(int size)
        {
            _size = size;
            _queue = new Queue<int>();
        }

        public double Next(int val)
        {
            if (_queue.Count == _size)
            {
                _total -= _queue.Dequeue();
            }

            _total += val;
            _queue.Enqueue(val);

            return (double)_total / _queue.Count;
        }
    }
}

