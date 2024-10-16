using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.StacksAndQueues;

internal class _2104_SumOfSubarrayRanges
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1([1, 2, 3]);
            Test1([4, -2, -3, 4, 1]);
            Test1([1, 3, 3]);
        }

        private void Test1(int[] nums)
        {
            List<(string Name, string? Value)> parameters =
            [
                (nameof(nums), JsonSerializer.Serialize(nums))
            ];

            var result = new _2104_SumOfSubarrayRanges().SubArrayRanges(nums);

            List<(string Name, string? Value)> processedParameters =
            [
                (nameof(nums), JsonSerializer.Serialize(nums))
            ];

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public long SubArrayRanges(int[] nums)
    {
        var sumMin = SumSubarrayMins(nums);
        var sumMax = SumSubarrayMaxs(nums);

        return sumMax - sumMin;
    }

    private long SumSubarrayMins(int[] arr)
    {
        var stack = new Stack<int>();
        long sum = 0;

        for (int i = 0; i <= arr.Length; i++)
        {
            while (stack.TryPeek(out var minimumIndex)
                && (i == arr.Length || arr[i] <= arr[minimumIndex]))
            {
                long mid = stack.Pop();
                if (!stack.TryPeek(out var leftBoundary))
                {
                    leftBoundary = -1;
                }
                var rightBoundary = i;

                var count = (mid - leftBoundary) * (rightBoundary - mid);

                sum += count * arr[mid];
            }

            stack.Push(i);
        }

        return sum;
    }

    private long SumSubarrayMaxs(int[] arr)
    {
        var stack = new Stack<int>();
        long sum = 0;

        for (int i = 0; i <= arr.Length; i++)
        {
            while (stack.TryPeek(out var minimumIndex)
                && (i == arr.Length || arr[i] >= arr[minimumIndex]))
            {
                long mid = stack.Pop();
                if (!stack.TryPeek(out var leftBoundary))
                {
                    leftBoundary = -1;
                }
                var rightBoundary = i;

                var count = (mid - leftBoundary) * (rightBoundary - mid);

                sum += count * arr[mid];
            }

            stack.Push(i);
        }

        return sum;
    }
}
