using Helpers;

namespace DataStructuresAndAlgorithms.ArrayAndStrings;

internal class _2000_ReversePrefixOfWord
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1("abcdefd", 'd');
            Test1("xyxzxe", 'z');
            Test1("abcd", 'z');
        }

        private void Test1(string word, char ch)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(word), word),
                (nameof(ch), ch));

            var result = new _2000_ReversePrefixOfWord().ReversePrefix(word, ch);

            printTable.AddProcessedParameters(
                (nameof(word), word),
                (nameof(ch), ch));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    public string ReversePrefix(string word, char ch)
    {
        var chars = word.ToCharArray();
        for(var i = 0; i < word.Length; i++) 
        {
            if (word[i] == ch)
            {
                for(var j =0; j <= i; j++)
                {
                    chars[j] = word[i - j];
                }

                break;
            }
        }

        return new string(chars);
    }
}
