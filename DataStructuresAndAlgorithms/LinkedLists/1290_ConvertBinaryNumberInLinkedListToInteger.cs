using Helpers;

namespace DataStructuresAndAlgorithms.LinkedLists;

internal class _1290_ConvertBinaryNumberInLinkedListToInteger
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1(ListNodeHelper.ConvertToListNode([1, 0, 1])!);
            Test1(ListNodeHelper.ConvertToListNode([0])!);
            Test1(ListNodeHelper.ConvertToListNode([1])!);
            Test1(ListNodeHelper.ConvertToListNode([1, 1, 1, 1])!);
            Test1(ListNodeHelper.ConvertToListNode([0, 0, 0, 0, 0, 0])!);
        }

        private void Test1(ListNode head)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(head), ListNodeHelper.ConvertToList(head)));

            var result = new _1290_ConvertBinaryNumberInLinkedListToInteger().GetDecimalValue(head);

            printTable.AddProcessedParameters(
                (nameof(head), ListNodeHelper.ConvertToList(head)));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    public int GetDecimalValue(ListNode head)
    {
        var result = 0;

        while(head != null)
        {
            result = (result << 1) | head.val;

            head = head.next!;
        }
        
        return result;
    }
}
