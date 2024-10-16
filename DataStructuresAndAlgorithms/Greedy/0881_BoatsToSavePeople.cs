using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.Greedy;

internal class _0881_BoatsToSavePeople
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var people = new int[] { 1, 2, 2, 3 };
            var limit = 3;
            Test(people, limit);
        }

        private void Test(int[] people, int limit)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(people), JsonSerializer.Serialize(people)),
                (nameof(limit), JsonSerializer.Serialize(limit))
            };

            var result = new _0881_BoatsToSavePeople().NumRescueBoats(people, limit);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(people), JsonSerializer.Serialize(people)),
                (nameof(limit), JsonSerializer.Serialize(limit))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int NumRescueBoats(int[] people, int limit)
    {
        Array.Sort(people);

        var boatCount = 0;
        var heap = new PriorityQueue<int, int>();

        var leftIndex = 0;
        var rightIndex = people.Length - 1;

        while (leftIndex < rightIndex)
        {
            boatCount++;

            if (people[leftIndex] + people[rightIndex] > limit)
            {
                rightIndex--;
                continue;
            }

            leftIndex++;
            rightIndex--;
        }

        if(leftIndex == rightIndex)
        {
            boatCount++;
        }

        return boatCount;
    }
}
