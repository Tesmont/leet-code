using Helpers;

namespace DataStructuresAndAlgorithms.StacksAndQueues;

internal class _1438_LongestContinuousSubarrayWithAbsoluteDiff
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1([9, 1, 4, 7], 9);
            Test1([1, 1, 9, 7], 9);

            Test1([8, 2, 4, 7], 4);
            Test1([10, 1, 2, 4, 7, 2], 5);
            Test1([4, 2, 2, 2, 4, 4, 2, 2], 0);
        }

        private void Test1(int[] nums, int limit)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(nums), string.Join(", ", nums)),
                (nameof(limit), limit.ToString()));

           var result = new _1438_LongestContinuousSubarrayWithAbsoluteDiff().LongestSubarray(nums, limit);

            printTable.AddProcessedParameters(
                (nameof(nums), string.Join(", ", nums)),
                (nameof(limit), limit.ToString()));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    public int LongestSubarray(int[] nums, int limit)
    {
        var increasingDeque = new LinkedList<(int Num, int Index)>();
        var decreasingDeque = new LinkedList<(int Num, int Index)>();

        var leftIndex = 0;
        var rightIndex = 0;
        var maxLenght = 0;

        for(; rightIndex < nums.Length; rightIndex++)
        {
            var num = nums[rightIndex];

            var lastNode = increasingDeque.Last;
            while (lastNode != null && num < lastNode.Value.Num)
            {
                increasingDeque.RemoveLast();
                lastNode = increasingDeque.Last;
            }

            lastNode = decreasingDeque.Last;
            while (lastNode != null && num > lastNode.Value.Num)
            {
                decreasingDeque.RemoveLast();
                lastNode = decreasingDeque.Last;
            }

            increasingDeque.AddLast((num, rightIndex));
            decreasingDeque.AddLast((num, rightIndex));

            var minNumNode = increasingDeque.First!;
            var maxNumNode = decreasingDeque.First!;
            var difference = maxNumNode.Value.Num - minNumNode.Value.Num;
            while (difference > limit)
            {
                if (leftIndex == minNumNode.Value.Index)
                {
                    increasingDeque.RemoveFirst();
                }

                if (leftIndex == maxNumNode.Value.Index)
                {
                    decreasingDeque.RemoveFirst();
                }

                leftIndex++;

                minNumNode = increasingDeque.First!;
                maxNumNode = decreasingDeque.First!;
                difference = maxNumNode.Value.Num - minNumNode.Value.Num;
            }

            maxLenght = Math.Max(maxLenght, rightIndex - leftIndex + 1);
        }

        return maxLenght;
    }

    public int LongestSubarrayV2(int[] nums, int limit)
    {
        var increasingDeque = new LinkedList<int>();
        var decreasingDeque = new LinkedList<int>();

        var leftIndex = 0;
        var rightIndex = 0;
        var maxLenght = 0;

        for (; rightIndex < nums.Length; rightIndex++)
        {
            var num = nums[rightIndex];

            var lastNode = increasingDeque.Last;
            while (lastNode != null && num < nums[lastNode.Value])
            {
                increasingDeque.RemoveLast();
                lastNode = increasingDeque.Last;
            }

            lastNode = decreasingDeque.Last;
            while (lastNode != null && num > nums[lastNode.Value])
            {
                decreasingDeque.RemoveLast();
                lastNode = decreasingDeque.Last;
            }

            increasingDeque.AddLast(rightIndex);
            decreasingDeque.AddLast(rightIndex);

            var minNumIndex = increasingDeque.First!.Value;
            var maxNumIndex = decreasingDeque.First!.Value;
            var difference = nums[maxNumIndex] - nums[minNumIndex];
            while (difference > limit)
            {
                if (leftIndex == minNumIndex)
                {
                    increasingDeque.RemoveFirst();
                    minNumIndex = increasingDeque.First!.Value;
                    difference = nums[maxNumIndex] - nums[minNumIndex];
                }
                else if (leftIndex == maxNumIndex)
                {
                    decreasingDeque.RemoveFirst();
                    maxNumIndex = decreasingDeque.First!.Value;
                    difference = nums[maxNumIndex] - nums[minNumIndex];
                }

                leftIndex++;
            }

            maxLenght = Math.Max(maxLenght, rightIndex - leftIndex + 1);
        }

        return maxLenght;
    }
}
