using Helpers;
using System.Data;

namespace DataStructuresAndAlgorithms.Hashing;

internal class _0003_LongestSubstringWithoutRepeatingCharacters
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1("abcabcbb");
            Test1("bbbbb");
            Test1("pwwkew");
            Test1("aabaab!bb");
        }

        private void Test1(string s)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(s), s));

            var result = new _0003_LongestSubstringWithoutRepeatingCharacters().LengthOfLongestSubstringV2(s);

            printTable.AddProcessedParameters(
                (nameof(s), s));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    public int LengthOfLongestSubstring(string s)
    {
        var map = new HashSet<char>();
        var leftIndex = 0;

        var maxLenght = 0;
        for(var rightIndex = 0; rightIndex < s.Length; rightIndex++) 
        {
            var rightLetter = s[rightIndex];

            if(map.Add(rightLetter))
            {
                maxLenght = Math.Max(maxLenght, rightIndex - leftIndex + 1);
                continue;
            }

            while (leftIndex < rightIndex) 
            {
                var leftLetter = s[leftIndex];

                leftIndex++;
                if (leftLetter != rightLetter)
                {
                    map.Remove(leftLetter);
                }
                else
                {
                    break;

                }
            }
        }

        return maxLenght;
    }

    public int LengthOfLongestSubstringV2(string s)
    {
        var map = new int[128];
        Array.Fill(map, -1);

        var leftIndex = 0;
        var maxLenght = 0;
        for (var rightIndex = 0; rightIndex < s.Length; rightIndex++)
        {
            var rightLetter = s[rightIndex];

            if (map[rightLetter] == -1)
            {
                map[rightLetter] = rightIndex;
            }
            else
            {
                leftIndex = Math.Max(leftIndex, map[rightLetter] + 1);
                map[rightLetter] = rightIndex;
            }

            maxLenght = Math.Max(maxLenght, rightIndex - leftIndex + 1);
        }

        return maxLenght;
    }
}
