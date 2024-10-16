using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.Greedy;

internal class _1323_Maximum69Number
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var num = 9996;
            Test(num);
        }

        private void Test(int num)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(num), JsonSerializer.Serialize(num))
            };

            var result = new _1323_Maximum69Number().Maximum69Number2(num);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(num), JsonSerializer.Serialize(num))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int Maximum69Number(int num)
    {
        int numLength = (int)Math.Log10(num);
        
        for(var power = numLength; power >= 0; power--)
        {
            int commonFactor = (int)Math.Pow(10, power);
            int digit = num / commonFactor % 10;

            if(digit != 6)
            {
                continue;
            }

            num += 3 * commonFactor;
            return num;
        }

        return num;
    }

    public int Maximum69Number2(int num)
    {
        const int commonFactor = 10;

        var max = num;
        var quotient = num;
        var multiplier = 1;

        while (quotient > 0)
        {
            var digit = quotient % commonFactor;
            if(digit == 6)
            {
                max = num + 3 * multiplier;
            }

            quotient /= commonFactor;
            multiplier *= commonFactor;
        }

        return max;
    }
}
