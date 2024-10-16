using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.Greedy;

internal class _2126_DestroyingAsteroids
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var mass = 10;
            var asteroids = new int[] { 3, 9, 19, 5, 21 };
            Test(mass, asteroids);
        }

        private void Test(int mass, int[] asteroids)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(mass), JsonSerializer.Serialize(mass)),
                (nameof(asteroids), JsonSerializer.Serialize(asteroids))
            };

            var result = new _2126_DestroyingAsteroids().AsteroidsDestroyed(mass, asteroids);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(mass), JsonSerializer.Serialize(mass)),
                (nameof(asteroids), JsonSerializer.Serialize(asteroids))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public bool AsteroidsDestroyed(int mass, int[] asteroids)
    {
        Array.Sort(asteroids);

        var longMass = (long)mass;
        for(var i = 0; i < asteroids.Length; i++)
        {
            if(longMass < asteroids[i])
            {
                return false;
            }

            longMass += asteroids[i];
        }

        return true;
    }
}
