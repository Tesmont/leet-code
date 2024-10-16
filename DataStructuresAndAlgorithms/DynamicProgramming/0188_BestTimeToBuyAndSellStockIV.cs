using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.DynamicProgramming;

internal class _0188_BestTimeToBuyAndSellStockIV
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var k = 2;
            var prices = new int[] { 3, 2, 6, 5, 0, 3 };
            Test(k, prices);
        }

        private void Test(int k, int[] prices)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(k), JsonSerializer.Serialize(k)),
                (nameof(prices), JsonSerializer.Serialize(prices))
            };

            var result = new _0188_BestTimeToBuyAndSellStockIV().MaxProfit(k, prices);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(k), JsonSerializer.Serialize(k)),
                (nameof(prices), JsonSerializer.Serialize(prices))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int MaxProfit(int k, int[] prices)
    {
        int[][][] memo = new int[prices.Length][][];
        for(var i = 0; i < prices.Length; i++)
        {
            memo[i] = new int[2][];
            for(var j = 0; j < 2; j++)
            {
                memo[i][j] = new int[k + 1];
                Array.Fill(memo[i][j], -1);
            }
        }

        return Dp(0, 0, k);

        int Dp(int priceIndex, int isHold, int remainPurchases)
        {
            if (priceIndex == prices.Length 
                || remainPurchases == 0)
            {
                return 0;
            }

            if (memo[priceIndex][isHold][remainPurchases] != -1)
            {
                return memo[priceIndex][isHold][remainPurchases];
            }

            var ans = Dp(priceIndex + 1, isHold, remainPurchases);
            if (isHold == 1)
            {
                ans = Math.Max(ans, prices[priceIndex] + Dp(priceIndex + 1, 0, remainPurchases - 1));
            }
            else
            {
                ans = Math.Max(ans, -prices[priceIndex] + Dp(priceIndex + 1, 1, remainPurchases));
            }

            memo[priceIndex][isHold][remainPurchases] = ans;
            return ans;
        }
    }

    public int MaxProfit2(int k, int[] prices)
    {
        var dp = new int[prices.Length + 1, k + 1, 2];
        
        for (var day = prices.Length - 1; day >= 0; day--)
        {
            for(var remainPurchases = 1; remainPurchases <= k; remainPurchases++)
            {
                for (var isHold = 0; isHold < 2; isHold++)
                {
                    var ans = dp[day + 1, remainPurchases, isHold];
                    if (isHold == 1)
                    {
                        ans = Math.Max(ans, prices[day] + dp[day + 1, remainPurchases - 1, 0]);
                    }
                    else
                    {
                        ans = Math.Max(ans, -prices[day] + dp[day + 1, remainPurchases, 1]);
                    }

                    dp[day, remainPurchases, isHold] = ans;
                }
            }
        }

        return dp[0, k, 0];
    }
}
