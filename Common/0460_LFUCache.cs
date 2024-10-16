using Helpers;

namespace Common;

internal class _0460_LFUCache
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1();
            Test2();
        }

        private void Test1()
        {
            var cache = new LFUCache(2);

            cache.Put(1, 1);
            cache.Put(2, 2);
            var val1 = cache.Get(1);     // returns 1
            cache.Put(3, 3);             // evicts key 2
            var val2 = cache.Get(2);     // returns -1 (not found)
            var val3 = cache.Get(3);     // returns 3
            cache.Put(4, 4);             // evicts key 1
            var val4 = cache.Get(1);     // returns -1 (not found)
            var val5 = cache.Get(3);     // returns 3
            var val6 = cache.Get(4);     // returns 4

            // Print test results
            var printTable = Helper.CreatePrintTable(
                ("Operations", "Results"),
                ("Put(1, 1), Put(2, 2), Get(1), Put(3, 3), Get(2), Get(3), Put(4, 4), Get(1), Get(3), Get(4)",
                 $"{val1}, {val2}, {val3}, {val4}, {val5}, {val6}")
            );
            Helper.PrintTable(printTable);
        }

        private void Test2()
        {
            var cache = new LFUCache(2);

            cache.Put(3, 1);
            cache.Put(2, 1);
            cache.Put(2, 2);
            cache.Put(4, 4);
            var val1 = cache.Get(2); 

            // Print test results
            var printTable = Helper.CreatePrintTable(
                ("Operations", "Results"),
                ("Put(3, 1), Put(2, 1), Put(2, 2), Put(4, 4), Get(2)", $"{val1}")
            );
            Helper.PrintTable(printTable);
        }
    }

    public class LFUCache
    {
        private record struct Tuple(int Key, int Value, int Frequency)
        {
            public required int Key { get; set; } = Key;
            public required int Value { get; set; } = Value;
            public required int Frequency { get; set; } = Frequency;
        }

        private readonly int _capacity;
        private readonly Dictionary<int, LinkedListNode<Tuple>> _keyMap;
        private readonly Dictionary<int, LinkedList<Tuple>> _frequencyMap;

        private int _minFrequency;

        public LFUCache(int capacity)
        {
            _capacity = capacity;

            _keyMap = new(capacity);
            _frequencyMap = new(capacity);

            _minFrequency = 0;
        }

        public int Get(int key)
        {
            if(!_keyMap.TryGetValue(key, out var node))
            {
                return -1;
            }
            
            IncreaseFrequency(node);
            return node.ValueRef.Value;
        }

        public void Put(int key, int value)
        {
            if (_keyMap.TryGetValue(key, out var node))
            {
                //Replace node value
                node.ValueRef.Value = value;
                IncreaseFrequency(node);

                return;
            }

            if(_keyMap.Count == _capacity)
            {
                //Remove 
                var lfuList = _frequencyMap[_minFrequency];
                node = lfuList.Last!;
                lfuList.RemoveLast();
                _keyMap.Remove(node.ValueRef.Key);
                if (lfuList.Count == 0)
                {
                    _frequencyMap.Remove(_minFrequency);
                }
            }

            {
                //Add new node;
                _minFrequency = 1;
                if(!_frequencyMap.TryGetValue(_minFrequency, out var lfuList))
                {
                    lfuList = new LinkedList<Tuple>();
                    _frequencyMap[_minFrequency] = lfuList;
                }

                var tuple = new Tuple() { Key = key, Value = value, Frequency = _minFrequency };
                node = lfuList.AddFirst(tuple);
                _keyMap.Add(key, node);
            }
        }

        private void IncreaseFrequency(LinkedListNode<Tuple> node)
        {
            var frequency = node.ValueRef.Frequency + 1;

            var lfuList = node.List!;
            lfuList.Remove(node);
            if(lfuList.Count == 0
                && node.ValueRef.Frequency == _minFrequency) 
            {
                _minFrequency = frequency;
            }

            node.ValueRef.Frequency = frequency;
            if (!_frequencyMap.TryGetValue(frequency, out lfuList))
            {
                lfuList = new LinkedList<Tuple>();
                _frequencyMap[frequency] = lfuList;
            }
            lfuList.AddFirst(node);
        }
    }
}
