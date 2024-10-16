using Helpers;

namespace DataStructuresAndAlgorithms.Hashing;

internal class _1248_CountNumberOfNiceSubarrays
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1([1, 1, 2, 1, 1], 3);
            Test1([2, 4, 6], 1);
            Test1([2, 2, 2, 1, 2, 2, 1, 2, 2, 2], 2);
        }

        private void Test1(int[] nums, int k)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(nums), nums),
                (nameof(k), k));

            var result = new _1248_CountNumberOfNiceSubarrays().NumberOfSubarraysV3(nums, k);

            printTable.AddProcessedParameters(
                (nameof(nums), nums),
                (nameof(k), k));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    public int NumberOfSubarrays(int[] nums, int k)
    {
        var leftIndex = 0;
        var rightIndex = 0;
        var oddNumberCount = 0;
        var subarrayCount = 0;

        for(; rightIndex < nums.Length; rightIndex++) 
        {
            if (nums[rightIndex] % 2 != 0)
            {
                oddNumberCount++;
            }

            if (oddNumberCount == k)
            {
                subarrayCount++;
            }

            if(oddNumberCount == k + 1
                || rightIndex == nums.Length - 1)
            {
                while (leftIndex != rightIndex)
                {
                    if (nums[leftIndex] % 2 != 0)
                    {
                        oddNumberCount--;
                    }
                    else
                    {
                        subarrayCount++;
                    }

                    leftIndex++;
                }
            }
        }

        return subarrayCount;
    }

    public int NumberOfSubarraysV2(int[] nums, int k)
    {
        var oddNumberMap = new Dictionary<int, int>()
        {
            { 0, 1 }
        };

        var oddNumberCount = 0;
        var subarrayCount = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] % 2 != 0)
            { 
                oddNumberCount++; 
            }
            var difference = oddNumberCount - k;
            if (oddNumberMap.TryGetValue(difference, out var differencesCount))
            {
                subarrayCount += differencesCount;
            }

            oddNumberMap[oddNumberCount] = oddNumberMap.TryGetValue(oddNumberCount, out var windowsSumsCount)
                ? windowsSumsCount + 1
                : 1;
        }

        return subarrayCount;
    }
    
    public int NumberOfSubarraysV3(int[] nums, int k)
    {
        var oddNumberMap = new int[k + 2];
        oddNumberMap[0] = 1;

        var oddNumberCount = 0;
        var subarrayCount = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] % 2 != 0)
            {
                oddNumberCount++;
            }
            var difference = oddNumberCount - k;
            subarrayCount = oddNumberMap[Math.Abs(difference)];

            oddNumberMap[oddNumberCount]++;
        }

        return subarrayCount;
    }
}

