using Helpers;
using System.Security;

namespace DataStructuresAndAlgorithms.StacksAndQueues;

internal class _0739_DailyTemperatures
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1([73, 74, 75, 71, 69, 72, 76, 73]);
            Test1([30, 40, 50, 60]);
            Test1([30, 20, 10, 5]);
            Test1([90, 80, 70, 60, 70, 80, 90]);
        }

        private void Test1(int[] temperatures)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(temperatures), string.Join(", ", temperatures)));

            var result = new _0739_DailyTemperatures().DailyTemperatures(temperatures);

            printTable.AddProcessedParameters(
                (nameof(temperatures), string.Join(", ", temperatures)));

            printTable.AddResult(string.Join(", ", result));
            Helper.PrintTable(printTable);
        }
    }

    public int[] DailyTemperatures(int[] temperatures)
    {
        var stack = new Stack<int>();
        var answears = new int[temperatures.Length];

        for (var i = 0; i < temperatures.Length; i++)
        {
            var currentTemperature = temperatures[i];

            while (stack.TryPeek(out var previousTemperatureIndex))
            {
                var previousTemperature = temperatures[previousTemperatureIndex];
                if(previousTemperature >= currentTemperature)
                {
                    break;
                }

                answears[previousTemperatureIndex] = i - previousTemperatureIndex;
                stack.Pop();
            }

            stack.Push(i);
        }

        return answears;
    }

    public int[] DailyTemperatures2(int[] temperatures)
    {
        var answears = new int[temperatures.Length];
        int hottestTemperature = 0;

        for (var i = temperatures.Length - 1; i >= 0; i--)
        {
            var currentTemperature = temperatures[i];

            if(currentTemperature >= hottestTemperature)
            {
                hottestTemperature = currentTemperature;
                continue;
            }

            var days = 1;
            while (temperatures[i + days] <= currentTemperature)
            {
                days += answears[i + days];
            }

            answears[i] = days;
        }

        return answears;
    }
}
