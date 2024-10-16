using Helpers;

namespace BeginnersGuide;

internal class _0383_RansomNote
{
    public void Launch()
    {
        Execute("a", "b");
        Execute("aa", "ab");
        Execute("aa", "aab");
        Execute("aaa", "aab");
    }

    private void Execute(string ransomNote, string magazine)
    {
        var result = CanConstructV2(ransomNote, magazine);

        Helper.PrintTable([
            ("ransomNote", ransomNote),
            ("magazine", magazine),
            ("result", result),
            ]);
    }

    public bool CanConstruct(string ransomNote, string magazine)
    {
        var dict = new Dictionary<char, int>();
        foreach (char letter in magazine)
        {
            if (!dict.TryAdd(letter, 1))
            {
                dict[letter]++;
            }
        }

        foreach (char letter in ransomNote)
        {
            if (!dict.TryGetValue(letter, out int result)
                || result == 0)
            {
                return false;
            }

            dict[letter]--;
        }

        return true;
    }

    public bool CanConstructV2(string ransomNote, string magazine)
    {
        const int shift = 'a';
        var availableLetters = new int[26];
        foreach (char letter in magazine)
        {
            availableLetters[letter - shift]++;
        }

        foreach (char letter in ransomNote)
        {
            if (availableLetters[letter - shift] == 0)
            {
                return false;
            }

            availableLetters[letter - shift]--;
        }

        return true;
    }
}
