using Helpers;
using System.Text.Json;

namespace TopInterview150;
internal class _0055_JumpGame
{
    public void Launch()
    {
        Execute([0, 3, 1, 1, 4]);
        Execute([2, 3, 1, 1, 4]);
        Execute([3, 2, 1, 0, 4]);
        Execute([3, 0, 2, 0, 5]);
    }

    private void Execute(int[] nums)
    {
        var originalNums = JsonSerializer.Serialize(nums);
        var result = CanJump(nums);

        Helper.PrintTable([
            ("numns", originalNums),
            ("processed numns", JsonSerializer.Serialize(nums)),
            ("result", result),
            ]);
    }

    public bool CanJump(int[] nums)
    {
        var targetIndex = nums.Length - 1;
        for (var i = targetIndex - 1; i >= 0; i--)
        {
            var maxAvaiableIndex = i + nums[i];
            if (maxAvaiableIndex >= targetIndex)
            {
                targetIndex = i;
            }
        }

        return targetIndex == 0;
    }
}
