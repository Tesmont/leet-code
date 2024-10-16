using Helpers;

namespace DataStructuresAndAlgorithms.LinkedLists;

internal class _0203_RemoveLinkedListElements
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1(ListNodeHelper.ConvertToListNode([1, 2, 6, 3, 4, 5, 6])!, 6);
            Test1(ListNodeHelper.ConvertToListNode([1, 2, 2, 1])!, 2);
            Test1(ListNodeHelper.ConvertToListNode([1])!, 1);
        }

        private void Test1(ListNode head, int val)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(head), ListNodeHelper.ConvertToList(head)),
                (nameof(val), val));

            var result = new _0203_RemoveLinkedListElements().RemoveElements(head, val);

            printTable.AddProcessedParameters(
                (nameof(head), ListNodeHelper.ConvertToList(head)),
                (nameof(val), val));

            printTable.AddResult(ListNodeHelper.ConvertToList(result));
            Helper.PrintTable(printTable);
        }
    }

    public ListNode RemoveElements(ListNode head, int val)
    {
        var sentinelNode = new ListNode(0);
        sentinelNode.next = head;

        var previousNode = sentinelNode;
        var currentNode = head;

        while(currentNode != null)
        {
            if(currentNode.val == val)
            {
                previousNode.next = currentNode.next;
            }
            else
            {
                previousNode = currentNode;
            }

            currentNode = currentNode.next;
        }

        return sentinelNode.next;
    }
}
