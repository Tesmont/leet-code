using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms.Hashing;

internal class _1426_CountingElements
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1([1, 2, 3]);
            Test1([1, 1, 3, 3, 5, 5, 7, 7]);
            Test1([1, 3, 2, 3, 5, 0]);
            Test1([1, 1, 2, 2]);
        }

        private void Test1(int[] arr)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(arr), arr));

            var result = new _1426_CountingElements().CountElements(arr);

            printTable.AddProcessedParameters(
                (nameof(arr), arr));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    public int CountElements(int[] arr)
    {
        var hash = new HashSet<int>();
        for (var i = 0; i < arr.Length; i++)
        {
            hash.Add(arr[i]);
        }

        var count = 0;
        for(var i = 0; i < arr.Length; i++)
        {
            if (hash.Contains(arr[i] + 1))
            {
                count++;
            }
        }

        return count;
    }
}

