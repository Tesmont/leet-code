using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.StacksAndQueues;

internal class _0907_SumOfSubarrayMinimums
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1([11, 81, 94]);
            Test1([1, 2, 3]);
            Test1([1, 2, 3, 4, 5]);

            Test1([3, 1, 2, 4]);
            Test1([11, 81, 94, 43, 3]);
        }

        private void Test1(int[] arr)
        {
            List<(string Name, string? Value)> parameters =
            [
                (nameof(arr), JsonSerializer.Serialize(arr))
            ];

            var result = new _0907_SumOfSubarrayMinimums().SumSubarrayMins(arr);

            List<(string Name, string? Value)> processedParameters =
            [
                (nameof(arr), JsonSerializer.Serialize(arr))
            ];

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int SumSubarrayMins(int[] arr)
    {
        const long modulo = 1000000007;

        var stack = new Stack<int>();
        long sum = 0;

        for (int i = 0; i <= arr.Length; i++)
        {
            while (stack.TryPeek(out var minimumIndex) 
                && (i == arr.Length || arr[i] <= arr[minimumIndex]))
            {
                var mid = stack.Pop();
                if (!stack.TryPeek(out var leftBoundary))
                {
                    leftBoundary = -1;
                }
                var rightBoundary = i;

                var count = (mid - leftBoundary) * (rightBoundary - mid) % modulo;

                sum += (count * arr[mid]) % modulo;
                sum %= modulo;
            }

            stack.Push(i);
        }

        return (int)sum;
    }
}
