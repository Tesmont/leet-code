using Helpers;

namespace DataStructuresAndAlgorithms.StacksAndQueues;

internal class _0649_Dota2Senate
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1("DRRDRDRDRDDRDRDR");
            Test1("DDRRR");

            Test1("RD");
            Test1("RDD");
            Test1("RRD");
            Test1("DDRR");
        }

        private void Test1(string senate)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(senate), senate));

            var result = new _0649_Dota2Senate().PredictPartyVictory(senate);

            printTable.AddProcessedParameters(
                (nameof(senate), senate));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    private record struct SenatorsGroup
    {
        public char Party { get; init; }
        public int Count { get; set; }
    }

    public string PredictPartyVictory(string senate)
    {
        var lenght = senate.Length;
        var radiantQueue = new Queue<int>();
        var direQueue = new Queue<int>();

        for (int i = 0; i < lenght; i++)
        {
            if (senate[i] == 'R')
            {
                radiantQueue.Enqueue(i);
            }
            else
            {
                direQueue.Enqueue(i);
            }
        }

        while (radiantQueue.Count > 0 && direQueue.Count > 0)
        {
            var radiantSenatorIndex = radiantQueue.Dequeue();
            int direSenatorIndex = direQueue.Dequeue();

            if (direSenatorIndex < radiantSenatorIndex)
            {
                direQueue.Enqueue(direSenatorIndex + lenght);
            }
            else
            {
                radiantQueue.Enqueue(radiantSenatorIndex + lenght);
            }
        }

        return radiantQueue.Count == 0 ? "Dire" : "Radiant";
    }
}
