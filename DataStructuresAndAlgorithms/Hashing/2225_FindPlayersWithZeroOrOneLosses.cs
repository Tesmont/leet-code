using Helpers;

namespace DataStructuresAndAlgorithms.Hashing;

internal class _2225_FindPlayersWithZeroOrOneLosses
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1([[1, 3], [2, 3], [3, 6], [5, 6], [5, 7], [4, 5], [4, 8], [4, 9], [10, 4], [10, 9]]);
            Test1([[2, 3], [1, 3], [5, 4], [6, 4]]);
        }

        private void Test1(int[][] matches)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(matches), matches));

            var result = new _2225_FindPlayersWithZeroOrOneLosses().FindWinners(matches);

            printTable.AddProcessedParameters(
                (nameof(matches), matches));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    public IList<IList<int>> FindWinners(int[][] matches)
    {
        var teamMap = new Dictionary<int, int>();

        for (var i = 0; i < matches.Length; i++)
        {
            for (var j = 0; j < matches[i].Length; j++)
            {
                var team = matches[i][j];
                teamMap[team] = teamMap.TryGetValue(team, out var teamWins)
                    ? teamWins + j
                    : j;
            }
        }

        var list1 = new List<int>();
        var list2 = new List<int>();
        foreach (var kvp in teamMap)
        {
            if (kvp.Value == 0)
            {
                list1.Add(kvp.Key);
            }

            if (kvp.Value == 1)
            {
                list2.Add(kvp.Key);
            }
        }

        list1.Sort();
        list2.Sort();

        return [list1, list2];
    }

    public IList<IList<int>> FindWinnersV2(int[][] matches)
    {
        int[] teamMap = new int[100001];
        Array.Fill(teamMap, -1);

        for(var i = 0; i < matches.Length; i++)
        {
            var winner = matches[i][0];
            var loser = matches[i][1];
            if (teamMap[winner] == -1)
            {
                teamMap[winner] = 0;
            }

            if (teamMap[loser] == -1)
            {
                teamMap[loser] = 1;
            }
            else
            {
                teamMap[loser]++;
            }
        }

        var winners = new List<int>();
        var losers = new List<int>();
        for(var i = 0; i < teamMap.Length; i++)
        {
            if (teamMap[i] == 0)
            {
                winners.Add(i);
            }
            else if (teamMap[i] == 1)
            {
                losers.Add(i);
            }
        }

        return [winners, losers];
    }
}


