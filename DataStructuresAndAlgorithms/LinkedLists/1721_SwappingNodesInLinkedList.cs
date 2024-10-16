using Helpers;

namespace DataStructuresAndAlgorithms.LinkedLists;

internal class _1721_SwappingNodesInLinkedList
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1(ListNodeHelper.ConvertToListNode([1, 2, 3, 4, 5])!, 1);
            Test1(ListNodeHelper.ConvertToListNode([1, 2, 3, 4, 5])!, 2);
            Test1(ListNodeHelper.ConvertToListNode([1, 2, 3, 4, 5])!, 5);
            Test1(ListNodeHelper.ConvertToListNode([7, 9, 6, 6, 7, 8, 3, 0, 9, 5])!, 5);
            Test1(ListNodeHelper.ConvertToListNode([1])!, 1);
        }

        private void Test1(ListNode head, int k)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(head), ListNodeHelper.ConvertToList(head)),
                (nameof(k), k));

            var result = new _1721_SwappingNodesInLinkedList().SwapNodes(head, k);

            printTable.AddProcessedParameters(
                (nameof(head), ListNodeHelper.ConvertToList(head)),
                (nameof(k), k));

            printTable.AddResult(ListNodeHelper.ConvertToList(result));
            Helper.PrintTable(printTable);
        }
    }

    public ListNode SwapNodes(ListNode head, int k)
    {
        var sentinelNode = new ListNode(0);
        sentinelNode.next = head;

        var leftPredecessorNode = sentinelNode;
        for (var i = 0; i < k - 1; i++)
        {
            leftPredecessorNode = leftPredecessorNode.next!;
        }
        var leftNode = leftPredecessorNode.next!;

        var rightPredecessorNode = head;
        var dummyNode = leftNode.next;
        if (dummyNode == null)
        {
            rightPredecessorNode = sentinelNode;
        }
        else
        {
            while (dummyNode.next != null)
            {
                rightPredecessorNode = rightPredecessorNode.next!;
                dummyNode = dummyNode.next;
            }
        }

        var rightNode = rightPredecessorNode.next!;

        leftPredecessorNode.next = rightNode;
        rightPredecessorNode.next = leftNode;

        dummyNode = leftNode.next;
        leftNode.next = rightNode.next;
        rightNode.next = dummyNode;

        return sentinelNode.next;
    }
}
