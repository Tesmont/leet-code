using Helpers;

namespace Common;

internal class _0146_LRUCache
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1();
            Test2();
            Test3();
            Test4();
        }

        public void Test1()
        {
            var cache = new LRUCache2(2);

            cache.Put(1, 1);
            cache.Put(2, 2);
            var val1 = cache.Get(1);     // returns 1
            cache.Put(3, 3);             // evicts key 2
            var val2 = cache.Get(2);     // returns -1 (not found)
            cache.Put(4, 4);             // evicts key 1
            var val3 = cache.Get(1);     // returns -1 (not found)
            var val4 = cache.Get(3);     // returns 3
            var val5 = cache.Get(4);     // returns 4

            var printTable = Helper.CreatePrintTable(
                (nameof(val1), val1),
                (nameof(val2), val2),
                (nameof(val3), val3),
                (nameof(val4), val4),
                (nameof(val5), val5)
            );
            Helper.PrintTable(printTable);
        }

        public void Test2()
        {
            var cache = new LRUCache(2);

            cache.Put(1, 1);
            cache.Put(2, 2);
            cache.Put(3, 3);
            var val1 = cache.Get(1);
            var val2 = cache.Get(2);
            var val3 = cache.Get(3);

            // Print test results
            var printTable = Helper.CreatePrintTable(
                (nameof(val1), val1),
                (nameof(val2), val2),
                (nameof(val3), val3)
            );
            Helper.PrintTable(printTable);
        }

        public void Test3()
        {
            var cache = new LRUCache(2);

            cache.Put(1, 1);
            cache.Put(2, 2);
            cache.Put(3, 3);
            cache.Put(1, 1);
            var val1 = cache.Get(1);
            var val2 = cache.Get(2);
            var val3 = cache.Get(3);

            // Print test results
            var printTable = Helper.CreatePrintTable(
                (nameof(val1), val1),
                (nameof(val2), val2),
                (nameof(val3), val3)
            );
            Helper.PrintTable(printTable);
        }

        public void Test4()
        {
            var cache = new LRUCache(2);

            cache.Put(1, 1);
            cache.Put(2, 2);
            cache.Put(2, 3);
            var val1 = cache.Get(1);
            var val2 = cache.Get(2);
            var val3 = cache.Get(3);

            // Print test results
            var printTable = Helper.CreatePrintTable(
                (nameof(val1), val1),
                (nameof(val2), val2),
                (nameof(val3), val3)
            );
            Helper.PrintTable(printTable);
        }
    }

    public class LRUCache
    {
        private readonly int _capacity;
        private readonly Dictionary<int, LinkedListNode<(int Key, int Value)>> _cache;
        private readonly LinkedList<(int Key, int Value)> _lruList;

        public LRUCache(int capacity)
        {
            _capacity = capacity;

            _cache = new Dictionary<int, LinkedListNode<(int Key, int Value)>>(capacity);
            _lruList = new LinkedList<(int Key, int Value)>();
        }

        public int Get(int key)
        {
            if (!_cache.TryGetValue(key, out var node))
            {

                return -1;
            }

            _lruList.Remove(node);
            _lruList.AddFirst(node);

            return node.ValueRef.Value;
        }

        public void Put(int key, int value)
        {
            if(_cache.TryGetValue(key, out var node))
            {
                //Replace node value
                node.ValueRef = (key, value);
                _lruList.Remove(node);
                _lruList.AddFirst(node);

                return;
            }

            if (_cache.Count == _capacity)
            {
                //Replace least recently used node.
                node = _lruList.Last!;

                _cache.Remove(node.ValueRef.Key);
                _lruList.RemoveLast();

                node.ValueRef = (key, value);
                _cache.Add(key, node);
                _lruList.AddFirst(node);

                return;
            }

            {                 
                //Add new node;
                node = _lruList.AddFirst((key, value));
                _cache.Add(key, node);
            }
        }
    }

    public class LRUCache2
    {
        private record Node(int Key, int Value, Node? NextNode, Node? PreviousNode)
        {
            public int Key = Key;
            public int Value = Value;
            public Node? NextNode = NextNode;
            public Node? PreviousNode = PreviousNode;
        }

        private readonly int _capacity;
        private readonly Dictionary<int, Node> _cache;
        private readonly Node _sentinelHeadNode;
        private readonly Node _sentinelTailNode;

        public LRUCache2(int capacity)
        {
            _capacity = capacity;

            _cache = new Dictionary<int, Node>(capacity);

            _sentinelHeadNode = new Node(int.MinValue, -1, null, null);
            _sentinelTailNode = new Node(int.MaxValue, -1, null, _sentinelHeadNode);
            _sentinelHeadNode.NextNode = _sentinelTailNode;
        }

        public int Get(int key)
        {
            if (!_cache.TryGetValue(key, out var node))
            {
                return -1;
            }

            RemoveNode(node);
            AddFirst(node);

            return node.Value;
        }

        public void Put(int key, int value)
        {
            if (_cache.TryGetValue(key, out var node))
            {
                //Replace node value
                node.Value = value;
                RemoveNode(node);
                AddFirst(node);

                return;
            }

            if (_cache.Count == _capacity)
            {
                //Replace least recently used node.
                node = _sentinelTailNode.PreviousNode!;

                _cache.Remove(node.Key);
                RemoveNode(node);

                node.Key = key;
                node.Value = value;
                _cache.Add(key, node);
                AddFirst(node);

                return;
            }

            {
                //Add new node;
                node = new Node(key, value, null, null);
                AddFirst(node);
                _cache.Add(key, node);
            }
        }

        private void RemoveNode(Node node)
        {
            node.PreviousNode!.NextNode = node.NextNode;
            node.NextNode!.PreviousNode = node.PreviousNode;
        }

        private void AddFirst(Node node)
        {
            node.PreviousNode = _sentinelHeadNode;
            node.NextNode = _sentinelHeadNode.NextNode;

            _sentinelHeadNode.NextNode!.PreviousNode = node;
            _sentinelHeadNode.NextNode = node;
        }
    }
}
