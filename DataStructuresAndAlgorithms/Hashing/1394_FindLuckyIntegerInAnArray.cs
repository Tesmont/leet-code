using Helpers;

namespace DataStructuresAndAlgorithms.Hashing;

internal class _1394_FindLuckyIntegerInAnArray
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1([2, 2, 3, 4]);
            Test1([1, 2, 2, 3, 3, 3]);
            Test1([2, 2, 2, 3, 3]);
            Test1([5]);
            Test1([7, 7, 7, 7, 7, 7, 7]);
        }

        private void Test1(int[] arr)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(arr), arr));

            var result = new _1394_FindLuckyIntegerInAnArray().FindLucky(arr);

            printTable.AddProcessedParameters(
                (nameof(arr), arr));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    public int FindLucky(int[] arr)
    {
        Span<short> span = stackalloc short[501];

        for(var i = 0; i < arr.Length; i++)
        {
            span[arr[i]]++;
        }

        for (var i = span.Length - 1; i >= 1; i--)
        {
            if (i == span[i])
            {
                return i;
            }
        }

        return -1;
    }
}
