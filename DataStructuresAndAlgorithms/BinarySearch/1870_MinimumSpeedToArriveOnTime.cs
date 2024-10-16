using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.BinarySearch;

internal class _1870_MinimumSpeedToArriveOnTime
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var dist = new int[] { 2, 1, 5, 4, 4, 3, 2, 9, 2, 10};
            var hour = 75.12;
            Test(dist, hour);
        }

        private void Test(int[] dist, double hour)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(dist), JsonSerializer.Serialize(dist)),
                (nameof(hour), JsonSerializer.Serialize(hour))
            };

            var result = new _1870_MinimumSpeedToArriveOnTime().MinSpeedOnTime(dist, hour);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(dist), JsonSerializer.Serialize(dist)),
                (nameof(hour), JsonSerializer.Serialize(hour))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int MinSpeedOnTime(int[] dist, double hour)
    {
        if (hour < dist.Length - 1)
        {
            return -1;
        }

        var minSpeed = 1;
        var maxSpeed = (int)Math.Pow(10, 7);

        if (minSpeed >= maxSpeed)
        {
            return minSpeed;
        }

        while (minSpeed < maxSpeed)
        {
            var midSpeed = minSpeed + (maxSpeed - minSpeed) / 2;

            var travelTime = CalculateTravelTime(midSpeed);
            if(travelTime <= hour)
            {
                maxSpeed = midSpeed;
            }
            else
            {
                minSpeed = midSpeed + 1;
            }
        }

        return minSpeed;

        double CalculateTravelTime(int speed)
        {
            double hours = 0;
            var i = 0;
            for (; i < dist.Length - 1; i++)
            {
                hours += (dist[i] - 1) / speed + 1;
            }

            hours += dist[i] / (double)speed;

            return hours;
        }
    }
}
