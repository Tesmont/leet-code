using Helpers;

namespace DataStructuresAndAlgorithms.Hashing;

internal class _2958_LengthOfLongestSubarrayWithAtMostKFrequency
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1([1, 2, 3, 1, 2, 3, 1, 2], 2);
            Test1([1, 2, 1, 2, 1, 2, 1, 2], 1);
            Test1([5, 5, 5, 5, 5, 5, 5], 4);

            Test1([2, 2, 3], 1);
            Test1([1, 2, 1, 2, 3], 2);
            Test1([1, 2, 1, 3, 4], 3);
            Test1([1, 1, 1, 2, 2, 3], 2);
        }

        private void Test1(int[] nums, int k)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(nums), nums),
                (nameof(k), k));

            var result = new _2958_LengthOfLongestSubarrayWithAtMostKFrequency().MaxSubarrayLengthV3(nums, k);

            printTable.AddProcessedParameters(
                (nameof(nums), nums),
                (nameof(k), k));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    public int MaxSubarrayLength(int[] nums, int k)
    {
        var subarrayMap = new Dictionary<int, int>();
        var maxSubarrayLength = 0;
        var leftIndex = 0;
        for (var rightIndex = 0; rightIndex < nums.Length; rightIndex++)
        {
            var rightNum = nums[rightIndex];
            if (!subarrayMap.TryGetValue(rightNum, out var frequency))
            {
                subarrayMap[rightNum] = 1;
                maxSubarrayLength = Math.Max(maxSubarrayLength, rightIndex - leftIndex + 1);
                continue;
            }

            if (frequency == k)
            {
                do
                {
                    var leftNum = nums[leftIndex];
                    leftIndex++;
                    if (leftNum == rightNum)
                    {
                        break;
                    }

                    subarrayMap[leftNum]--;
                } while (frequency == k);

                continue;
            }

            frequency++;
            subarrayMap[rightNum] = frequency;

            maxSubarrayLength = Math.Max(maxSubarrayLength, rightIndex - leftIndex + 1);
        }

        return maxSubarrayLength;
    }

    public int MaxSubarrayLengthV2(int[] nums, int k)
    {
        var subarrayMap = new Dictionary<int, int>();
        var maxSubarrayLength = 0;
        var leftIndex = 0;
        for (var rightIndex = 0; rightIndex < nums.Length; rightIndex++)
        {
            var rightNum = nums[rightIndex];
            subarrayMap[rightNum] = subarrayMap.TryGetValue(rightNum, out var frequency) ? frequency + 1 : 1;

            while (subarrayMap[rightNum] > k)
            {
                var leftNum = nums[leftIndex];
                subarrayMap[leftNum]--;
                leftIndex++;
            }

            maxSubarrayLength = Math.Max(maxSubarrayLength, rightIndex - leftIndex + 1);
        }

        return maxSubarrayLength;
    }

    public int MaxSubarrayLengthV3(int[] nums, int k)
    {
        var map = new Dictionary<int, int>();
        var leftIndex = 0;
        var lettersWithFrequecnceOverK = 0;
        for (var rightIndex = 0; rightIndex < nums.Length; rightIndex++)
        {
            var rightNum = nums[rightIndex];
            if (!map.TryGetValue(rightNum, out var frequency))
            {
                frequency = 1;
            }
            else
            {
                frequency++;
            }
            map[rightNum] = frequency;
            if (frequency == k + 1)
            {
                lettersWithFrequecnceOverK++;
            }

            if(lettersWithFrequecnceOverK > 0)
            {
                var leftNum = nums[leftIndex];
                leftIndex++;
                frequency = map[leftNum] - 1;
                map[leftNum] = frequency;
                if(frequency == k)
                {
                    lettersWithFrequecnceOverK--;
                }
            }
        }

        return nums.Length - leftIndex;
    }
}
