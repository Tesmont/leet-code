using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.Heaps;

internal class _0295_FindMedianFromDataStream
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var medianFinder = new MedianFinder();
            medianFinder.AddNum(1);
            medianFinder.AddNum(2);
            var median1 = medianFinder.FindMedian();
            medianFinder.AddNum(3);
            var median2 = medianFinder.FindMedian();

            Test(medianFinder, median1, median2);
        }

        private void Test(MedianFinder medianFinder, double median1, double median2)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(medianFinder), JsonSerializer.Serialize(medianFinder))
            };

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(medianFinder), JsonSerializer.Serialize(medianFinder)),
                (nameof(median1), JsonSerializer.Serialize(median1)),
                (nameof(median2), JsonSerializer.Serialize(median2))
            };

            var resultStr = JsonSerializer.Serialize((median1, median2));

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public class MedianFinder
    {
        private PriorityQueue<int, int> _minHeap;
        private PriorityQueue<int, int> _maxHeap;

        public MedianFinder()
        {
            _minHeap = new PriorityQueue<int, int>();
            _maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y.CompareTo(x)));
        }

        public void AddNum(int num)
        {
            _minHeap.Enqueue(num, num);

            num = _minHeap.Dequeue();
            _maxHeap.Enqueue(num, num);

            if (_maxHeap.Count > _minHeap.Count)
            {
                num = _maxHeap.Dequeue();
                _minHeap.Enqueue(num, num);
            }
        }

        public double FindMedian()
        {
            if (_minHeap.Count > _maxHeap.Count)
            {
                return _minHeap.Peek();
            }

            return (_minHeap.Peek() + _maxHeap.Peek()) / 2d;
        }
    }
}
