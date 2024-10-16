using Helpers;

namespace DataStructuresAndAlgorithms.LinkedLists;

internal class _0019_RemoveNthNodeFromEndOfList
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1(ListNodeHelper.ConvertToListNode([1, 2, 3, 4, 5])!, 2);
            Test1(ListNodeHelper.ConvertToListNode([1, 2, 3])!, 1);
            Test1(ListNodeHelper.ConvertToListNode([1])!, 1);
            Test1(ListNodeHelper.ConvertToListNode([1, 2])!, 2);
        }

        private void Test1(ListNode head, int n)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(head), ListNodeHelper.ConvertToList(head)),
                (nameof(n), n));

            var result = new _0019_RemoveNthNodeFromEndOfList().RemoveNthFromEnd(head, n);

            printTable.AddProcessedParameters(
                (nameof(head), ListNodeHelper.ConvertToList(head)),
                (nameof(n), n));

            printTable.AddResult(ListNodeHelper.ConvertToList(result));
            Helper.PrintTable(printTable);
        }
    }

    public ListNode? RemoveNthFromEnd(ListNode head, int n)
    {
        var slow = head;
        var fast = head;
        for(var i = 0; i < n; i++)
        {
            fast = fast!.next;
        }

        if(fast is null)
        {
            return slow.next;
        }

        while (fast?.next is not null)
        {
            slow = slow!.next;
            fast = fast.next;
        }

        slow!.next = slow!.next!.next;

        return head;
    }
}
