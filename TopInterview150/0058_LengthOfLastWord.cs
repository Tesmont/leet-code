using Helpers;

namespace TopInterview150;

internal class _0058_LengthOfLastWord
{
    public void Launch()
    {
        Execute("Hello World");
        Execute("   fly me   to   the moon  ");
        Execute("luffy is still joyboy");

        Execute("");
        Execute(" ");
        Execute("a");
        Execute("a ");
        Execute(" a ");
        Execute(" a");

    }

    private void Execute(string s)
    {
        var result = LengthOfLastWordV2(s);

        Helper.PrintTable([
            ("s", s),
            ("result", result),
            ]);
    }

    public int LengthOfLastWord(string s)
    {
        var endOfLastWord = s.Length - 1;
        for (; endOfLastWord >= 0; endOfLastWord--)
        {
            if (s[endOfLastWord] != ' ')
            {
                break;
            }
        }

        var startOfLastWord = endOfLastWord;
        for (; startOfLastWord >= 0; startOfLastWord--)
        {
            if (s[startOfLastWord] == ' ')
            {
                break;
            }
        }

        return endOfLastWord - startOfLastWord;
    }

    public int LengthOfLastWordV2(string s)
    {
        var lenght = 0;
        for (var i = s.Length - 1; i >= 0; i--)
        {
            if (s[i] == ' ')
            {
                if (lenght > 0)
                {
                    break;
                }
            }
            else
            {
                lenght++;
            }
        }

        return lenght;
    }
}
