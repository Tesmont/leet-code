using Helpers;
using System.IO.Pipes;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.TreesAndGraphs.DFS;

internal class _1026_MaximumDifferenceBetweenNodeAndAncestor
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var root1 = new TreeNode(8,
                new TreeNode(3, new TreeNode(1), new TreeNode(6, new TreeNode(4), new TreeNode(7))),
                new TreeNode(10, null, new TreeNode(14, new TreeNode(13))));

            Test1(root1);

            var root2 = new TreeNode(1,
                new TreeNode(2, new TreeNode(0, new TreeNode(3)), null));

            Test1(root2);

            var root3 = new TreeNode(4,
                new TreeNode(2, new TreeNode(1), new TreeNode(3)),
                new TreeNode(6, new TreeNode(5), new TreeNode(7)));

            Test1(root3);
        }

        private void Test1(TreeNode root)
        {
            List<(string Name, string? Value)> parameters =
            [
                (nameof(root), Environment.NewLine + root.ToString())
            ];

            var result = new _1026_MaximumDifferenceBetweenNodeAndAncestor().MaxAncestorDiff2(root);

            List<(string Name, string? Value)> processedParameters =
            [
                (nameof(root), Environment.NewLine + root.ToString())
            ];

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    /// <summary>
    /// DFS, stack
    /// </summary>
    public int MaxAncestorDiff(TreeNode root)
    {
        var maxDifference = int.MinValue;

        var stack = new Stack<(TreeNode Node, int MinAnsectorValue, int MaxAnsectorValue)>();
        stack.Push((root, root.val, root.val));

        while (stack.TryPop(out var nodeTuple))
        {
            var minAnsectorValue = Math.Min(nodeTuple.MinAnsectorValue, nodeTuple.Node.val);
            var maxAnsectorValue = Math.Max(nodeTuple.MaxAnsectorValue, nodeTuple.Node.val);

            if (nodeTuple.Node.right != null)
            {
                stack.Push((nodeTuple.Node.right, minAnsectorValue, maxAnsectorValue));
            }

            if (nodeTuple.Node.left != null)
            {
                stack.Push((nodeTuple.Node.left, minAnsectorValue, maxAnsectorValue));
            }

            var difference = Math.Abs(nodeTuple.Node.val - nodeTuple.MinAnsectorValue);
            maxDifference = Math.Max(maxDifference, difference);

            difference = Math.Abs(nodeTuple.Node.val - nodeTuple.MaxAnsectorValue);
            maxDifference = Math.Max(maxDifference, difference);
        }

        return maxDifference;
    }

    /// <summary>
    /// DFS, recursuion
    /// </summary>
    public int MaxAncestorDiff2(TreeNode root)
    {
        return MaxAncestorDiffRecuresion(root, root.val, root.val);
    }

    private int MaxAncestorDiffRecuresion(TreeNode? root, int minAnsectorValue, int maxAnsectorValue)
    {
        if (root == null)
        {
            return maxAnsectorValue - minAnsectorValue;
        }

        minAnsectorValue = Math.Min(minAnsectorValue, root.val);
        maxAnsectorValue = Math.Max(maxAnsectorValue, root.val);

        var leftMaxDifference = MaxAncestorDiffRecuresion(root.left, minAnsectorValue, maxAnsectorValue);
        var rightMaxDifference = MaxAncestorDiffRecuresion(root.right, minAnsectorValue, maxAnsectorValue);

        var maxDifference = Math.Max(leftMaxDifference, rightMaxDifference);

        return maxDifference;
    }
}
