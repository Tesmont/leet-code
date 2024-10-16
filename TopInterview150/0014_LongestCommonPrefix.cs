namespace TopInterview150;

internal class _0014_LongestCommonPrefix
{
    public void Launch()
    {
        Execute(["flower", "flow", "flight"]);
        Execute(["dog", "racecar", "car"]);

        Execute(["qwer", "qwerty", "qwertyu"]);
        Execute(["qwer", "qwe", "qwertyu"]);

    }

    private void Execute(string[] strs)
    {
        LongestCommonPrefix(strs);
    }

    public string LongestCommonPrefix(string[] strs)
    {
        for (var i = 0; i < strs[0].Length; i++)
        {
            var ch = strs[0][i];

            for (var j = 1; j < strs.Length; j++)
            {
                var str = strs[j];
                if (str.Length == i
                    || str[i] != ch)
                {
                    return str.Substring(0, i);
                }
            }
        }

        return strs[0];
    }
}
