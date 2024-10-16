using Helpers;
using System.Text.Json;

namespace Common;

internal class _0067_AddBinary
{
    internal class Tester
    {
        public void LaunchTests()
        {
            string a = "101111";
            string b = "10";
            Test(a, b);
        }

        private void Test(string a, string b)
        {
            // Serialize parameters before the method call
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(a), JsonSerializer.Serialize(a)),
                (nameof(b), JsonSerializer.Serialize(b))
            };

            // Call the method to test
            var result = new _0067_AddBinary().AddBinary(a, b);

            // Serialize parameters after the method call
            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(a), JsonSerializer.Serialize(a)),
                (nameof(b), JsonSerializer.Serialize(b))
            };

            // Serialize the result
            var resultStr = JsonSerializer.Serialize(result);

            // Print the comparison table
            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public string AddBinary(string a, string b)
    {
        if (a.Length < b.Length) 
        {
            var buf = a;
            a = b;
            b = buf;
        }

        Span<char> fullSum = stackalloc char[10 * 10 * 10 * 10 + 1]
            .Slice(0, a.Length + 1);

        var sum = fullSum.Slice(1, a.Length);

        var aIdx = a.Length - 1;
        var isCarry = false;
        for (var bIdx = b.Length - 1; bIdx >= 0; aIdx--, bIdx--)
        {
            var aDigit = a[aIdx] - '0';
            var bDigit = b[bIdx] - '0';

            var newDigit = aDigit + bDigit;
            if (isCarry)
            {
                newDigit++;
            }

            if (newDigit <= 1)
            {
                sum[aIdx] = (char)(newDigit + '0');
                isCarry = false;
                continue;
            }

            sum[aIdx] = (char)(newDigit % 2 + '0');
            isCarry = true;
        }

        if (!isCarry)
        {
            a.AsSpan().Slice(0, aIdx + 1).CopyTo(sum);
            return new string(sum);
        }

        for (; aIdx >= 0; aIdx--)
        {
            var aDigit = a[aIdx] - '0';
            aDigit++;
            if (aDigit <= 1)
            {
                sum[aIdx] = (char)(aDigit + '0');
                a.AsSpan().Slice(0, aIdx).CopyTo(sum);
                return new string(sum);
            }

            sum[aIdx] = '0';
        }

        fullSum[0] = '1';
        return new string(fullSum);
    }
}
