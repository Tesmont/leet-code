using Helpers;
using System;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.DynamicProgramming;

internal class _0322_CoinChange
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var coins = new int[] { 1, 2, 5 };
            var amount = 11;
            Test(coins, amount);
        }

        private void Test(int[] coins, int amount)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(coins), JsonSerializer.Serialize(coins)),
                (nameof(amount), JsonSerializer.Serialize(amount))
            };

            var result = new _0322_CoinChange().CoinChange(coins, amount);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(coins), JsonSerializer.Serialize(coins)),
                (nameof(amount), JsonSerializer.Serialize(amount))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int CoinChange(int[] coins, int amount)
    {
        Span<int> dp = stackalloc int[10 * 10 * 10 * 10 + 1];
        dp.Slice(0, amount).Fill(-1);

        for (var i = amount; i >= 0; i--)
        {
            var rigtCoinCount = dp[i];
            if(rigtCoinCount == -1)
            {
                continue;
            }

            foreach(var coin in coins)
            {
                if(coin > i)
                {
                    continue;
                }

                var j = i - coin;

                var leftCoinCount = dp[j];
                if(leftCoinCount == -1)
                {
                    dp[j] = rigtCoinCount + 1;
                    continue;
                }

                leftCoinCount--;
                if (rigtCoinCount < leftCoinCount)
                {
                    dp[j] = rigtCoinCount + 1;
                }
            }
        }

        return dp[0];
    }
}
