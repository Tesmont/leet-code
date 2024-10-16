using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.DynamicProgramming;

internal class _0714_BestTimeToBuyAndSellStockWithTransactionFee
{
    internal class Tester
    {
        public void LaunchTests()
        { 
            //Test([1, 3, 2, 8, 4, 9], 2);
            Test([1, 3, 2, 8, 4, 9], 2);
        }

        private void Test(int[] prices, int fee)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(prices), JsonSerializer.Serialize(prices)),
                (nameof(fee), JsonSerializer.Serialize(fee))
            };

            var result = new _0714_BestTimeToBuyAndSellStockWithTransactionFee().MaxProfit3(prices, fee);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(prices), JsonSerializer.Serialize(prices)),
                (nameof(fee), JsonSerializer.Serialize(fee))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int MaxProfit(int[] prices, int fee)
    {
        var dp = new int[prices.Length, 2];

        dp[0, 0] = 0;
        dp[0, 1] = -prices[0];

        for (int day = 1; day < prices.Length; day++)
        {
            var previousDay = day - 1;

            var option1 = dp[previousDay, 0]; //no hold, skip
            var option2 = dp[previousDay, 1] + prices[day] - fee; //no hold, sell
            dp[day, 0] = Math.Max(option1, option2);

            option1 = dp[previousDay, 1]; //hold, skip
            option2 = dp[previousDay, 0] - prices[day]; //hold, buy
            dp[day, 1] = Math.Max(option1, option2);
        }

        return dp[prices.Length - 1, 0];
    }

    public int MaxProfit2(int[] prices, int fee)
    {
        var dp = new int[prices.Length + 1, 2];

        for(var day = prices.Length - 1; day >= 0; day--)
        {
            var nextDay = day + 1;
            var currentPrice = prices[day];
            var nextDayNoHold = dp[nextDay, 0]; //option1 for no nold stock
            var nextDayHold = dp[nextDay, 1]; //option2 for nold stock

            //No hold stock
            var option2 = nextDayHold - currentPrice - fee; //Sell stock by current price
            dp[day, 0] = Math.Max(nextDayNoHold, option2);

            //Hold stock
            option2 = nextDayNoHold + currentPrice; //Buy stock by current price.
            dp[day, 1] = Math.Max(nextDayHold, option2);
        }

        return dp[0, 0];
    }

    public int MaxProfit3(int[] prices, int fee)
    {
        var nextDayNoHold = 0;
        var nextDayHold = 0;

        for (var day = prices.Length - 1; day >= 0; day--)
        {
            var currentPrice = prices[day];

            var option1 = nextDayHold - currentPrice - fee; //Sell stock by current price
            var option2 = nextDayNoHold + currentPrice; //Buy stock by current price.
            
            nextDayNoHold = Math.Max(nextDayNoHold, option1);
            nextDayHold = Math.Max(nextDayHold, option2);
        }

        return nextDayNoHold;
    }
}
