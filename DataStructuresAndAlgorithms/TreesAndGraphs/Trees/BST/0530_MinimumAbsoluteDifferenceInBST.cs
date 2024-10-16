using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.TreesAndGraphs.BST;

internal class _0530_MinimumAbsoluteDifferenceInBST
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var root1 = new TreeNode(1,
                new TreeNode(2), new TreeNode(3));

            var root2 = new TreeNode(4,
                new TreeNode(2,
                    new TreeNode(1),
                    new TreeNode(3)
                ),
                new TreeNode(6)
            );

            Test1(root1);
            Test1(root2);
        }

        private void Test1(TreeNode root)
        {
            List<(string Name, string? Value)> parameters =
            [
                (nameof(root), Environment.NewLine + root.ToString())
            ];

            var result = new _0530_MinimumAbsoluteDifferenceInBST().GetMinimumDifference2(root);

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
    public int GetMinimumDifference(TreeNode root)
    {
        var values = new List<int>();
        FillListRecursion(root, values);

        var minDifference = int.MaxValue;
        for (int i = 1; i < values.Count; i++)
        {
            var difference = values[i] - values[i - 1];
            minDifference = Math.Min(minDifference, difference);
        }

        return minDifference;
    }

    private void FillListRecursion(TreeNode? node, List<int> values)
    {
        if (node == null)
        {
            return;
        }

        FillListRecursion(node.left, values);

        values.Add(node.val);

        FillListRecursion(node.right, values);
    }

    /// <summary>
    /// DFS. Recursion. In-place
    /// </summary>
    public int GetMinimumDifference2(TreeNode? root)
    {
        if (root == null)
        {
            return 0;
        }

        _minDifference = int.MaxValue;
        _prevNode = null;

        GetMinimumDifference2Recursion(root);

        return _minDifference;
    }

    private void GetMinimumDifference2Recursion(TreeNode? root)
    {
        if (root == null)
        {
            return;
        }

        GetMinimumDifference2Recursion(root.left);

        if (_prevNode != null)
        {
            _minDifference = Math.Min(_minDifference, root.val - _prevNode.val);
        }

        _prevNode = root;

        GetMinimumDifference2Recursion(root.right);
    }

    private int _minDifference;
    private TreeNode? _prevNode;

    /// <summary>
    /// DFS. Stack. List
    /// </summary>
    public int GetMinimumDifference3(TreeNode? root)
    {
        var values = ToList(root);

        var minDifference = int.MaxValue;
        for (int i = 1; i < values.Count; i++)
        {
            var difference = values[i] - values[i - 1];
            minDifference = Math.Min(minDifference, difference);
        }

        return minDifference;
    }

    private List<int> ToList(TreeNode? root)
    {
        if (root == null)
        {
            return new List<int>();
        }

        var values = new List<int>();
        var stack = new Stack<TreeNode>();
        var currentNode = root;

        while (stack.Count > 0
            || currentNode != null)
        {
            while (currentNode != null)
            {
                stack.Push(currentNode);
                currentNode = currentNode.left;
            }

            currentNode = stack.Pop();
            values.Add(currentNode.val);

            currentNode = currentNode.right;
        }

        return values;
    }

    /// <summary>
    /// DFS. Stack.
    /// </summary>
    public int GetMinimumDifference4(TreeNode? root)
    {
        if (root == null)
        {
            return 0;
        }

        var minDifference = int.MaxValue;
        TreeNode? prevNode = null;

        var stack = new Stack<TreeNode>();
        var currentNode = root;

        while (stack.Count > 0
            || currentNode != null)
        {
            while (currentNode != null)
            {
                stack.Push(currentNode);
                currentNode = currentNode.left;
            }

            currentNode = stack.Pop();

            if (prevNode != null)
            {
                minDifference = Math.Min(minDifference, currentNode.val - prevNode.val);
            }

            prevNode = currentNode;

            currentNode = currentNode.right;
        }

        return minDifference;
    }
}
