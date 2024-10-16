using Helpers;
using System.Text.Json;

namespace Common;

internal class _0066_PlusOne
{
    internal class Tester
    {
        public void LaunchTests()
        {
            int[] digits = { 9, 9, 9 };
            Test(digits);
        }

        private void Test(int[] digits)
        {
            // Serialize parameters before the method call
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(digits), JsonSerializer.Serialize(digits))
            };

            // Call the method to test
            var result = new _0066_PlusOne().PlusOne(digits);

            // Serialize parameters after the method call
            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(digits), JsonSerializer.Serialize(digits))
            };

            // Serialize the result
            var resultStr = JsonSerializer.Serialize(result);

            // Print the comparison table
            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int[] PlusOne(int[] digits)
    {
        for(var i = digits.Length - 1; i >= 0; i--)
        {
            if (digits[i] <= 8)
            {
                digits[i]++;
                return digits;
            }

            digits[i] = 0;
        }
        
        var newDigits = new int[digits.Length + 1];
        Array.Copy(digits, 0, newDigits, 1, digits.Length);
        newDigits[0] = 1;

        return newDigits;
    }
}
