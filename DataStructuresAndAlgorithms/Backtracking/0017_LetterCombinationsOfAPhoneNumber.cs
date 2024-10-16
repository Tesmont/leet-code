using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.Backtracking;

internal class _0017_LetterCombinationsOfAPhoneNumber
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var digits = "23";
            Test(digits);
        }

        private void Test(string digits)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(digits), JsonSerializer.Serialize(digits))
            };

            var result = new _0017_LetterCombinationsOfAPhoneNumber().LetterCombinations3(digits);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(digits), JsonSerializer.Serialize(digits))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public IList<string> LetterCombinations(string digits)
    {
        if(digits.Length == 0)
        {
            return Array.Empty<string>();
        }

        var digitMap = new char['9' + 1][];
        digitMap['2'] = ['a', 'b', 'c'];
        digitMap['3'] = ['d', 'e', 'f'];
        digitMap['4'] = ['g', 'h', 'i'];
        digitMap['5'] = ['j', 'k', 'l'];
        digitMap['6'] = ['m', 'n', 'o'];
        digitMap['7'] = ['p', 'q', 'r', 's'];
        digitMap['8'] = ['t', 'u', 'v'];
        digitMap['9'] = ['w', 'x', 'y', 'z'];

        var resultLenght = (int)Math.Pow(4, digits.Length);
        var strings = new List<char[]>(resultLenght);
        strings.Add(new char[digits.Length]);

        for (var digitIndex = 0; digitIndex< digits.Length; digitIndex++)
        {
            var digit = digits[digitIndex];
            var letters = digitMap[digit];

            var stringCount = strings.Count;
            for(var stringIndex = 0; stringIndex < stringCount; stringIndex++)
            {
                var str = strings[stringIndex];

                for (var letterIndex = 1; letterIndex < letters.Length; letterIndex++)
                {
                    var letter = letters[letterIndex];
                    var newString = (char[])str.Clone();
                    newString[digitIndex] = letter;
                    strings.Add(newString);
                }

                str[digitIndex] = letters[0];
            }
        }

        var result = new List<string>(resultLenght);
        result.AddRange(strings.Select(i => new string(i)));

        return result;
    }

    public IList<string> LetterCombinations2(string digits)
    {
        if (digits.Length == 0)
        {
            return Array.Empty<string>();
        }

        var digitMap = new char['9' + 1][];
        digitMap['2'] = ['a', 'b', 'c'];
        digitMap['3'] = ['d', 'e', 'f'];
        digitMap['4'] = ['g', 'h', 'i'];
        digitMap['5'] = ['j', 'k', 'l'];
        digitMap['6'] = ['m', 'n', 'o'];
        digitMap['7'] = ['p', 'q', 'r', 's'];
        digitMap['8'] = ['t', 'u', 'v'];
        digitMap['9'] = ['w', 'x', 'y', 'z'];

        var resultLenght = (int)Math.Pow(4, digits.Length);
        var result = new List<string>(resultLenght);
        var buffer = new char[digits.Length];

        Backtrack(0);

        return result;

        void Backtrack(int digitIndex)
        {
            if(digitIndex == digits.Length)
            {
                result.Add(new string(buffer));
                return;
            }

            var digit = digits[digitIndex];
            var letters = digitMap[digit];
            foreach (var letter in letters)
            {
                buffer[digitIndex] = letter;
                Backtrack(digitIndex + 1);
            }
        }
    }

    private record struct StackFrame
    {
        public readonly int DigitIndex { get; init; } 
        public int LetterIndex { get; set; }
    }

    public IList<string> LetterCombinations3(string digits)
    {
        if (digits.Length == 0)
        {
            return Array.Empty<string>();
        }

        var digitMap = new char['9' + 1][];
        digitMap['2'] = ['a', 'b', 'c'];
        digitMap['3'] = ['d', 'e', 'f'];
        digitMap['4'] = ['g', 'h', 'i'];
        digitMap['5'] = ['j', 'k', 'l'];
        digitMap['6'] = ['m', 'n', 'o'];
        digitMap['7'] = ['p', 'q', 'r', 's'];
        digitMap['8'] = ['t', 'u', 'v'];
        digitMap['9'] = ['w', 'x', 'y', 'z'];

        var resultLenght = (int)Math.Pow(4, digits.Length);
        var result = new List<string>(resultLenght);
        var buffer = new char[digits.Length];

        var stack = new Stack<StackFrame>();
        var frame = new StackFrame()
        {
            DigitIndex = 0,
            LetterIndex = 0
        };
        stack.Push(frame);

        while (stack.TryPop(out frame))
        {
            if (frame.DigitIndex == digits.Length)
            {
                result.Add(new string(buffer));
                continue;
            }

            var digit = digits[frame.DigitIndex];
            var letters = digitMap[digit];

            if(frame.LetterIndex == letters.Length)
            {
                continue;
            }

            buffer[frame.DigitIndex] = letters[frame.LetterIndex];
            frame.LetterIndex++;
            stack.Push(frame);

            var newFrame = new StackFrame()
            {
                DigitIndex = frame.DigitIndex + 1,
                LetterIndex = 0,
            };
            stack.Push(newFrame);
        }

        return result;
    }
}
