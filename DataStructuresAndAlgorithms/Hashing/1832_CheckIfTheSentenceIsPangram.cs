using Helpers;


namespace DataStructuresAndAlgorithms.Hashing;

internal class _1832_CheckIfTheSentenceIsPangram
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1("thequickbrownfoxjumpsoverthelazydog");
            Test1("leetcode");
        }

        private void Test1(string sentence)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(sentence), sentence));

            var result = new _1832_CheckIfTheSentenceIsPangram().CheckIfPangramV2(sentence);

            printTable.AddProcessedParameters(
                (nameof(sentence), sentence));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    public bool CheckIfPangram(string sentence)
    {
        var flags = new bool['Z' + 1];

        for (var i = 0; i < sentence.Length; i++)
        {
            flags[char.ToUpper(sentence[i])] = true;
        }

        for (var i = 'A'; i < flags.Length; i++)
        {
            if (flags[i] == false)
            {
                return false;
            }
        }

        return true;
    }

    public bool CheckIfPangramV2(string sentence)
    {
        int flag = 0;

        for (var i = 0; i < sentence.Length; i++)
        {
            var letterIndex = sentence[i] - 'a';
            flag |= 1 << letterIndex;
        }
        
        return flag == 0x3ffffff; //(1 << 26) - 1
    }
}

