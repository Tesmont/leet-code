using Helpers;

namespace DataStructuresAndAlgorithms.LinkedLists;

internal class _0234_PalindromeLinkedList
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1(ListNodeHelper.ConvertToListNode([1, 2])!);
            Test1(ListNodeHelper.ConvertToListNode([1, 2, 3])!);
            Test1(ListNodeHelper.ConvertToListNode([1, 2, 3, 4])!);
            Test1(ListNodeHelper.ConvertToListNode([1, 2, 3, 4, 5])!);
            Test1(ListNodeHelper.ConvertToListNode([1, 2, 3, 4, 5, 6])!);
            Test1(ListNodeHelper.ConvertToListNode([1, 2, 3, 4, 5, 6, 7])!);


            Test1(ListNodeHelper.ConvertToListNode([1, 2, 2, 1])!);
            Test1(ListNodeHelper.ConvertToListNode([1, 2, 3, 2, 1])!);
            Test1(ListNodeHelper.ConvertToListNode([1, 2, 3, 3, 2, 1])!);
            Test1(ListNodeHelper.ConvertToListNode([1, 2, 3, 3, 2, 1])!);
            Test1(ListNodeHelper.ConvertToListNode([1])!);
            Test1(ListNodeHelper.ConvertToListNode([1, 2])!);
        }

        private void Test1(ListNode head)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(head), ListNodeHelper.ConvertToList(head)));

            var result = new _0234_PalindromeLinkedList().IsPalindrome(head);

            printTable.AddProcessedParameters(
                (nameof(head), ListNodeHelper.ConvertToList(head)));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    public bool IsPalindrome(ListNode head)
    {
        var middleNode = FindMiddleNode(head);
        var endNode = Revert(middleNode);

        while(endNode is not null) 
        {
            if(head.val != endNode.val)
            {
                return false;
            }

            head = head.next!;
            endNode = endNode.next!;
        }

        return true;
    }

    private ListNode FindMiddleNode(ListNode head)
    {
        var fast = head;
        while (fast is not null)
        {
            head = head.next!;
            fast = fast.next?.next;
        }

        return head;
    }

    private ListNode Revert(ListNode head)
    {
        ListNode? previousNode = null;
        while(head is not null)
        {
            var next = head.next!;
            head.next = previousNode;
            previousNode = head;
            head = next;
        }

        return previousNode!;
    }
}
