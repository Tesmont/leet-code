using Helpers;

namespace BeginnersGuide;

internal class _0876_MiddleOfTheLinkedList
{
    public void Launch()
    {
        Execute(new()
        {
            val = 1,
            next = new()
            {
                val = 2,
                next = new()
                {
                    val = 3,
                    next = new()
                    {
                        val = 4,
                        next = new()
                        {
                            val = 5,
                            next = null
                        }
                    }
                }
            }
        });

        Execute(new()
        {
            val = 1,
            next = new()
            {
                val = 2,
                next = new()
                {
                    val = 3,
                    next = new()
                    {
                        val = 4,
                        next = new()
                        {
                            val = 5,
                            next = new()
                            {
                                val = 6,
                                next = null
                            }
                        }
                    }
                }
            }
        });
    }

    private void Execute(ListNode head)
    {
        var processedHead = Helper.DeepClone(head);
        var result = MiddleNode(processedHead);

        Helper.PrintTable([
            ("head", head),
            ("processedHead", processedHead),
            ("result", result),
            ]);
    }

    public record ListNode
    {
        public int val { get; set; }
        public ListNode? next { get; set; }
    }

    public ListNode MiddleNode(ListNode head)
    {
        var lenght = 1;
        var node = head;
        while (node.next != null)
        {
            node = node.next;
            lenght++;
        }

        node = head;
        for (var i = 0; i < lenght / 2; i++)
        {
            node = node!.next;
        }

        return node!;
    }

    public ListNode MiddleNodeV2(ListNode head)
    {
        ListNode mid = head;
        ListNode end = head;
        while (end != null && end.next != null)
        {
            mid = mid.next!;
            end = end.next!.next!;
        }

        return mid!;
    }
}
