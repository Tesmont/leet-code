using Helpers;

namespace DataStructuresAndAlgorithms.LinkedLists;

internal class _2130_MaximumTwinSumOfLinkedList
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1(ListNodeHelper.ConvertToListNode([1, 2])!);
            Test1(ListNodeHelper.ConvertToListNode([1, 2, 3, 4])!);
            Test1(ListNodeHelper.ConvertToListNode([1, 2, 3, 4, 5, 6])!);
            Test1(ListNodeHelper.ConvertToListNode([1, 2, 3, 4, 5, 6, 7, 8])!);
            Test1(ListNodeHelper.ConvertToListNode([1, 2, 3, 4, 5, 6, 7, 8, 9, 10])!);
            Test1(ListNodeHelper.ConvertToListNode([5, 4, 2, 1])!);
            Test1(ListNodeHelper.ConvertToListNode([4, 2, 2, 3])!);
            Test1(ListNodeHelper.ConvertToListNode([1, 100000])!);
        }

        private void Test1(ListNode head)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(head), ListNodeHelper.ConvertToList(head)));

            var result = new _2130_MaximumTwinSumOfLinkedList().PairSum(head);

            printTable.AddProcessedParameters(
                (nameof(head), ListNodeHelper.ConvertToList(head)));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    public int PairSum(ListNode head)
    {
        var middleNode = FindMiddleNode(head);
        var firstNode = Reverse(middleNode);

        var maxSum = int.MinValue;
        while(firstNode is not null)
        {
            var sum = head.val + firstNode.val;
            maxSum = Math.Max(maxSum, sum);

            head = head.next!;
            firstNode = firstNode.next!;
        }

        return maxSum;
    }

    private ListNode FindMiddleNode(ListNode head)
    {
        var fast = head;

        while(fast is not null)
        {
            head = head.next!;
            fast = fast.next!.next;
        }

        return head;
    }

    private ListNode Reverse(ListNode head)
    {
        ListNode? previous = null;
        while(head is not null)
        {
            var next = head.next!;
            head.next = previous;
            previous = head;
            head = next;
        }

        return previous!;
    }
}
