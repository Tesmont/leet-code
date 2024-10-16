namespace Helpers;

public static class ListNodeHelper
{
    public static ListNode? ConvertToListNode(ICollection<int> collection)
    {
        if (collection.Count == 0)
        {
            return null;
        }

        ListNode dummyHead = new ListNode(0);
        ListNode current = dummyHead;

        foreach (var value in collection)
        {
            current.next = new ListNode(value);
            current = current.next;
        }

        return dummyHead.next;
    }

    public static List<int> ConvertToList(ListNode? listNode)
    {
        var list = new List<int>();

        var current = listNode;
        while (current != null)
        {
            list.Add(current.val);
            current = current.next;
        }

        return list;
    }
}
