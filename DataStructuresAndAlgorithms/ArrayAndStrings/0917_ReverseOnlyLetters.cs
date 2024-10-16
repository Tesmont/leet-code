namespace DataStructuresAndAlgorithms.ArrayAndStrings;

internal class _0917_ReverseOnlyLetters
{
    public void Launch()
    {
        Execute("ab-cd");
        Execute("a-bC-dEf-ghIj");
        Execute("Test1ng-Leet=code-Q!");
    }

    private void Execute(string s)
    {
        ReverseOnlyLetters(s);
    }

    public string ReverseOnlyLetters(string s)
    {
        var chars = s.ToCharArray();

        var leftIndex = 0;
        var rightIndex = s.Length - 1;

        while (leftIndex <= rightIndex)
        {
            var leftValue = s[leftIndex];
            if (!char.IsLetter(leftValue))
            {
                leftIndex++;
                continue;
            }

            var rightValue = s[rightIndex];
            if (!char.IsLetter(rightValue))
            {
                rightIndex--;
                continue;
            }

            chars[leftIndex] = rightValue;
            chars[rightIndex] = leftValue;
            leftIndex++;
            rightIndex--;
        }

        return new string(chars);
    }
}
