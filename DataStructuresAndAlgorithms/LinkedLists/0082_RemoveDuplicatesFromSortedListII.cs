using Helpers;

namespace DataStructuresAndAlgorithms.LinkedLists;

internal class _0082_RemoveDuplicatesFromSortedListII
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1(ListNodeHelper.ConvertToListNode([1, 2, 3, 3, 4, 4, 5])!);
            Test1(ListNodeHelper.ConvertToListNode([1, 1, 1, 2, 3])!);
            Test1(ListNodeHelper.ConvertToListNode([1, 1, 2, 2])!);
        }

        private void Test1(ListNode head)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(head), ListNodeHelper.ConvertToList(head)));

            var result = new _0082_RemoveDuplicatesFromSortedListII().DeleteDuplicates(head);

            printTable.AddProcessedParameters(
                (nameof(head), ListNodeHelper.ConvertToList(head)));

            printTable.AddResult(ListNodeHelper.ConvertToList(result));
            Helper.PrintTable(printTable);
        }
    }

    public ListNode DeleteDuplicates(ListNode head)
    {
        var dummy = new ListNode(0);
        dummy.next = head;

        var previousNode = dummy;
        while(head?.next != null)
        {
            if(head.val != head.next.val)
            {
                previousNode = head;
                head = head.next!;
                continue;
            }

            var value = head.val;
            head = head.next.next!;
            while(head?.val == value) 
            {
                head = head.next!;
            }

            previousNode.next = head;
        }

        return dummy.next;
    }
}
