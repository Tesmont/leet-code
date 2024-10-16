using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.BinarySearch;

internal class _2300_SuccessfulPairsOfSpellsAndPotions
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var spells = new int[] { 5, 1, 3 };
            var potions = new int[] { 1, 2, 3, 4, 5 };
            var success = 7;
            Test(spells, potions, success);
        }

        private void Test(int[] spells, int[] potions, long success)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(spells), JsonSerializer.Serialize(spells)),
                (nameof(potions), JsonSerializer.Serialize(potions)),
                (nameof(success), JsonSerializer.Serialize(success))
            };

            var result = new _2300_SuccessfulPairsOfSpellsAndPotions().SuccessfulPairs(spells, potions, success);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(spells), JsonSerializer.Serialize(spells)),
                (nameof(potions), JsonSerializer.Serialize(potions)),
                (nameof(success), JsonSerializer.Serialize(success))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int[] SuccessfulPairs(int[] spells, int[] potions, long success)
    {
        Array.Sort(potions);

        var result = new int[spells.Length];

        for (int i = 0; i < spells.Length; i++)
        {
            var target = (long)Math.Ceiling((double)success / spells[i]);
            result[i] = potions.Length - LowerBound(potions, target);
        }
        
        return result;
    }

    private int LowerBound(int[] arr, long target)
    {
        var left = 0L;
        var right = arr.LongLength;

        while(left < right)
        {
            var mid = (left + right) / 2;
            if (arr[mid] >= target)
            {
                right = mid;
            }
            else
            {
                left = mid + 1;
            }
        }

        return (int)left;
    }
}
