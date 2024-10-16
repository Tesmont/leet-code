using Helpers;

namespace TopInterview150;

internal class _0028_FindTheIndexOfTheFirstOccurrenceInAString
{
    public void Launch()
    {
        Execute("sadbutsad", "sad");
        Execute("leetcode", "leeto");

        Execute("a", "a");

        Execute("sad", "sadbutsad");
        Execute("leetcode", "etc");

    }

    private void Execute(string haystack, string needle)
    {
        var result = StrStr(haystack, needle);

        Helper.PrintTable([
            ("haystack", haystack),
            ("needle", needle),
            ("result", result),
            ]);
    }

    public int StrStr(string haystack, string needle)
    {
        var startIndex = FindCharIndex(haystack, needle[0], 0);
        while (haystack.Length - startIndex >= needle.Length
            && startIndex >= 0)
        {
            if (CheckStrings(haystack, needle, startIndex))
            {
                return startIndex;
            }

            startIndex++;
            startIndex = FindCharIndex(haystack, needle[0], startIndex);
        }

        return -1;
    }

    private int FindCharIndex(string haystack, char ch, int startIndex)
    {
        for (var i = startIndex; i < haystack.Length; i++)
        {
            if (haystack[i] == ch)
            {
                return i;
            }
        }

        return -1;
    }

    private bool CheckStrings(string haystack, string needle, int startIndex)
    {
        for (int i = 1, j = startIndex + 1; i < needle.Length; i++, j++)
        {
            if (needle[i] != haystack[j])
            {
                return false;
            }
        }

        return true;
    }
}
