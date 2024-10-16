using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.Backtracking;

internal class _0078_Subsets
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var nums = new int[] { 1, 2, 3 };
            Test(nums);
        }

        private void Test(int[] nums)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(nums), JsonSerializer.Serialize(nums))
            };

            var result = new _0078_Subsets().Subsets(nums);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(nums), JsonSerializer.Serialize(nums))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public IList<IList<int>> Subsets(int[] nums)
    {
        var result = new List<IList<int>>();
        var buffer = new List<int>(nums.Length);
        Backtrack(buffer, 0);

        return result;

        void Backtrack(List<int> list, int index)
        {
            if (index > nums.Length)
            {
                return;
            }

            result.Add(new List<int>(list));
            for (var i = index; i < nums.Length; i++)
            {
                list.Add(nums[i]);
                Backtrack(list, i + 1);
                list.RemoveAt(list.Count - 1);
            }
        }
    }
}
