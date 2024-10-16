using Helpers;

namespace DataStructuresAndAlgorithms.StacksAndQueues;

internal class _1475_FinalPricesWithSpecialDiscount
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1([5,6,7,8,9,8,6,4]);
            Test1([8, 7, 4, 2, 8, 1, 7, 7, 10, 1]);

            Test1([8, 4, 6, 2, 3]);
            Test1([1, 2, 3, 4, 5]);
            Test1([10, 1, 1, 6]);
        }

        private void Test1(int[] prices)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(prices), string.Join(", ", prices)));

            var result = new _1475_FinalPricesWithSpecialDiscount().FinalPrices(prices);

            printTable.AddProcessedParameters(
                (nameof(prices), string.Join(", ", prices)));

            printTable.AddResult(string.Join(", ", result));
            Helper.PrintTable(printTable);
        }
    }

    public int[] FinalPrices(int[] prices)
    {
        var discounts = new int[prices.Length];
        var decreasingDeque = new Stack<int>(prices.Length);

        for (var i = 0; i < prices.Length; i++)
        {
            var price = prices[i];
            while(decreasingDeque.TryPeek(out var minPriceIndex)
                && price <= prices[minPriceIndex])
            {
                discounts[minPriceIndex] = price;
                decreasingDeque.Pop();
            }

            decreasingDeque.Push(i);
        }

        for(var i = 0; i < prices.Length; i++)
        {
            prices[i] -= discounts[i];
        }

        return prices;
    }
}
