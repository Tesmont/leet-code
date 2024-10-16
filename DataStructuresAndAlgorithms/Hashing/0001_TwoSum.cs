using Helpers;

namespace DataStructuresAndAlgorithms.Hashing;

internal class _0001_TwoSum
{
    public void Launch()
    {
        Execute([2, 7, 11, 15], 9);
        Execute([3, 2, 4], 6);
        Execute([3, 3], 6);
    }

    private void Execute(int[] nums, int target)
    {
        var result = TwoSum(nums, target);

        Helper.PrintTable([
            ("nums", nums),
            ("target", target),
            ("result", result),
            ]);
    }

    public int[] TwoSum(int[] nums, int target)
    {
        var dict = new Dictionary<int, int>(nums.Length);

        for (var i = 0; i < nums.Length; i++)
        {
            var value = nums[i];
            var left = target - value;
            if (dict.TryGetValue(left, out var index))
            {
                return [index, i];
            }

            dict[value] = i;
        }

        return Array.Empty<int>();
    }
}
