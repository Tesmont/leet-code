using Helpers;

namespace DataStructuresAndAlgorithms.LinkedLists;

internal class _0328_OddEvenLinkedList
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1(ListNodeHelper.ConvertToListNode([1, 2, 3, 4, 5])!);
            Test1(ListNodeHelper.ConvertToListNode([2, 1, 3, 5, 6, 4, 7])!);
        }

        private void Test1(ListNode head)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(head), ListNodeHelper.ConvertToList(head)));

            var result = new _0328_OddEvenLinkedList().OddEvenListV2(head);

            printTable.AddProcessedParameters(
                (nameof(head), ListNodeHelper.ConvertToList(head)));

            printTable.AddResult(ListNodeHelper.ConvertToList(result));
            Helper.PrintTable(printTable);
        }
    }

    public ListNode? OddEvenList(ListNode? head)
    {
        if(head?.next == null)
        {
            return head;
        }

        var currentOddNode = head;
        var currentEvenNode = head.next;
        var firstEvenNode = currentEvenNode;
        var currentNode = currentEvenNode.next;

        while(currentNode != null)
        {
            currentOddNode.next = currentNode;
            currentOddNode = currentNode;

            currentEvenNode!.next = currentNode.next;
            currentEvenNode = currentNode.next;
            
            currentNode = currentEvenNode?.next;
        }

        currentOddNode.next = firstEvenNode;

        return head;
    }

    public ListNode? OddEvenListV2(ListNode? head)
    {
        if (head?.next == null)
        {
            return head;
        }

        var currentOddNode = head;
        var currentEvenNode = head.next;
        var firstEvenNode = currentEvenNode;
        var currentNode = currentEvenNode.next;
        var index = 3;

        while (currentNode != null)
        {
            if(index % 2 == 0)
            {
                currentEvenNode.next = currentNode;
                currentEvenNode = currentNode;
            }
            else
            {
                currentOddNode.next = currentNode;
                currentOddNode = currentNode;
            }

            currentNode = currentNode.next;
            index++;
        }

        currentOddNode.next = firstEvenNode;
        currentEvenNode.next = null;

        return head;
    }
}
