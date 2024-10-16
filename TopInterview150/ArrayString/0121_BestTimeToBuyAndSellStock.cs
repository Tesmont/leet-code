using Helpers;
using System.Text.Json;

namespace TopInterview150.ArrayString;

internal class _0121_BestTimeToBuyAndSellStock
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var prices = new int[] { 7, 1, 5, 3, 6, 4 };
            Test(prices);
        }

        private void Test(int[] prices)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(prices), JsonSerializer.Serialize(prices))
            };

            var result = new _0121_BestTimeToBuyAndSellStock().MaxProfit(prices);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(prices), JsonSerializer.Serialize(prices))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int MaxProfit(int[] prices)
    {
        var maxProfit = 0;
        var minPrice = prices[0];
        for(var i = 1; i < prices.Length; i++)
        {
            var price = prices[i];
            if(minPrice >= price)
            {
                minPrice = price;
                continue;
            }

            var profit = price - minPrice;
            maxProfit = Math.Max(maxProfit, profit);
        }
        
        return maxProfit;
    }
}
