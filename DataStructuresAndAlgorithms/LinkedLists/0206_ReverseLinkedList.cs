using Helpers;

namespace DataStructuresAndAlgorithms.LinkedLists;

internal class _0206_ReverseLinkedList
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1(ListNodeHelper.ConvertToListNode([1, 2, 3, 4, 5])!);
            Test1(ListNodeHelper.ConvertToListNode([1, 2])!);
            Test1(ListNodeHelper.ConvertToListNode([1, 1, 2, 3, 3])!);
            Test1(ListNodeHelper.ConvertToListNode([])!);
        }

        private void Test1(ListNode head)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(head), ListNodeHelper.ConvertToList(head)));

            var result = new _0206_ReverseLinkedList().ReverseList(head);

            printTable.AddProcessedParameters(
                (nameof(head), ListNodeHelper.ConvertToList(head)));

            printTable.AddResult(ListNodeHelper.ConvertToList(result));
            Helper.PrintTable(printTable);
        }
    }

    public ListNode ReverseList(ListNode head)
    {
        ListNode? previous = null;
        while(head is not null)
        {
            var next = head.next;

            head.next = previous;
            previous = head;

            head = next!;
        }

        return previous!;
    }
}
