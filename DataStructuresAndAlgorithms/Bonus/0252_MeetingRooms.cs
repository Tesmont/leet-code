using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.Bonus;

internal class _0252_MeetingRooms
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test([[5, 8], [6, 8]]);
        }

        private void Test(int[][] intervals)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(intervals), JsonSerializer.Serialize(intervals))
            };

            var result = new _0252_MeetingRooms().CanAttendMeetings2(intervals);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(intervals), JsonSerializer.Serialize(intervals))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public bool CanAttendMeetings(int[][] intervals)
    {
        var map = new Dictionary<int, int>();
        foreach (var meeting in intervals)
        {
            var start = meeting[0];
            var end = meeting[1];
            map[start] = map.TryGetValue(start, out var value)
                ? value + 1
                : 1;
            map[end] = map.TryGetValue(end, out value)
                ? value - 1
                : -1;
        }

        var passedMeetingCount = 0;
        var currentTime = 0;
        var currentState = 0;
        while (passedMeetingCount < map.Count)
        {
            if(map.TryGetValue(currentTime, out var value))
            {
                currentState += value;
                passedMeetingCount++;

                if (currentState > 1)
                {
                    return false;
                }
            }

            currentTime++;
        }
        
        return true;
    }

    public bool CanAttendMeetings2(int[][] intervals)
    {
        if(intervals.Length == 0)
        {
            return true;
        }

        Array.Sort(intervals, Comparer<int[]>.Create((x, y) => x[0].CompareTo(y[0])));
        var previousMeeting = intervals[0];
        for(var i = 1; i < intervals.Length; i++)
        {
            var currentMeeting = intervals[i];
            if (currentMeeting[0] < previousMeeting[1])
            {
                return false;
            }

            previousMeeting = currentMeeting;
        }

        return true;
    }
}
