using Helpers;

namespace DataStructuresAndAlgorithms.LinkedLists;

internal class _0092_ReverseLinkedListII
{
    internal class Tester
    {
        public void LaunchTests()
        {
            //Test1(ListNodeHelper.ConvertToListNode([1, 2, 3, 4, 5])!, 1, 4);
            //Test1(ListNodeHelper.ConvertToListNode([1, 2, 3, 4, 5])!, 1, 5);
            Test1(ListNodeHelper.ConvertToListNode([1, 2, 3, 4, 5])!, 2, 4);
            Test1(ListNodeHelper.ConvertToListNode([1, 2, 3, 4, 5])!, 1, 5);
            Test1(ListNodeHelper.ConvertToListNode([5, 4, 3, 2, 1])!, 2, 4);
        }

        private void Test1(ListNode head, int left, int right)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(head), ListNodeHelper.ConvertToList(head)),
                (nameof(left), left),
                (nameof(right), right));

            var result = new _0092_ReverseLinkedListII().ReverseBetween(head, left, right);

            printTable.AddProcessedParameters(
                (nameof(head), ListNodeHelper.ConvertToList(head)),
                (nameof(left), left),
                (nameof(right), right));

            printTable.AddResult(ListNodeHelper.ConvertToList(result));
            Helper.PrintTable(printTable);
        }
    }

    public ListNode ReverseBetween(ListNode head, int left, int right)
    {
        ListNode? lastSkippedNode = null;
        ListNode firstRevertedNode;
        if (left > 1)
        {
            lastSkippedNode = head;
            for (var i = 0; i < left - 2; i++)
            {
                lastSkippedNode = lastSkippedNode.next!;
            }

            firstRevertedNode = lastSkippedNode.next!;
        }
        else
        {
            firstRevertedNode = head;
        }

        var currentNode = firstRevertedNode;
        ListNode? lastRevertedNode = null;
        for(var i = left; i <= right; i++)
        {
            var next = currentNode.next!;
            currentNode.next = lastRevertedNode;
            lastRevertedNode = currentNode;
            currentNode = next;
        }

        firstRevertedNode.next = currentNode;

        if (left == 1)
        {
            return lastRevertedNode!;
        }

        lastSkippedNode!.next = lastRevertedNode;
        
        return head;
    }
}
