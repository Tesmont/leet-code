using Helpers;

namespace DataStructuresAndAlgorithms.Hashing;

internal class _1207_UniqueNumberOfOccurrences
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1([1, 2, 2, 1, 1, 3]);
            Test1([1, 2]);
            Test1([-3, 0, 1, -3, 1, 1, 1, -3, 10, 0]);
        }

        private void Test1(int[] arr)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(arr), arr));

            var result = new _1207_UniqueNumberOfOccurrences().UniqueOccurrences(arr);

            printTable.AddProcessedParameters(
                (nameof(arr), arr));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    public bool UniqueOccurrences(int[] arr)
    {
        var dict = new Dictionary<int, int>();
        var hash = new HashSet<int>();

        for(var i = 0; i < arr.Length; i++)
        {
            var num = arr[i];
            dict[num] = dict.TryGetValue(num, out var dictValue) ? dictValue + 1 : 1;
        }

        foreach(var dictValue in dict.Values)
        {
            if(!hash.Add(dictValue))
            {
                return false;
            }
        }

        return true;
    }
}
