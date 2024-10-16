using Helpers;

namespace DataStructuresAndAlgorithms.LinkedLists;

internal class _2095_DeleteMiddleNodeOfLinkedList
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1(ListNodeHelper.ConvertToListNode([1, 3, 4, 7, 1, 2, 6])!);

            Test1(ListNodeHelper.ConvertToListNode([1])!);
            Test1(ListNodeHelper.ConvertToListNode([1, 2])!);
            Test1(ListNodeHelper.ConvertToListNode([1, 2, 3])!);
            Test1(ListNodeHelper.ConvertToListNode([1, 2, 3, 4])!);
            Test1(ListNodeHelper.ConvertToListNode([1, 2, 3, 4, 5])!);
            Test1(ListNodeHelper.ConvertToListNode([1, 2, 3, 4, 5, 6])!);
            Test1(ListNodeHelper.ConvertToListNode([1, 2, 3, 4, 5, 6, 7])!);
            Test1(ListNodeHelper.ConvertToListNode([1, 2, 3, 4, 5, 6, 7, 8])!);
            Test1(ListNodeHelper.ConvertToListNode([1, 2, 3, 4, 5, 6, 7, 8, 9])!);
            Test1(ListNodeHelper.ConvertToListNode([1, 2, 3, 4, 5, 6, 7, 8, 9, 10])!);
        }

        private void Test1(ListNode head)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(head), ListNodeHelper.ConvertToList(head)));

            var result = new _2095_DeleteMiddleNodeOfLinkedList().DeleteMiddle(head);

            printTable.AddProcessedParameters(
                (nameof(head), ListNodeHelper.ConvertToList(head)));

            printTable.AddResult(ListNodeHelper.ConvertToList(result));
            Helper.PrintTable(printTable);
        }
    }

    public ListNode? DeleteMiddle(ListNode head)
    {
        if(head.next is null)
        {
            return null;
        }

        var slow = head;
        var fast = head.next?.next;
        while (fast?.next != null)
        {
            slow = slow.next!;
            fast = fast.next.next;
        }

        slow.next = slow.next!.next;

        return head;
    }
}
