using Helpers;

namespace DataStructuresAndAlgorithms.Hashing;

internal class _1436_DestinationCity
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1(new List<IList<string>>
            {
                new List<string> { "London", "New York" },
                new List<string> { "New York", "Lima" },
                new List<string> { "Lima", "Sao Paulo" }
            });

            Test1(new List<IList<string>>
            {
                new List<string> { "B", "C" },
                new List<string> { "D", "B" },
                new List<string> { "C", "A" }
            });

            Test1(new List<IList<string>>
            {
                new List<string> { "A", "Z" }
            });
        }

        private void Test1(IList<IList<string>> paths)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(paths), paths));

            var result = new _1436_DestinationCity().DestCity(paths);

            printTable.AddProcessedParameters(
                (nameof(paths), paths));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    public string DestCity(IList<IList<string>> paths)
    {
        var map = new HashSet<string>();

        for(var i = 0; i < paths.Count; i++)
        {
            map.Add(paths[i][0]);
        }

        for (var i = 0; i < paths.Count; i++)
        {
            if(!map.Contains(paths[i][1]))
            {
                return paths[i][1];
            }
        }

        return string.Empty;
    }
}
