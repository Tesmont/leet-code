using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.TreesAndGraphs.BST;

internal class _0098_ValidateBinarySearchTree
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var root1 = new TreeNode(1,
                new TreeNode(2), new TreeNode(3));

            Test1(root1);
        }

        private void Test1(TreeNode root)
        {
            List<(string Name, string? Value)> parameters =
            [
                (nameof(root), Environment.NewLine + root.ToString())
            ];

            var result = new _0098_ValidateBinarySearchTree().IsValidBST(root);

            List<(string Name, string? Value)> processedParameters =
            [
                (nameof(root), Environment.NewLine + root.ToString())
            ];

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    /// <summary>
    /// DFS. Recursion
    /// </summary>
    public bool IsValidBST(TreeNode root)
    {
        return IsValidBST(root, long.MinValue, long.MaxValue);
    }

    private bool IsValidBST(TreeNode? root, long minValue, long maxValue)
    {
        if (root == null)
        {
            return true;
        }

        if (root.val <= minValue
            || root.val >= maxValue
            || !IsValidBST(root.left, minValue, root.val)
            || !IsValidBST(root.right, root.val, maxValue))
        {
            return false;
        }

        return true;
    }

    /// <summary>
    /// DFS. Iteration.
    /// </summary>
    public bool IsValidBST2(TreeNode root)
    {
        var stack = new Stack<(TreeNode node, long minValue, long maxValue)>();
        stack.Push((root, long.MinValue, long.MaxValue));

        while(stack.TryPop(out var nodeTuple))
        {
            if(nodeTuple.node.val <= nodeTuple.minValue
                || nodeTuple.node.val >= nodeTuple.maxValue)
            {
                return false;
            }

            if(nodeTuple.node.left != null)
            {
                var leftNodeTuple = nodeTuple with 
                { 
                    node = nodeTuple.node.left,
                    maxValue = nodeTuple.node.val
                };
                stack.Push(leftNodeTuple);
            }

            if (nodeTuple.node.right != null)
            {
                var rightNodeTuple = nodeTuple with
                {
                    node = nodeTuple.node.right,
                    minValue = nodeTuple.node.val
                };
                stack.Push(rightNodeTuple);
            }
        }

        return true;
    }
}
