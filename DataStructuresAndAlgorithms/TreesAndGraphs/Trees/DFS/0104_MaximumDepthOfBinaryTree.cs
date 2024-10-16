using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.TreesAndGraphs.DFS;

internal class _0104_MaximumDepthOfBinaryTree
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1(new TreeNode(3, new TreeNode(9), new TreeNode(20, new TreeNode(15), new TreeNode(7))));
            Test1(new TreeNode(1, null, new TreeNode(2)));
            Test1(new TreeNode(1, new TreeNode(2), new TreeNode(3, new TreeNode(4), new TreeNode(5))));
        }

        private void Test1(TreeNode? root)
        {
            List<(string Name, string? Value)> parameters =
            [
                (nameof(root), Environment.NewLine + root?.ToString() ?? "NULL")
            ];

            var result = new _0104_MaximumDepthOfBinaryTree().MaxDepth(root);

            List<(string Name, string? Value)> processedParameters =
            [
                (nameof(root), Environment.NewLine + root?.ToString() ?? "NULL")
            ];

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int MaxDepth(TreeNode? root)
    {
        if (root == null)
        {
            return 0;
        }

        var stack = new Stack<(TreeNode node, int length)>();
        var maxLength = 0;

        stack.Push((root, 1));

        while (stack.TryPop(out (TreeNode node, int length) tuple))
        {
            var nodeLenght = tuple.length + 1;

            maxLength = Math.Max(maxLength, nodeLenght);

            if (tuple.node.left != null)
            {
                stack.Push((tuple.node.left, nodeLenght));
            }

            if (tuple.node.right != null)
            {
                stack.Push((tuple.node.right, nodeLenght));
            }
        }

        return maxLength;
    }

    public int MaxDepth2(TreeNode? root)
    {
        if (root == null)
        {
            return 0;
        }

        var leghtLength = MaxDepth2(root.left);
        var rightLength = MaxDepth2(root.right);

        return 1 + Math.Max(leghtLength, rightLength);
    }
}