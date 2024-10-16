using Helpers;

namespace DataStructuresAndAlgorithms.ArrayAndStrings;

internal class _1732_FindTheHighestAltitude
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1([-5, 1, 5, 0, -7]);
            Test1([-4, -3, -2, -1, 4, 3, 2]);
        }

        private void Test1(int[] gain)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(gain), gain));

            var result = new _1732_FindTheHighestAltitude().LargestAltitude(gain);

            printTable.AddProcessedParameters(
                (nameof(gain), gain));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    public int LargestAltitude(int[] gain)
    {
        var currentAltitude = 0;
        var maxAltitude = 0;

        for (var i = 0; i < gain.Length; i++)
        {
            currentAltitude += gain[i];

            maxAltitude = Math.Max(maxAltitude, currentAltitude);
        }

        return maxAltitude;
    }
}

