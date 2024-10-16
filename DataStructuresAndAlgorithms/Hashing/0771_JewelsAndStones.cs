using Helpers;

namespace DataStructuresAndAlgorithms.Hashing;

internal class _0771_JewelsAndStones
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1("aA", "aAAbbbb");
            Test1("z", "ZZ");
        }

        private void Test1(string jewels, string stones)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(jewels), jewels),
                (nameof(stones), stones));

            var result = new _0771_JewelsAndStones().NumJewelsInStones(jewels, stones);

            printTable.AddProcessedParameters(
                (nameof(jewels), jewels),
                (nameof(stones), stones));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    public int NumJewelsInStones(string jewels, string stones)
    {
        var map = new HashSet<char>();
        for (var i = 0; i < jewels.Length; i++)
        {
            map.Add(jewels[i]);
        }

        var count = 0;
        for (var i = 0; i < stones.Length; i++)
        {
            if (map.Contains(stones[i]))
            {
                count++;
            }
        }
        
        return count;
    }
}
