using Helpers;

namespace DataStructuresAndAlgorithms.ArrayAndStrings;

internal class _1208_GetEqualSubstringsWithinBudget
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1("abcd", "bcdf", 3);
            Test1("abcd", "cdef", 3);
            Test1("abcd", "acde", 0);
        }

        private void Test1(string s, string t, int maxCost)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(s), s),
                (nameof(t), t),
                (nameof(maxCost), maxCost));

            var result = new _1208_GetEqualSubstringsWithinBudget().EqualSubstring(s, t, maxCost);

            printTable.AddProcessedParameters(
                (nameof(s), s),
                (nameof(t), t),
                (nameof(maxCost), maxCost));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    public int EqualSubstring(string s, string t, int maxCost)
    {
        var leftIndex = 0;
        var windowSum = 0;
        var maxWindowLenght = 0;
        for(var rightIndex = 0; rightIndex < s.Length; rightIndex++)
        {
            windowSum += Math.Abs(s[rightIndex] - t[rightIndex]);

            while(windowSum > maxCost
                && leftIndex <= rightIndex)
            {
                windowSum -= Math.Abs(s[leftIndex] - t[leftIndex]);
                leftIndex++;
            }

            maxWindowLenght = Math.Max(maxWindowLenght, rightIndex - leftIndex + 1);
        }

        return maxWindowLenght;
    }
}
