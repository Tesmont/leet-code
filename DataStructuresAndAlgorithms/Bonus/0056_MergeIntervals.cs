using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.Bonus;

internal class _0056_MergeIntervals
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var intervals = new int[][]
            {
                [1, 3],
                [2, 6],
                [8, 10],
                [15, 18]
            };
            Test(intervals);
        }

        private void Test(int[][] intervals)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(intervals), JsonSerializer.Serialize(intervals))
            };

            var result = new _0056_MergeIntervals().Merge(intervals);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(intervals), JsonSerializer.Serialize(intervals))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int[][] Merge(int[][] intervals)
    {
        if(intervals.Length <= 1)
        {
            return intervals;
        }

        Array.Sort(intervals, Comparer<int[]>.Create((x, y) => x[0].CompareTo(y[0])));
        var mergedIntervals = new List<int[]>(intervals.Length);

        var i = 0;
        for (; i < intervals.Length - 1; i++)
        {
            var currentInterval = intervals[i];
            var nextInterval = intervals[i + 1];

            if (currentInterval[1] < nextInterval[0])
            {
                mergedIntervals.Add(currentInterval);
            }
            else
            {
                nextInterval[0] = currentInterval[0];
                nextInterval[1] = Math.Max(currentInterval[1], nextInterval[1]);
            }
        }

        mergedIntervals.Add(intervals[i]);

        return mergedIntervals.ToArray();
    }
}
