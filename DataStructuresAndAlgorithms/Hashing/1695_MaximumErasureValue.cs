using Helpers;

namespace DataStructuresAndAlgorithms.Hashing;

internal class _1695_MaximumErasureValue
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1([4, 2, 4, 5, 6]);
            Test1([5, 2, 1, 2, 5, 2, 1, 2, 5]);

            Test1([187, 470, 25, 436, 538, 809, 441, 167, 477, 110, 275, 133, 666, 345, 411, 459, 490, 266, 987, 965, 429, 166, 809, 340, 467, 318, 125, 165, 809, 610, 31, 585, 970, 306, 42, 189, 169, 743, 78, 810, 70, 382, 367, 490, 787, 670, 476, 278, 775, 673, 299, 19, 893, 817, 971, 458, 409, 886, 434]);
        }

        private void Test1(int[] nums)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(nums), nums));

            var result = new _1695_MaximumErasureValue().MaximumUniqueSubarray(nums);

            printTable.AddProcessedParameters(
                (nameof(nums), nums));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    public int MaximumUniqueSubarray(int[] nums)
    {
        var map = new HashSet<int>();
        var leftIndex = 0;
        var rightIndex = 0;
        var maxWindowSum = 0;
        var currentWindowSum = 0;

        for(;rightIndex < nums.Length; rightIndex++)
        {
            var rightNum = nums[rightIndex];
            if (map.Add(rightNum))
            {
                currentWindowSum += rightNum;
                maxWindowSum = Math.Max(maxWindowSum, currentWindowSum);
                continue;
            }

            while(leftIndex <= rightIndex)
            {
                var leftNum = nums[leftIndex];
                leftIndex++;
                if(leftNum == rightNum)
                {
                    break;
                }

                map.Remove(leftNum);
                currentWindowSum -= leftNum;
            }
        }
        
        return maxWindowSum;
    }
}
