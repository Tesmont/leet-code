using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.TreesAndGraphs.Graphs.ImplicitGraphs;

internal class _1306_JumpGameIII
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var arr1 = new int[] { 4, 2, 3, 0, 3, 1, 2 };
            var start1 = 5;

            Test1(arr1, start1);

            var arr2 = new int[] { 3, 0, 2, 1, 2 };
            var start2 = 2;

            Test1(arr2, start2);
        }

        private void Test1(int[] arr, int start)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(arr), JsonSerializer.Serialize(arr)),
                (nameof(start), start.ToString())
            };

            var result = new _1306_JumpGameIII().CanReach(arr, start);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(arr), JsonSerializer.Serialize(arr)),
                (nameof(start), start.ToString())
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public bool CanReach(int[] arr, int start)
    {
        var stack = new Stack<int>();
        stack.Push(start);

        while(stack.TryPop(out var index))
        {
            var value = arr[index];

            if(value == 0)
            {
                return true;
            }

            if(value < 0)
            {
                continue;
            }

            arr[index] = -1;

            var nextIndex = (index + value);
            var previousIndex = (index - value);

            if(nextIndex < arr.Length)
            {
                stack.Push(nextIndex);
            }

            if (previousIndex >= 0)
            {
                stack.Push(previousIndex);
            }
        }

        return false;
    }
}
