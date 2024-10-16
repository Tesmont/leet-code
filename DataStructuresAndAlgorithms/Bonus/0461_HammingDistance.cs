using Helpers;
using System.Numerics;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.Bonus;

internal class _0461_HammingDistance
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var x = 1;
            var y = 4;
            Test(x, y);
        }

        private void Test(int x, int y)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(x), JsonSerializer.Serialize(x)),
                (nameof(y), JsonSerializer.Serialize(y))
            };

            var result = new _0461_HammingDistance().HammingDistance(x, y);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(x), JsonSerializer.Serialize(x)),
                (nameof(y), JsonSerializer.Serialize(y))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int HammingDistance(int x, int y)
    {
        BitOperations.PopCount((uint)(x ^ y));
        const int lenght = 32;

        x ^= y;
        var hammingDistance = 0;
        for (var i = 0; i < lenght; i++)
        {
            var val = (x >> i) & 1;
            if (val == 1)
            {
                hammingDistance++;
            }
        }

        return hammingDistance;
    }

    public int HammingDistance2(int x, int y)
    {
        return BitOperations.PopCount((uint)(x ^ y));
    }

    /// <summary>
    /// Counting bits set, Brian Kernighan's way
    /// https://graphics.stanford.edu/~seander/bithacks.html#CountBitsSetKernighan
    /// </summary>
    public int HammingDistance3(int x, int y)
    {
        x ^= y;
        var hammingDistance = 0;
        while(x > 0)
        {
            hammingDistance++;
            x = x & (x - 1);
        }

        return hammingDistance;
    }
}
