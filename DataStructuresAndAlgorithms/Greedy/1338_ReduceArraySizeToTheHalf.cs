using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.Greedy;

internal class _1338_ReduceArraySizeToTheHalf
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var arr = new int[] { 3, 3, 3, 3, 5, 5, 5, 2, 2, 7 };
            Test(arr);
        }

        private void Test(int[] arr)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(arr), JsonSerializer.Serialize(arr))
            };

            var result = new _1338_ReduceArraySizeToTheHalf().MinSetSize(arr);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(arr), JsonSerializer.Serialize(arr))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int MinSetSize(int[] arr)
    {
        var frequencyMap = new Dictionary<int, int>();

        for(var i = 0; i < arr.Length; i++)
        {
            if(frequencyMap.TryGetValue(arr[i], out var frequency))
            {
                frequencyMap[arr[i]] = frequency + 1;
                continue;
            }

            frequencyMap[arr[i]] = 1;
        }

        var limit = (int)Math.Ceiling(arr.Length / 2d);
        var removedDigitCount = 0;

        var frequencies = frequencyMap.Values.OrderDescending().ToList();

        for(var i = 0; i < frequencies.Count; i++)
        {
            removedDigitCount += frequencies[i];

            if(removedDigitCount >= limit)
            {
                return i + 1;
            }
        }

        return arr.Length;
    }
}
