using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.Bonus;

internal class _1268_SearchSuggestionsSystem
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var products = new string[] { "mobile", "mouse", "moneypot", "monitor", "mousepad" };
            var searchWord = "mouse";
            Test(products, searchWord);
            Test(["havana"], "tatiana");
        }

        private void Test(string[] products, string searchWord)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(products), JsonSerializer.Serialize(products)),
                (nameof(searchWord), JsonSerializer.Serialize(searchWord))
            };

            var result = new _1268_SearchSuggestionsSystem().SuggestedProducts(products, searchWord);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(products), JsonSerializer.Serialize(products)),
                (nameof(searchWord), JsonSerializer.Serialize(searchWord))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    private record Node(IList<string> Products, Dictionary<char, Node> Children);

    public IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
    {
        if(products.Length > 3)
        {
            Array.Sort(products);
        }

        var trie = BuildTrie();

        var result = new List<IList<string>>();
        var currentNode = trie;
        foreach (var letter in searchWord)
        {
            if(!currentNode.Children.TryGetValue(letter, out var nextNode))
            {
                if(result.Count < searchWord.Length)
                {
                    var emptyArrays = Enumerable.Repeat(Array.Empty<string>(), searchWord.Length - result.Count);
                    result.AddRange(emptyArrays);
                }

                break;
            }

            currentNode = nextNode;
            var suggestedProducts = currentNode.Products.Count > 3
                ? currentNode.Products.Take(3).ToList()
                : currentNode.Products;
            result.Add(suggestedProducts);
        }

        return result;

        Node BuildTrie()
        {
            var root = new Node(products, new());
            foreach (var product in products)
            {
                var currentNode = root;
                foreach (var letter in product)
                {
                    if (!currentNode.Children.TryGetValue(letter, out var nextNode))
                    {
                        nextNode = new Node(new List<string>(), new());
                        currentNode.Children[letter] = nextNode;
                    }

                    currentNode = nextNode;
                    currentNode.Products.Add(product);
                }
            }

            return root;
        }
    }
}
