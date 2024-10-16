using Helpers;

namespace DataStructuresAndAlgorithms.ArrayAndStrings;

internal class _0392_IsSubsequence
{
    public void Launch()
    {
        Execute("abc", "ahbgdc");
        Execute("axc", "ahbgdc");
        Execute("", "ahbgdc");
    }

    private void Execute(string s, string t)
    {
        var result = IsSubsequence(s, t);

        Helper.PrintTable([
            ("s", s),
            ("t", t),
            ("result", result),
            ]);
    }

    public bool IsSubsequence(string s, string t)
    {
        if (s.Length == 0)
        {
            return true;
        }

        var sIndex = 0;
        for (var tIndex = 0; tIndex < t.Length; tIndex++)
        {
            if (s[sIndex] == t[tIndex])
            {
                sIndex++;
            }

            if (sIndex == s.Length)
            {
                return true;
            }
        }

        return false;
    }
}
