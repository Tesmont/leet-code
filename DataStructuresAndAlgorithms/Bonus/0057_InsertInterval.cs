using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.Bonus;

internal class _0057_InsertInterval
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test([[1, 2], [3, 5], [6, 7], [8, 10], [12, 16]], [4, 8]);
        }

        private void Test(int[][] intervals, int[] newInterval)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(intervals), JsonSerializer.Serialize(intervals)),
                (nameof(newInterval), JsonSerializer.Serialize(newInterval))
            };

            var result = new _0057_InsertInterval().Insert(intervals, newInterval);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(intervals), JsonSerializer.Serialize(intervals)),
                (nameof(newInterval), JsonSerializer.Serialize(newInterval))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int[][] Insert(int[][] intervals, int[] newInterval)
    {
        if (intervals.Length == 0)
        {
            return [newInterval]; 
        }

        var mergedIntervals = new List<int[]>(intervals.Length + 1);
        var i = 0;
        for (; i < intervals.Length; i++)
        {
            if (newInterval[0] < intervals[i][0])
            {
                break;
            }

            mergedIntervals.Add(intervals[i]);
        }

        if (i == 0)
        {
            mergedIntervals.Add(newInterval);
        }
        else
        {
            AddInterval(newInterval);
        }

        for (; i < intervals.Length; i++)
        {
            AddInterval(intervals[i]);
        }

        return mergedIntervals.ToArray();


        void AddInterval(int[] intervalToAdd)
        {
            var lastAddedInterval = mergedIntervals[mergedIntervals.Count - 1];
            if (lastAddedInterval[1] < intervalToAdd[0])
            {
                mergedIntervals.Add(intervalToAdd);
                return;
            }

            lastAddedInterval[1] = Math.Max(lastAddedInterval[1], intervalToAdd[1]);
        }
    }
}
