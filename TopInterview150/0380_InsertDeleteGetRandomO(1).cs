using Helpers;

namespace TopInterview150;

internal class _0380_InsertDeleteGetRandomO_1_
{
    public void Launch()
    {
        Execute();
    }

    private void Execute()
    {
        var set = new RandomizedSet();

        Helper.PrintTable([
            ("Action", set.Insert(0)),
            ("Action", set.Insert(1)),
            ("Action", set.Remove(0)),
            ("Action", set.Insert(2)),
            ("Action", set.Remove(1)),
            ("Action", set.GetRandom()),
            ]);
    }

    public class RandomizedSet
    {
        private readonly Dictionary<int, int> _dictionary = new();
        private readonly List<int> _list = new();
        private readonly Random _random = new();


        public bool Insert(int val)
        {
            if (!_dictionary.TryAdd(val, _list.Count))
            {
                return false;
            }

            _list.Add(val);

            return true;
        }

        public bool Remove(int val)
        {
            if (!_dictionary.TryGetValue(val, out var index))
            {
                return false;
            }

            int lastElement = _list[_list.Count - 1];
            _list[index] = lastElement;
            _dictionary[lastElement] = index;

            _list.RemoveAt(_list.Count - 1);
            _dictionary.Remove(val);

            return true;
        }

        public int GetRandom()
        {
            int randomIndex = _random.Next(_list.Count);

            return _list[randomIndex];
        }
    }
}
