using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.DynamicProgramming;

internal class _0309_BestTimeToBuyAndSellStockWithCooldown
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test([1, 2, 3, 0, 2]);
            Test([0, 2]);
        }

        private void Test(int[] prices)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(prices), JsonSerializer.Serialize(prices))
            };

            var result = new _0309_BestTimeToBuyAndSellStockWithCooldown().MaxProfit(prices);

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
        var dp = new int[prices.Length + 2, 2];

        for (var day = prices.Length - 1; day >= 0; day--)
        {
            var currentPrice = prices[day];

            var nextDay = day + 1;
            var nextDayPlusOne = day + 2;

            //No hold stock
            var option1 = dp[nextDay, 0]; //Skip day
            var option2 = dp[nextDay, 1] - currentPrice; //Sell stock by current price
            dp[day, 0] = Math.Max(option1, option2);

            //Hold stock
            option1 = dp[nextDay, 1]; //Skip day
            option2 = dp[nextDayPlusOne, 0] + currentPrice; //Buy stock by current price.
            dp[day, 1] = Math.Max(option1, option2);
        }

        return dp[0, 0];
    }

    public int MaxProfit2(int[] prices)
    {
        var nextDayNoHold = 0;
        var nextDayHold = 0;
        var nextDayPlusOneNoHold = 0;

        for (var day = prices.Length - 1; day >= 0; day--)
        {
            var currentPrice = prices[day];

            var option1 = nextDayHold - currentPrice; //Sell stock by current price
            var option2 = nextDayPlusOneNoHold + currentPrice; //Buy stock by current price.

            nextDayPlusOneNoHold = nextDayNoHold;
            nextDayNoHold = Math.Max(nextDayNoHold, option1);
            nextDayHold = Math.Max(nextDayHold, option2);
        }

        return nextDayNoHold;
    }
}
