using Helpers;
using System.Text.Json;

namespace TopInterview150;

internal class _0026_RemoveDuplicatesFromSortedArray
{
    public void Launch()
    {
        Execute([1, 1, 2]);
        Execute([0, 0, 1, 1, 1, 2, 2, 3, 3, 4]);
        Execute([]);
    }

    private void Execute(int[] nums)
    {
        var originalNums = JsonSerializer.Serialize(nums);
        var result = RemoveDuplicates(nums);

        Helper.PrintTable([
            ("numns", originalNums),
            ("processed numns", JsonSerializer.Serialize(nums)),
            ("result", result),
            ]);
    }

    public int RemoveDuplicates(int[] nums)
    {
        if (nums.Length == 0)
        {
            return 0;
        }

        var k = 1;
        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i] != nums[i - 1])
            {
                nums[k] = nums[i];
                k++;
            }
        }

        return k;
    }
}
