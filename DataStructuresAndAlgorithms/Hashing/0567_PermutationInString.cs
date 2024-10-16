using Helpers;

namespace DataStructuresAndAlgorithms.Hashing;

internal class _0567_PermutationInString
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1("ab", "eidbaooo");
            Test1("ab", "eidboaoo");
            Test1("hello", "ooolleoooleh");
            Test1("abc", "cccccbabbbaaaa");
            Test1("adc", "dcda");
        }

        private void Test1(string s1, string s2)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(s1), s1),
                (nameof(s2), s2));

            var result = new _0567_PermutationInString().CheckInclusionV2(s1, s2);

            printTable.AddProcessedParameters(
                (nameof(s1), s1),
                (nameof(s2), s2));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    public bool CheckInclusion(string s1, string s2)
    {
        var s1Map = new Dictionary<char, int>();
        for(var i = 0; i < s1.Length; i++)
        {
            var letter = s1[i];
            s1Map[letter] = s1Map.TryGetValue(letter, out var frequency) ? frequency + 1 : 1;
        }

        var s2Map = new Dictionary<char, int>();
        var leftIndex = 0;
        var rightIndex = 0;

        for(; rightIndex <= s2.Length - s1.Length; rightIndex++)
        {
            var rightLetter = s2[rightIndex];
            if(!s1Map.TryGetValue(rightLetter, out var s1Frequency))
            {
                leftIndex = rightIndex + 1;
                s2Map.Clear();
                continue;
            }

            if(s2Map.TryGetValue(rightLetter, out var s2Frequency))
            {
                s2Frequency++;
            }
            else
            {
                s2Frequency = 1;
            }
            s2Map[rightLetter] = s2Frequency;

            if(s2Frequency < s1Frequency)
            {
                continue;
            }

            if(s2Frequency == s1Frequency)
            {
                if(rightIndex - leftIndex + 1 == s1.Length)
                {
                    return true;
                }

                continue;
            }

            while(leftIndex < rightIndex)
            {
                var leftLetter = s2[leftIndex];
                leftIndex++;
                s2Map[leftLetter]--;
                if(leftLetter == rightLetter)
                {
                    break;
                }
            }
        }

        return false;
    }

    public bool CheckInclusionV2(string s1, string s2)
    {
        const int lenght = 26;
        var s1Map = new int[lenght];
        var s2Map = new int[lenght];
        var leftIndex = 0;
        var rightIndex = 0;
        for (var i = 0; i < s1.Length; i++)
        {
            s1Map[s1[i] - 'a']++;
        }

        for (; rightIndex < s2.Length; rightIndex++)
        {
            var rightLetter = s2[rightIndex] - 'a';
            var s1Frequency = s1Map[rightLetter];
            if (s1Frequency == 0)
            {
                leftIndex = rightIndex + 1;
                Array.Fill(s2Map, 0);
                continue;
            }

            s2Map[rightLetter]++;
            var s2Frequency = s2Map[rightLetter];

            if (s2Frequency < s1Frequency)
            {
                continue;
            }

            if (s2Frequency == s1Frequency)
            {
                if (rightIndex - leftIndex + 1 == s1.Length)
                {
                    return true;
                }

                continue;
            }

            while (leftIndex < rightIndex)
            {
                var leftLetter = s2[leftIndex] - 'a';
                leftIndex++;
                s2Map[leftLetter]--;
                if (leftLetter == rightLetter)
                {
                    break;
                }
            }
        }

        return false;
    }
}
