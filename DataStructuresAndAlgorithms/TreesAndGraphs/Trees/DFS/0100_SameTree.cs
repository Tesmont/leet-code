using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.TreesAndGraphs.DFS;

internal class _0100_SameTree
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1(new TreeNode(1, new TreeNode(2), new TreeNode(3)),
                  new TreeNode(1, new TreeNode(2), new TreeNode(3)));
            Test1(new TreeNode(1, new TreeNode(2)),
                  new TreeNode(1, null, new TreeNode(2)));
            Test1(new TreeNode(1, new TreeNode(2), new TreeNode(1)),
                  new TreeNode(1, new TreeNode(1), new TreeNode(2)));
        }

        private void Test1(TreeNode p, TreeNode q)
        {
            List<(string Name, string? Value)> parameters =
            [
                (nameof(p), Environment.NewLine + p?.ToString() ?? "NULL"),
                (nameof(q), Environment.NewLine + q?.ToString() ?? "NULL")
            ];

            var result = new _0100_SameTree().IsSameTree(p, q);

            List<(string Name, string? Value)> processedParameters =
            [
                (nameof(p), Environment.NewLine + p?.ToString() ?? "NULL"),
                (nameof(q), Environment.NewLine + q?.ToString() ?? "NULL")
            ];

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public bool IsSameTree(TreeNode? p, TreeNode? q)
    {
        var stack = new Stack<(TreeNode? pNode, TreeNode? qNode)>();

        stack.Push((p, q));

        while (stack.Count > 0)
        {
            var (pNode, qNode) = stack.Pop();

            if (pNode == null && qNode == null)
            {
                continue;
            }

            if (pNode == null
                || qNode == null
                || pNode.val != qNode.val)
            {
                return false;
            }

            stack.Push((pNode.left, qNode.left));
            stack.Push((pNode.right, qNode.right));
        }

        return true;
    }
}
