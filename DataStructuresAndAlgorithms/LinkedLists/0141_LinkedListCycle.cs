using Helpers;

namespace DataStructuresAndAlgorithms.LinkedLists;

internal class _0141_LinkedListCycle
{
    internal class ListNode
    {
        public int val;
        public ListNode? next;
        public ListNode(int x) { val = x; next = null; }
    }

    internal class Tester
    {
        public void LaunchTests()
        {
            // Test cases can be added here
        }

        private void Test1(ListNode head)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(head), head));

            var result = new _0141_LinkedListCycle().HasCycle(head);

            printTable.AddProcessedParameters(
                (nameof(head), head));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    public bool HasCycle(ListNode head)
    {
        if(head == null)
        {
            return false;
        }

        var slow = head;
        var fast = head;

        while (true)
        {
            slow = slow.next!;
            fast = fast.next?.next;

            if (fast == null)
            {
                return false;
            }

            if (slow == fast)
            {
                return true;
            }
        }
    }
}
