namespace DataStructuresAndAlgorithms.ArrayAndStrings;

internal class _0557_ReverseWordsInAStringIII
{
    public void Launch()
    {
        Execute("  Let's take LeetCode contest");
        Execute("Let's take LeetCode contest");
        Execute("Mr Ding");
    }

    private void Execute(string s)
    {
        ReverseWords(s);
    }

    public string ReverseWords(string s)
    {
        var length = s.Length;
        var lastSpaceIndex = -1;
        var chars = s.ToCharArray();
        for (int strIndex = 0; strIndex <= length; strIndex++)
        {
            if (strIndex == length || chars[strIndex] == ' ')
            {
                int startIndex = lastSpaceIndex + 1;
                int endIndex = strIndex - 1;
                while (startIndex < endIndex)
                {
                    char temp = chars[startIndex];
                    chars[startIndex] = chars[endIndex];
                    chars[endIndex] = temp;
                    startIndex++;
                    endIndex--;
                }
                lastSpaceIndex = strIndex;
            }
        }

        return new string(chars);
    }
}
