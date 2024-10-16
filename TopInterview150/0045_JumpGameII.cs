using Helpers;
using System.Text.Json;

namespace TopInterview150;

internal class _0045_JumpGameII
{
    public void Launch()
    {
        Execute([2, 3, 1, 1, 4]);
        Execute([2, 3, 0, 1, 4]);

        Execute([0, 3, 1, 1, 4]);
        Execute([3, 2, 1, 0, 4]);
        Execute([3, 0, 2, 0, 5]);
    }

    private void Execute(int[] nums)
    {
        var originalNums = JsonSerializer.Serialize(nums);
        var result = Jump(nums);

        Helper.PrintTable([
            ("numns", originalNums),
            ("processed numns", JsonSerializer.Serialize(nums)),
            ("result", result),
            ]);
    }

    public int Jump(int[] nums)
    {
        if (nums.Length <= 1)
        {
            return 0;
        }

        var jumps = 0;
        var currentFarthestAvailableIndex = 0;
        var newFarthestAvailableIndex = 0;
        for (int i = 0; i < nums.Length - 1; i++)
        {
            newFarthestAvailableIndex = Math.Max(newFarthestAvailableIndex, nums[i] + i);

            if (i == currentFarthestAvailableIndex)
            {
                jumps++;
                currentFarthestAvailableIndex = newFarthestAvailableIndex;

                if (currentFarthestAvailableIndex >= nums.Length - 1)
                {
                    return jumps;
                }
            }
        }

        return jumps;
    }
}
