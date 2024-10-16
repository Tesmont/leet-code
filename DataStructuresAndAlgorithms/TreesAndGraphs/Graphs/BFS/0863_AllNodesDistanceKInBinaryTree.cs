using Helpers;
using System.IO.Pipes;
using System.Runtime.Serialization.Formatters;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.TreesAndGraphs.Graphs.BFS;

internal class _0863_AllNodesDistanceKInBinaryTree
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var root = TreeNodeHelper.ArrayToTreeNode([3, 5, 1, 6, 2, 0, 8, null, null, 7, 4])!;
            var target = root.left!;

            var root2 = TreeNodeHelper.ArrayToTreeNode([0, 1, null, 3, 2])!;
            var target2 = root2.left!.right!;

            var root3 = TreeNodeHelper.ArrayToTreeNode([0, 1, null, null, 2, null, 3, null, 4])!;
            var target3 = root3.left!.right!.right!;

            Test1(root, target, 2);
            Test1(root2, target2, 1);
            Test1(root3, target3, 0);
        }

        private void Test1(TreeNode root, TreeNode target, int k)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(root), Environment.NewLine + root.ToString()),
                (nameof(target), Environment.NewLine + target.ToString()),
                (nameof(k), k.ToString())
            };

            var result = new _0863_AllNodesDistanceKInBinaryTree().DistanceK(root, target, k);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(root), Environment.NewLine + root.ToString()),
                (nameof(target), Environment.NewLine + target.ToString()),
                (nameof(k), k.ToString())
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    const int _maxN = 500;

    public IList<int> DistanceK(TreeNode root, TreeNode target, int k)
    {
        if(k == 0)
        {
            return [target.val];
        }

        var parents = BuildParents(root);
        var visitedVerticies = new bool[_maxN];
        
        var queue = new Queue<TreeNode>();
        queue.Enqueue(target);
        visitedVerticies[target.val] = true;

        for(var i = 0; i < k; i++)
        {
            if(queue.Count == 0)
            {
                return Array.Empty<int>();
            }

            var length = queue.Count;
            for(var j = 0; j < length; j++)
            {
                var vertex = queue.Dequeue();

                var parent = parents[vertex.val];
                if (parent != null
                    && !visitedVerticies[parent.val])
                {
                    queue.Enqueue(parent);
                    visitedVerticies[parent.val] = true;
                }

                if (vertex.left != null
                    && !visitedVerticies[vertex.left.val])
                {
                    queue.Enqueue(vertex.left);
                    visitedVerticies[vertex.left.val] = true;
                }

                if (vertex.right != null
                    && !visitedVerticies[vertex.right.val])
                {
                    queue.Enqueue(vertex.right);
                    visitedVerticies[vertex.right.val] = true;
                }
            }
        }

        var result = queue
            .Select(i => i.val)
            .ToList();

        return result;
    }

    private TreeNode?[] BuildParents(TreeNode root)
    {
        var parents = new TreeNode?[_maxN];
        var previousVertex = root;

        var stack = new Stack<(TreeNode parentVertex, TreeNode? childVertex)>();
        stack.Push((root, root.left));
        stack.Push((root, root.right));

        while (stack.TryPop(out var family))
        {
            if(family.childVertex == null)
            {
                continue;
            }

            parents[family.childVertex.val] = family.parentVertex;
            stack.Push((family.childVertex, family.childVertex.left));
            stack.Push((family.childVertex, family.childVertex.right));
        }

        return parents;
    }
}
