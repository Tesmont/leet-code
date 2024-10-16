using Helpers;

namespace DataStructuresAndAlgorithms.ArrayAndStrings;

internal class _0344_ReverseString
{
    public void Launch()
    {
        Execute(['h', 'e', 'l', 'l', 'o']);
        Execute(['H', 'a', 'n', 'n', 'a', 'h']);
    }

    private void Execute(char[] s)
    {
        var processedS = Helper.DeepClone(s);
        ReverseString(processedS);

        Helper.PrintTable([
            ("s", s),
            ("processedS", processedS),
            ]);
    }

    public void ReverseString(char[] s)
    {
        var i = 0;
        var j = s.Length - 1;
        while (i < j)
        {
            var buf = s[i];
            s[i] = s[j];
            s[j] = buf;

            i++;
            j--;
        }
    }
}
