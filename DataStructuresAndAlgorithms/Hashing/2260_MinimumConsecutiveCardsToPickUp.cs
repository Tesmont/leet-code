using Helpers;

namespace DataStructuresAndAlgorithms.Hashing;

internal class _2260_MinimumConsecutiveCardsToPickUp
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1([3, 4, 2, 3, 4, 7]);
            Test1([1, 0, 5, 3]);
            Test1([1, 2, 3, 4, 5, 6, 7, 8, 9, 1]);
        }

        private void Test1(int[] cards)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(cards), cards));

            var result = new _2260_MinimumConsecutiveCardsToPickUp().MinimumCardPickup(cards);

            printTable.AddProcessedParameters(
                (nameof(cards), cards));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    public int MinimumCardPickup(int[] cards)
    {
        var map = new Dictionary<int, int>();

        var minLength = int.MaxValue;

        for (var i = 0; i < cards.Length; i++)
        {
            var currentCardValue = cards[i];
            if (map.TryGetValue(currentCardValue, out var prevCardIndex))
            {
                minLength = Math.Min(minLength, i - prevCardIndex + 1);
            }

            map[currentCardValue] = i;
        }

        return minLength == int.MaxValue ? -1 : minLength;
    }
}
