using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.BinarySearch;

internal class _0875_KokoEatingBananas
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var piles = new int[] { 3, 6, 7, 11 };
            var h = 8;
            Test(piles, h);
        }

        private void Test(int[] piles, int h)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(piles), JsonSerializer.Serialize(piles)),
                (nameof(h), JsonSerializer.Serialize(h))
            };

            var result = new _0875_KokoEatingBananas().MinEatingSpeed(piles, h);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(piles), JsonSerializer.Serialize(piles)),
                (nameof(h), JsonSerializer.Serialize(h))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int MinEatingSpeed(int[] piles, int h)
    {
        var minSpeed = 1L;
        var maxSpeed = (long)piles.Max();

        while (minSpeed < maxSpeed) 
        {
            var midSpeed = (minSpeed + maxSpeed) / 2;
            var necessaryHours = CalculateNecessaryHours(midSpeed);

            if(necessaryHours <= h)
            { 
                maxSpeed = midSpeed;
            }
            else
            {
                minSpeed = midSpeed + 1;
            }
        }

        return (int)minSpeed;

        long CalculateNecessaryHours(long speed)
        {
            var hours = 0L;
            for (var i = 0; i < piles.Length; i++)
            {
                hours += (piles[i] - 1) / speed + 1;
            }

            return hours;
        }
    }
}
