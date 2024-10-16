using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.Greedy;

internal class _1196_HowManyApplesCanYouPutIntoTheBasket
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var weight = new int[] { 100, 200, 150, 1000 };
            Test(weight);
        }

        private void Test(int[] weight)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(weight), JsonSerializer.Serialize(weight))
            };

            var result = new _1196_HowManyApplesCanYouPutIntoTheBasket().MaxNumberOfApples(weight);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(weight), JsonSerializer.Serialize(weight))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int MaxNumberOfApples(int[] weight)
    {
        var limit = 5000;
        Array.Sort(weight);

        for(var i = 0; i < weight.Length; i++)
        {
            limit -= weight[i];
            if (limit < 0)
            {
                return i;
            }
        }
        
        return weight.Length;
    }
}
