using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.TreesAndGraphs.DFS;

internal class _0111_MinimumDepthOfBinaryTree
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var root1 = new TreeNode(3,
                new TreeNode(9),
                new TreeNode(20, new TreeNode(15), new TreeNode(7)));

            Test1(root1);

            var root2 = new TreeNode(2,
                null, new TreeNode(3, null, new TreeNode(4, null, new TreeNode(5, null, new TreeNode(6)))));

            Test1(root2);

            var root3 = new TreeNode(1);

            Test1(root3);
        }

        private void Test1(TreeNode? root)
        {
            List<(string Name, string? Value)> parameters =
            [
                (nameof(root), Environment.NewLine + (root?.ToString() ?? "NULL"))
            ];

            var result = new _0111_MinimumDepthOfBinaryTree().MinDepth(root);

            List<(string Name, string? Value)> processedParameters =
            [
                (nameof(root), Environment.NewLine + (root?.ToString() ?? "NULL"))
            ];

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    /// <summary>
    /// DFS, stack
    /// </summary>
    public int MinDepth(TreeNode? root)
    {
        if (root == null)
        {
            return 0;
        }

        var stack = new Stack<(TreeNode Node, int Depth)>();
        stack.Push((root, 0));

        var minDepth = int.MaxValue;

        while (stack.TryPop(out var nodeTuple))
        {
            var depth = nodeTuple.Depth + 1;

            if (nodeTuple.Node.left != null)
            {
                if (nodeTuple.Node.right != null)
                {
                    stack.Push((nodeTuple.Node.right, depth));
                }

                stack.Push((nodeTuple.Node.left, depth));

                continue;
            }

            if (nodeTuple.Node.right != null)
            {
                stack.Push((nodeTuple.Node.right, depth));

                continue;
            }

            minDepth = Math.Min(minDepth, depth);
        }

        return minDepth;
    }
}

