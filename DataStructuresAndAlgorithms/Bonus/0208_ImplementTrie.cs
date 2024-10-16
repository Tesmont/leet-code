using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.Bonus;

internal class _0208_ImplementTrie
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var trie = new Trie();
            trie.Insert("apple");
            var searchResult = trie.Search("apple");   // returns true
            var searchResult2 = trie.Search("app");    // returns false
            var startsWithResult = trie.StartsWith("app"); // returns true
            trie.Insert("app");
            var searchResult3 = trie.Search("app");    // returns true

            Test(trie, searchResult, searchResult2, startsWithResult, searchResult3);
        }

        private void Test(Trie trie, bool searchResult, bool searchResult2, bool startsWithResult, bool searchResult3)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(trie), JsonSerializer.Serialize(trie))
            };

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(searchResult), JsonSerializer.Serialize(searchResult)),
                (nameof(searchResult2), JsonSerializer.Serialize(searchResult2)),
                (nameof(startsWithResult), JsonSerializer.Serialize(startsWithResult)),
                (nameof(searchResult3), JsonSerializer.Serialize(searchResult3))
            };

            var resultStr = JsonSerializer.Serialize((searchResult, searchResult2, startsWithResult, searchResult3));

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public class Trie
    {
        private record Node(Dictionary<char, Node> Children)
        {
            public bool IsEnd { get; set; }
        };

        private readonly Node _root;

        public Trie()
        {
            _root = new Node(new());
        }

        public void Insert(string word)
        {
            var currentNode = _root;
            foreach (var letter in word)
            {
                if (!currentNode.Children.TryGetValue(letter, out var nextNode))
                {
                    nextNode = new Node(new());
                    currentNode.Children[letter] = nextNode;
                }

                currentNode = nextNode;
            }

            currentNode.IsEnd = true;
        }

        public bool Search(string word)
        {
            var lastNode = FindLastNode(word);

            return lastNode?.IsEnd ?? false;
        }

        public bool StartsWith(string prefix)
        {
            var lastNode = FindLastNode(prefix);

            return lastNode != null;
        }

        private Node? FindLastNode(string prefix)
        {
            var currentNode = _root;
            foreach (var letter in prefix)
            {
                if (!currentNode.Children.TryGetValue(letter, out var nextNode))
                {
                    return null;
                }

                currentNode = nextNode;
            }

            return currentNode;
        }
    }
}
