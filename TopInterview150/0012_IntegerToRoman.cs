using Helpers;
using System.Text;

namespace TopInterview150;

internal class _0012_IntegerToRoman
{
    public void Launch()
    {
        Execute(3749);
        Execute(58);
        Execute(1994);

        Execute(10);
        Execute(100);
        Execute(1000);

        Execute(11);
        Execute(101);
        Execute(1001);
    }

    private void Execute(int num)
    {
        var result = new SolutionV2().IntToRoman(num);

        Helper.PrintTable([
            ("num", num),
            ("result", result),
            ]);
    }

    public class SolutionV1
    {
        private static readonly string[][] _map =
        [
            [string.Empty, "I","II","III","IV","V","VI","VII","VIII","IX"],
            [string.Empty, "X","XX","XXX","XL","L","LX","LXX","LXXX","XC"],
            [string.Empty, "C","CC","CCC","CD","D","DC","DCC","DCCC","CM"],
            [string.Empty, "M","MM","MMM" ],
        ];

        public string IntToRoman(int num)
        {
            var resultParts = new List<string>(4);
            for (var i = 0; num > 0; i++)
            {
                var value = num % 10;
                var partOfResult = _map[i][value];
                num /= 10;

                resultParts.Add(partOfResult);
            }

            var maxLenght = resultParts.Sum(i => i.Length);
            var resultBuilder = new StringBuilder(maxLenght);
            for (var i = resultParts.Count - 1; i >= 0; i--)
            {
                resultBuilder.Append(resultParts[i]);
            }

            return resultBuilder.ToString();
        }
    }

    public class SolutionV2
    {
        private static readonly string[] _romanValues =
        [
            "I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM", "M"
        ];

        private static readonly int[] _integerValues =
        [
            1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000
        ];

        private static readonly int _startIndex = _integerValues.Length - 1;

        public string IntToRoman(int num)
        {
            StringBuilder resultBuilder = new StringBuilder();
            int i = _startIndex;
            while (num > 0)
            {
                while (num >= _integerValues[i])
                {
                    num -= _integerValues[i];
                    resultBuilder.Append(_romanValues[i]);
                }
                i--;
            }

            return resultBuilder.ToString();
        }
    }
}
