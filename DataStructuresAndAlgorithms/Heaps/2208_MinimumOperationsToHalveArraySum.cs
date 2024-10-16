using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.Heaps;

internal class _2208_MinimumOperationsToHalveArraySum
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var nums = new int[] { 5, 19, 8, 1 };
            Test(nums);
        }

        private void Test(int[] nums)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(nums), JsonSerializer.Serialize(nums))
            };

            var result = new _2208_MinimumOperationsToHalveArraySum().HalveArray(nums);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(nums), JsonSerializer.Serialize(nums))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int HalveArray(int[] nums)
    {
        var comparer = Comparer<double>.Create((x, y) => y.CompareTo(x));
        var heapSource = nums.Select(i => ((double)i, (double)i));
        var maxHeap = new PriorityQueue<double, double>(heapSource, comparer);

        var sum = nums.Select(i => (double)i).Sum();
        var halfSum = sum / 2d;

        for(var i = 0; i < nums.Length; i++)
        {
            var maxValue = maxHeap.Dequeue();
            var halfMaxValue = maxValue / 2d;
            sum -= halfMaxValue;

            if(sum <= halfSum)
            {
                return i + 1;
            }

            maxHeap.Enqueue(halfMaxValue, halfMaxValue);
        }

        throw new InvalidOperationException();
    }
}
