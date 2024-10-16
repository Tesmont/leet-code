using Helpers;

namespace DataStructuresAndAlgorithms.Hashing;

internal class _1189_MaximumNumberOfBalloons
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1("nlaebolko");
            Test1("loonbalxballpoon");
            Test1("leetcode");
        }

        private void Test1(string text)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(text), text));

            var result = new _1189_MaximumNumberOfBalloons().MaxNumberOfBalloons(text);

            printTable.AddProcessedParameters(
                (nameof(text), text));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    public int MaxNumberOfBalloons(string text)
    {
        var letterFrequency = new int[256];

        for(var i = 0; i < text.Length; i++) 
        {
            letterFrequency[text[i]]++;
        }

        var minCount = int.MaxValue;
        minCount = Math.Min(minCount, letterFrequency['b']);
        minCount = Math.Min(minCount, letterFrequency['a']);
        minCount = Math.Min(minCount, letterFrequency['l'] / 2);
        minCount = Math.Min(minCount, letterFrequency['o'] / 2);
        minCount = Math.Min(minCount, letterFrequency['n']);

        return minCount;
    }
}
