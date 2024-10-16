using Helpers;

namespace DataStructuresAndAlgorithms.LinkedLists;

internal class _0083_RemoveDuplicatesFromSortedList
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1(ListNodeHelper.ConvertToListNode([1, 1, 2])!);
            Test1(ListNodeHelper.ConvertToListNode([1, 1, 1, 2])!);
            Test1(ListNodeHelper.ConvertToListNode([1, 1, 2, 3, 3])!);
        }

        private void Test1(ListNode head)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(head), ListNodeHelper.ConvertToList(head)));

            var result = new _0083_RemoveDuplicatesFromSortedList().DeleteDuplicates(head);

            printTable.AddProcessedParameters(
                (nameof(head), ListNodeHelper.ConvertToList(head)));

            printTable.AddResult(ListNodeHelper.ConvertToList(result));
            Helper.PrintTable(printTable);
        }
    }

    public ListNode DeleteDuplicates(ListNode head)
    {
        var currentNode = head;
        while (currentNode?.next is not null) 
        {
            if(currentNode.val == currentNode.next.val)
            {
                currentNode.next = currentNode.next.next;
                continue;
            }

            currentNode = currentNode.next;
        }
        return head;
    }
}
