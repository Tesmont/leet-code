using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.TreesAndGraphs.BFS;

internal class _0199_BinaryTreeRightSideView
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var root1 = new TreeNode(1,
                new TreeNode(2), new TreeNode(3));

            Test1(root1);
        }

        private void Test1(TreeNode? root)
        {
            List<(string Name, string? Value)> parameters =
            [
                (nameof(root), Environment.NewLine + root?.ToString() ?? "NULL")
            ];

            var result = new _0199_BinaryTreeRightSideView().RightSideView(root);

            List<(string Name, string? Value)> processedParameters =
            [
                (nameof(root), Environment.NewLine + root?.ToString() ?? "NULL")
            ];

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    /// <summary>
    /// BFS. Queue
    /// </summary>
    public IList<int> RightSideView(TreeNode? root)
    {
        if (root == null)
        {
            return Array.Empty<int>();
        }

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        var result = new List<int>();

        while (queue.Count > 0)
        {
            var length = queue.Count;

            TreeNode node = null!;
            for (var i = 0; i < length; i++)
            {
                node = queue.Dequeue();

                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }

            result.Add(node.val);
        }

        return result;
    }

    /// <summary>
    /// DFS. Recursion
    /// </summary>
    public IList<int> RightSideView2(TreeNode? root)
    {
        _result = new List<int>();

        RightSideViewRecursion(root, 0);

        return _result;
    }

    private List<int> _result = null!;

    private void RightSideViewRecursion(TreeNode? root, int level)
    {
        if (root == null)
        {
            return;
        }

        if (level == _result.Count)
        {
            _result.Add(root.val);
        }

        level++;
        RightSideViewRecursion(root.right, level);
        RightSideViewRecursion(root.left, level);
    }

    /// <summary>
    /// DFS. Morris
    /// </summary>
    public IList<int> RightSideView3(TreeNode? root)
    {
        var result = new List<int>();

        var currentNode = root;
        var currentLevel = 0;
        var maxLevel = int.MinValue;

        while (currentNode != null)
        {
            if (currentNode.right == null)
            {
                if (maxLevel < currentLevel)
                {
                    result.Add(currentNode.val);
                    maxLevel = currentLevel;
                }

                currentLevel++;
                currentNode = currentNode.left;

                continue;
            }

            var preNode = currentNode.right;
            var preDepth = 1;
            while (preNode.left != null && preNode.left != currentNode)
            {
                preNode = preNode.left;
                preDepth++;
            }

            if (preNode.left == null)
            {
                if (maxLevel < currentLevel) 
                { 
                    result.Add(currentNode.val);
                    maxLevel = currentLevel;
                }

                preNode.left = currentNode;
                currentLevel++;
                currentNode = currentNode.right;
            }
            else
            {
                preNode.left = null;
                currentLevel -= preDepth;
                currentNode = currentNode.left;
            }
        }

        return result;
    }
}
