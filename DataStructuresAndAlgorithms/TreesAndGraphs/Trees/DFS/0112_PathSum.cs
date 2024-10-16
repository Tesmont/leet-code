using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.TreesAndGraphs.DFS;

internal class _0112_PathSum
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1(new TreeNode(1, new TreeNode(2), null), 1);

            Test1(new TreeNode(5, new TreeNode(4, new TreeNode(11, new TreeNode(7), new TreeNode(2))),
                new TreeNode(8, new TreeNode(13), new TreeNode(4, null, new TreeNode(1)))), 22);
            Test1(new TreeNode(1, new TreeNode(2), new TreeNode(3)), 5);
            Test1(null, 0);
        }

        private void Test1(TreeNode? root, int targetSum)
        {
            List<(string Name, string? Value)> parameters =
            [
                (nameof(root), Environment.NewLine + root?.ToString() ?? "NULL"),
                (nameof(targetSum), targetSum.ToString())
            ];

            var result = new _0112_PathSum().HasPathSum(root, targetSum);

            List<(string Name, string? Value)> processedParameters =
            [
                (nameof(root), Environment.NewLine + root?.ToString() ?? "NULL"),
                (nameof(targetSum), targetSum.ToString())
            ];

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public bool HasPathSum(TreeNode? root, int targetSum)
    {
        if (root == null)
        {
            return false;
        }

        var stack = new Stack<(TreeNode node, int sum)>();

        stack.Push((root, 0));

        while (stack.TryPop(out var tuple))
        {
            var sum = tuple.node.val + tuple.sum;

            if (tuple.node.left != null)
            {
                stack.Push((tuple.node.left, sum));

                if (tuple.node.right != null)
                {
                    stack.Push((tuple.node.right, sum));
                }

                continue;
            }
            else if (tuple.node.right != null)
            {
                stack.Push((tuple.node.right, sum));

                continue;
            }

            if (targetSum == sum)
            {
                return true;
            }
        }

        return false;
    }
}
