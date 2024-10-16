using Helpers;

namespace DataStructuresAndAlgorithms.StacksAndQueues;

internal class _0239_SlidingWindowMaximum
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1([1, 3, -1, -3, 5, 3, 6, 7], 3);
            Test1([1, 3, 1, 2, 0, 5], 3);
            Test1([1], 1);
            Test1([9, 11], 2);
            Test1([4, -2], 2);
            Test1([1, -1], 1);
        }

        private void Test1(int[] nums, int k)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(nums), string.Join(", ", nums)),
                (nameof(k), k.ToString()));

            var result = new _0239_SlidingWindowMaximum().MaxSlidingWindow(nums, k);

            printTable.AddProcessedParameters(
                (nameof(nums), string.Join(", ", nums)),
                (nameof(k), k.ToString()));

            printTable.AddResult(string.Join(", ", result));
            Helper.PrintTable(printTable);
        }
    }

    public int[] MaxSlidingWindow(int[] nums, int k)
    {
        if(k == 1)
        {
            return nums;
        }

        var maximums = new int[nums.Length - k + 1];
        var decreasingDeque = new LinkedList<int>();

        LinkedListNode<int>? lastNode;
        for (var i = 0; i < k; i++)
        {
            lastNode = decreasingDeque.Last;
            while (lastNode != null && nums[i] > nums[lastNode.Value])
            {
                decreasingDeque.RemoveLast();
                lastNode = decreasingDeque.Last;
            }

            decreasingDeque.AddLast(i);
        }

        maximums[0] = nums[decreasingDeque.First!.Value];

        for (var i = k; i < nums.Length; i++)
        {
            lastNode = decreasingDeque.Last;
            while (lastNode != null && nums[i] > nums[lastNode.Value])
            {
                decreasingDeque.RemoveLast();
                lastNode = decreasingDeque.Last;
            }

            decreasingDeque.AddLast(i);

            var first = decreasingDeque.First.Value;
            if (first + k == i)
            {
                decreasingDeque.RemoveFirst();
                first = decreasingDeque.First.Value;
            }

            maximums[i - k + 1] = nums[first];
        }

        return maximums;
    }
}
