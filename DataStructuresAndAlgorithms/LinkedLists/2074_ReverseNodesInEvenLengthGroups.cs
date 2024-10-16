using Helpers;
using System.Runtime.CompilerServices;

namespace DataStructuresAndAlgorithms.LinkedLists;

internal class _2074_ReverseNodesInEvenLengthGroups
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1(ListNodeHelper.ConvertToListNode([1, 2, 3])!);
            Test1(ListNodeHelper.ConvertToListNode([1, 2, 3, 4])!);
            Test1(ListNodeHelper.ConvertToListNode([1, 2, 3, 4, 5, 6, 7, 8, 9, 10])!);

            Test1(ListNodeHelper.ConvertToListNode([5, 2, 6, 3, 9, 1, 7, 3, 8, 4])!);
            Test1(ListNodeHelper.ConvertToListNode([1, 1, 0, 6])!);
        }

        private void Test1(ListNode head)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(head), ListNodeHelper.ConvertToList(head)));

            var result = new _2074_ReverseNodesInEvenLengthGroups().ReverseEvenLengthGroups(head);

            printTable.AddProcessedParameters(
                (nameof(head), ListNodeHelper.ConvertToList(head)));

            printTable.AddResult(ListNodeHelper.ConvertToList(result));
            Helper.PrintTable(printTable);
        }
    }

    public ListNode ReverseEvenLengthGroups(ListNode head)
    {
        if(head.next == null)
        {
            return head;
        }

        var groupNumber = 2;
        var predecessorNode = head;
        var firstNode = head.next;
        while (firstNode != null)
        {
            var groupLength = 1;
            var lastNode = firstNode;

            while (lastNode?.next != null
                && groupLength < groupNumber)
            {
                lastNode = lastNode.next!;
                groupLength++;
            }
            groupNumber++;

            if (groupLength % 2 != 0)
            {
                predecessorNode = lastNode!;
                firstNode = lastNode?.next;
                continue;
            }

            //reverse
            var currentNode = firstNode;
            var previousNode = lastNode?.next;
            for(var i = 0; i < groupLength; i++)
            {
                var next = currentNode!.next;

                currentNode.next = previousNode;
                previousNode = currentNode;

                currentNode = next;
            }

            predecessorNode.next = lastNode;
            predecessorNode = firstNode;
            firstNode = firstNode.next;
        }

        return head;
    }
}
