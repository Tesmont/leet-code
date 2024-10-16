using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.TreesAndGraphs.DFS;

internal class _1448_CountGoodNodesInBinaryTree
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1(new TreeNode(3, new TreeNode(1, new TreeNode(3)),
                new TreeNode(4, new TreeNode(1), new TreeNode(5))));
            Test1(new TreeNode(3, new TreeNode(3, new TreeNode(4), new TreeNode(2))));
            Test1(new TreeNode(1));
        }

        private void Test1(TreeNode? root)
        {
            List<(string Name, string? Value)> parameters =
            [
                (nameof(root), Environment.NewLine + root?.ToString() ?? "NULL")
            ];

            var result = new _1448_CountGoodNodesInBinaryTree().GoodNodes(root);

            List<(string Name, string? Value)> processedParameters =
            [
                (nameof(root), Environment.NewLine + root?.ToString() ?? "NULL")
            ];

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int GoodNodes(TreeNode? root)
    {
        if (root == null)
        {
            return 0;
        }

        var stack = new Stack<(TreeNode node, int maxValue)>();
        var goodNodeCount = 0;
        stack.Push((root, int.MinValue));

        while (stack.TryPop(out var tuple))
        {
            if (tuple.node.val >= tuple.maxValue)
            {
                goodNodeCount++;
            }

            var maxValue = Math.Max(tuple.maxValue, tuple.node.val);

            if (tuple.node.left != null)
            {
                stack.Push((tuple.node.left, maxValue));
            }

            if (tuple.node.right != null)
            {
                stack.Push((tuple.node.right, maxValue));
            }
        }

        return goodNodeCount;
    }
}
