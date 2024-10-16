using Helpers;

namespace DataStructuresAndAlgorithms.StacksAndQueues;

internal class _0901_OnlineStockSpan
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1();
            Test2();
        }

        private void Test1()
        {
            var stockSpanner = new StockSpanner();

            var val1 = stockSpanner.Next(100); // returns 1
            var val2 = stockSpanner.Next(80);  // returns 1
            var val3 = stockSpanner.Next(60);  // returns 1
            var val4 = stockSpanner.Next(70);  // returns 2
            var val5 = stockSpanner.Next(60);  // returns 1
            var val6 = stockSpanner.Next(75);  // returns 4
            var val7 = stockSpanner.Next(85);  // returns 6

            // Print test results
            var printTable = Helper.CreatePrintTable(
                ("Operations", "Results"),
                ("Next(100), Next(80), Next(60), Next(70), Next(60), Next(75), Next(85)",
                 $"{val1}, {val2}, {val3}, {val4}, {val5}, {val6}, {val7}")
            );
            Helper.PrintTable(printTable);
        }

        private void Test2()
        {
            var stockSpanner = new StockSpanner();

            var val1 = stockSpanner.Next(100);
            var val2 = stockSpanner.Next(80);
            var val3 = stockSpanner.Next(100);
            var val4 = stockSpanner.Next(70);
            var val5 = stockSpanner.Next(60);
            var val6 = stockSpanner.Next(75);
            var val7 = stockSpanner.Next(85);

            // Print test results
            var printTable = Helper.CreatePrintTable(
                ("Operations", "Results"),
                ("Next(100), Next(80), Next(60), Next(70), Next(60), Next(75), Next(85)",
                 $"{val1}, {val2}, {val3}, {val4}, {val5}, {val6}, {val7}")
            );
            Helper.PrintTable(printTable);
        }
    }

    public class StockSpanner
    {
        private readonly Stack<(int Price, int Days)> _decresingDeck;

        public StockSpanner()
        {
            _decresingDeck = new();
        }

        public int Next(int price)
        {
            var days = 1;
            while (_decresingDeck.TryPeek(out var lastTupple) && lastTupple.Price <= price)
            {
                days += lastTupple.Days;
                _decresingDeck.Pop();
            }

            _decresingDeck.Push((price, days));

            return days;
        }
    }
}
