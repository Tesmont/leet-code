using Helpers;

namespace TopInterview150;

internal class _0042_TrappingRainWater
{
    public void Launch()
    {
        Execute([0, 1, 0, 2, 1, 0, 1, 3, 0, 2, 1, 2, 1]);
        Execute([2, 0, 2]);


        Execute([0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1]);
        Execute([4, 2, 0, 3, 2, 5]);
    }

    private void Execute(int[] height)
    {
        var originalheight = height.Clone();
        var result = Trap(height);

        Helper.PrintTable([
            ("original height", originalheight),
            ("processed height", height),
            ("result", result),
            ]);
    }

    public int Trap(int[] height)
    {
        if (height.Length < 3)
        {
            return 0;
        }

        var max = height.Max();
        var maxIndex = Array.IndexOf(height, max);

        var waterVolume = CalculateVolumeOnTheLeftSide(height, maxIndex);
        waterVolume += CalculateVolumeOnTheRightSide(height, maxIndex);

        return waterVolume;
    }

    private int CalculateVolumeOnTheLeftSide(int[] height, int rightColumnIndex)
    {
        var waterVolume = 0;

        while (rightColumnIndex >= 2)
        {
            var max = height.Take(rightColumnIndex).Max();
            var leftColumnIndex = Array.LastIndexOf(height, max, rightColumnIndex - 1, rightColumnIndex);

            waterVolume += CalculateVolume(height, max, leftColumnIndex, rightColumnIndex);

            rightColumnIndex = leftColumnIndex;
        }

        return waterVolume;
    }

    private int CalculateVolumeOnTheRightSide(int[] height, int leftColumnIndex)
    {
        var waterVolume = 0;

        while (leftColumnIndex < height.Length - 2)
        {
            var max = height.Skip(leftColumnIndex + 1).Max();
            var rightColumnIndex = Array.IndexOf(height, max, leftColumnIndex + 1, height.Length - leftColumnIndex - 1);

            waterVolume += CalculateVolume(height, max, leftColumnIndex, rightColumnIndex);

            leftColumnIndex = rightColumnIndex;
        }

        return waterVolume;
    }

    private int CalculateVolume(int[] height, int waterLevel, int leftColumnIndex, int rightColumnIndex)
    {
        var waterVolume = 0;
        for (var i = leftColumnIndex + 1; i < rightColumnIndex; i++)
        {
            waterVolume += waterLevel - height[i];
        }

        return waterVolume;
    }
}
