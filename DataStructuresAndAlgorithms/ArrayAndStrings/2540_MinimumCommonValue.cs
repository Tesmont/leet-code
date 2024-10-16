using Helpers;

namespace DataStructuresAndAlgorithms.ArrayAndStrings;

internal class _2540_MinimumCommonValue
{
    public void Launch()
    {
        Execute([1, 2, 3], [2, 4]);
        Execute([1, 2, 3, 6], [2, 3, 4, 5]);

        Execute([1, 4], [2, 3, 4]);
        Execute([1, 4, 5], [2, 3, 4, 5]);
    }

    private void Execute(int[] nums1, int[] nums2)
    {
        var processedNums1 = Helper.DeepClone(nums1);
        var processedNums2 = Helper.DeepClone(nums2);
        var result = GetCommon(processedNums1, processedNums2);

        Helper.PrintTable([
            ("nums1", nums1),
            ("nums2", nums2),
            ("processedNums1", processedNums1),
            ("processedNums2", processedNums2),
            ("result", result),
            ]);
    }

    public int GetCommon(int[] nums1, int[] nums2)
    {
        var firstIndex = 0;
        var secondIndex = 0;

        while (firstIndex < nums1.Length && secondIndex < nums2.Length)
        {
            if (nums1[firstIndex] == nums2[secondIndex])
            {
                return nums1[firstIndex];
            }

            if (nums1[firstIndex] < nums2[secondIndex])
            {
                firstIndex++;
            }
            else
            {
                secondIndex++;
            }
        }

        return -1;
    }

    public int GetCommonV2(int[] nums1, int[] nums2)
    {
        HashSet<int> minLenghtNums;
        if(nums1.Length < nums2.Length) 
        {
            minLenghtNums = nums1.ToHashSet();
            nums1 = nums2;
        }
        else
        {
            minLenghtNums = nums2.ToHashSet();
        }

        for(var i = 0; i < nums1.Length; i++) 
        {
            if (minLenghtNums.Contains(nums1[i]))
            {
                return nums1[i];
            }
        }

        return -1;
    }
}
