using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.StacksAndQueues;

internal class _1944_NumberOfVisiblePeopleInAQueue
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1([10, 6, 8, 5, 11, 9]);
            Test1([5, 1, 2, 3, 10]);
            Test1([1, 1, 1, 1]);
        }

        private void Test1(int[] heights)
        {
            List<(string Name, string? Value)> parameters =
            [
                (nameof(heights), JsonSerializer.Serialize(heights))
            ];

            var result = new _1944_NumberOfVisiblePeopleInAQueue().CanSeePersonsCount(heights);

            List<(string Name, string? Value)> processedParameters =
            [
                (nameof(heights), JsonSerializer.Serialize(heights))
            ];

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    private record struct StackTuple
    {
        public int Height { get; init; }
        public int Index { get; init; }
        public int RemovedPersonCount { get; set; }

    }

    public int[] CanSeePersonsCount(int[] heights)
    {
        var result = new int[heights.Length];
        var decresingStack = new int[heights.Length];
        var stackIndex = -1;

        for (int i = 0; i < heights.Length; i++)
        {
            int height = heights[i];

            while (stackIndex >= 0 
                && height > heights[decresingStack[stackIndex]])
            {
                result[decresingStack[stackIndex]] += 1;
                stackIndex--;
            }

            if (stackIndex >= 0)
            {
                result[decresingStack[stackIndex]] += 1;
            }

            stackIndex++;
            decresingStack[stackIndex] = i;
        }

        return result;
    }
}
