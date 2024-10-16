using Helpers;

namespace DataStructuresAndAlgorithms.LinkedLists;

internal class _0707_DesignLinkedList
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var linkedList = new MyLinkedList();

            linkedList.AddAtHead(7);
            linkedList.AddAtHead(2);
            linkedList.AddAtHead(1);
            linkedList.AddAtIndex(3, 0);
            linkedList.DeleteAtIndex(2);
            linkedList.AddAtHead(6);
            linkedList.AddAtTail(4);

            var val1 = linkedList.Get(4);
            linkedList.AddAtHead(4);
            linkedList.AddAtIndex(5, 0);
            linkedList.AddAtHead(6);
        }
    }

    public class MyLinkedList
    {
        public List<int> ToList()
        {
            var list = new List<int>();

            var currentNode = _sentinelHead.Next!;
            for (var i = 0; i < _lenght; i++)
            {
                list.Add(currentNode.Value);
                currentNode = currentNode.Next!;
            }

            return list;
        }

        private record Node(int Value, Node? Previous, Node? Next)
        {
            public int Value { get; set; } = Value;
            public Node? Previous { get; set; } = Previous;
            public Node? Next { get; set; } = Next;
        }

        private Node _sentinelHead;
        private Node _sentinelTail;
        private int _lenght;

        public MyLinkedList()
        {
            _sentinelTail = new Node(0, null, null);
            _sentinelHead = new Node(0, null, _sentinelTail);
            _sentinelTail.Previous = _sentinelHead;
            _lenght = 0;
        }

        public int Get(int index)
        {
            if (index >= _lenght)
            {
                return -1;
            }

            Node currentNode;

            if (index < _lenght / 2)
            {
                currentNode = _sentinelHead.Next!;
                for (var i = 0; i < index; i++)
                {
                    currentNode = currentNode.Next!;
                }

            }
            else
            {
                currentNode = _sentinelTail.Previous!;
                for (var i = 0; i < _lenght - index - 1; i++)
                {
                    currentNode = currentNode.Previous!;
                }
            }

            return currentNode.Value;
        }

        public void AddAtHead(int val)
        {
            var newNode = new Node(val, _sentinelHead, _sentinelHead.Next);

            _sentinelHead.Next!.Previous = newNode;
            _sentinelHead.Next = newNode;
            _lenght++;
        }

        public void AddAtTail(int val)
        {
            var newNode = new Node(val, _sentinelTail.Previous, _sentinelTail);

            _sentinelTail.Previous!.Next = newNode;
            _sentinelTail.Previous = newNode;
            _lenght++;
        }

        public void AddAtIndex(int index, int val)
        {
            if (index > _lenght)
            {
                return;
            }

            if(index == 0)
            {
                AddAtHead(val);
                return;
            }

            if(index == _lenght)
            {
                AddAtTail(val);
                return;
            }

            Node currentNode;

            if (index < _lenght / 2)
            {
                currentNode = _sentinelHead.Next!;
                for (var i = 0; i < index; i++)
                {
                    currentNode = currentNode.Next!;
                }

            }
            else
            {
                currentNode = _sentinelTail.Previous!;
                for (var i = 0; i < _lenght - index - 1; i++)
                {
                    currentNode = currentNode.Previous!;
                }
            }

            var newNode = new Node(val, currentNode.Previous, currentNode);

            currentNode.Previous!.Next = newNode;
            currentNode.Previous = newNode;
            _lenght++;
        }

        public void DeleteAtIndex(int index)
        {
            if (index >= _lenght)
            {
                return;
            }

            Node currentNode;

            if (index < _lenght / 2)
            {
                currentNode = _sentinelHead.Next!;
                for (var i = 0; i < index; i++)
                {
                    currentNode = currentNode.Next!;
                }

            }
            else
            {
                currentNode = _sentinelTail.Previous!;
                for (var i = 0; i < _lenght - index - 1; i++)
                {
                    currentNode = currentNode.Previous!;
                }
            }

            currentNode.Previous!.Next = currentNode.Next;
            currentNode.Next!.Previous = currentNode.Previous;
            _lenght--;
        }
    }
}
