using Helpers;

namespace DataStructuresAndAlgorithms.Hashing;

internal class _1496_PathCrossing
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1("NES");
            Test1("NESWW");
        }

        private void Test1(string path)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(path), path));

            var result = new _1496_PathCrossing().IsPathCrossing(path);

            printTable.AddProcessedParameters(
                (nameof(path), path));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    public bool IsPathCrossing(string path)
    {
        var map = new HashSet<(int X, int Y)>()
        {
            (0, 0)
        };

        var x = 0;
        var y = 0;
        for(var i = 0; i < path.Length; i ++)
        {
            switch(path[i])
            {
                case 'N':
                    x++;
                    break;
                case 'S':
                    x--;
                    break;
                case 'E':
                    y++;
                    break;
                case 'W':
                    y--;
                    break;
            }

            if (!map.Add((x, y)))
            {
                return true;
            } 
        }

        return false;
    }
}
