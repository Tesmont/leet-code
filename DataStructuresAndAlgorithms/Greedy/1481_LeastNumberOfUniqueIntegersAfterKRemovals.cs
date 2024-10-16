using Helpers;
using System.Linq;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.Greedy;

internal class _1481_LeastNumberOfUniqueIntegersAfterKRemovals
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var arr = new int[] { 5, 5, 4 };
            var k = 1;
            Test(arr, k);
        }

        private void Test(int[] arr, int k)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(arr), JsonSerializer.Serialize(arr)),
                (nameof(k), JsonSerializer.Serialize(k))
            };

            var result = new _1481_LeastNumberOfUniqueIntegersAfterKRemovals().FindLeastNumOfUniqueInts(arr, k);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(arr), JsonSerializer.Serialize(arr)),
                (nameof(k), JsonSerializer.Serialize(k))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int FindLeastNumOfUniqueInts(int[] arr, int k)
    {
        var dictionary = new Dictionary<int, int>();
        for (var i = 0; i < arr.Length; i++)
        {
            if (dictionary.TryGetValue(arr[i], out var counter))
            {
                dictionary[arr[i]] = counter + 1;
                continue;
            }

            dictionary[arr[i]] = 1;
        }

        var counters = dictionary.Values.Order().ToList();

        for (var i = 0; i < counters.Count; i++)
        {
            var newK = k - counters[i];
            if (newK > 0)
            {
                k = newK;
                continue;
            }

            return counters[i] > k
                ? counters.Count - i
                : counters.Count - i - 1;
        }

        return 0;
    }
}
