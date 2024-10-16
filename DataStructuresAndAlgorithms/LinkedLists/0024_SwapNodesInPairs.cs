using Helpers;

namespace DataStructuresAndAlgorithms.LinkedLists;

internal class _0024_SwapNodesInPairs
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1(ListNodeHelper.ConvertToListNode([1, 2, 3, 4])!);
            Test1(ListNodeHelper.ConvertToListNode([1, 2, 3])!);
            Test1(ListNodeHelper.ConvertToListNode([])!);
        }

        private void Test1(ListNode head)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(head), ListNodeHelper.ConvertToList(head)));

            var result = new _0024_SwapNodesInPairs().SwapPairs(head);

            printTable.AddProcessedParameters(
                (nameof(head), ListNodeHelper.ConvertToList(head)));

            printTable.AddResult(ListNodeHelper.ConvertToList(result));
            Helper.PrintTable(printTable);
        }
    }

    public ListNode? SwapPairs(ListNode head)
    {
        if(head?.next is null)
        {
            return head;
        }

        var currentPairFirstNode = head;
        var currentPairSecondNode = head.next;
        head = currentPairSecondNode;
        do
        {
            var nextPairFirstNode = currentPairSecondNode.next;
            var nextPairSecondNode = nextPairFirstNode?.next;

            currentPairFirstNode.next = nextPairSecondNode ?? nextPairFirstNode;
            currentPairSecondNode.next = currentPairFirstNode;

            currentPairFirstNode = nextPairFirstNode!;
            currentPairSecondNode = nextPairSecondNode;
        } while (currentPairSecondNode is not null);

        return head;
    }
}
