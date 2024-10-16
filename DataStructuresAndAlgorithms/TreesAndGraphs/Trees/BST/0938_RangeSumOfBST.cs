using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.TreesAndGraphs.BST;

internal class _0938_RangeSumOfBST
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var root1 = new TreeNode(1,
                new TreeNode(2), new TreeNode(3));

            var root2 = new TreeNode(10,
                new TreeNode(5,
                    new TreeNode(3),
                    new TreeNode(7)
                ),
                new TreeNode(15,
                    null,
                    new TreeNode(18)
                )
            );

            Test1(root1, 1, 3);
            Test1(root2, 7, 15);
        }

        private void Test1(TreeNode? root, int low, int high)
        {
            List<(string Name, string? Value)> parameters =
            [
                (nameof(root), Environment.NewLine + root?.ToString() ?? "NULL"),
                (nameof(low), low.ToString()),
                (nameof(high), high.ToString())
            ];

            var result = new _0938_RangeSumOfBST().RangeSumBST2(root, low, high);

            List<(string Name, string? Value)> processedParameters =
            [
                (nameof(root), Environment.NewLine + root?.ToString() ?? "NULL"),
                (nameof(low), low.ToString()),
                (nameof(high), high.ToString())
            ];

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    /// <summary>
    /// DFS. Recursion
    /// </summary>
    public int RangeSumBST(TreeNode? root, int low, int high)
    {
        if (root == null)
        {
            return 0;
        }

        var sum = RangeSumBST(root.left, low, high);
        sum += RangeSumBST(root.right, low, high);

        if (root.val >= low && root.val <= high)
        {
            sum += root.val;
        }

        return sum;
    }

    /// <summary>
    /// DFS. Iteration
    /// </summary>
    public int RangeSumBST2(TreeNode? root, int low, int high)
    {
        if (root == null)
        {
            return 0;
        }

        var stack = new Stack<TreeNode>();
        stack.Push(root);

        var sum = 0;

        while (stack.TryPop(out var node))
        {
            if (node.val >= low && node.val <= high)
            {
                sum += node.val;
            }

            if (node.left != null)
            {
                stack.Push(node.left);
            }

            if (node.right != null)
            {
                stack.Push(node.right);
            }
        }

        return sum;
    }

    /// <summary>
    /// BFS.
    /// </summary>
    public int RangeSumBST3(TreeNode? root, int low, int high)
    {
        if (root == null)
        {
            return 0;
        }

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        var sum = 0;

        while (queue.TryDequeue(out var node))
        {
            if (node.val >= low && node.val <= high)
            {
                sum += node.val;
            }

            if (node.left != null)
            {
                queue.Enqueue(node.left);
            }

            if (node.right != null)
            {
                queue.Enqueue(node.right);
            }
        }

        return sum;
    }

    /// <summary>
    /// BFS. Skip nodes
    /// </summary>
    public int RangeSumBST4(TreeNode? root, int low, int high)
    {
        if (root == null)
        {
            return 0;
        }

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        var sum = 0;

        while (queue.TryDequeue(out var node))
        {
            if (node.val >= low && node.val <= high)
            {
                sum += node.val;
            }

            if (node.val >= low
                && node.left != null)
            {
                queue.Enqueue(node.left);
            }

            if (node.val <= high
                && node.right != null)
            {
                queue.Enqueue(node.right);
            }
        }

        return sum;
    }

    /// <summary>
    /// DFS. Recursion. Skip nodes
    /// </summary>
    public int RangeSumBST5(TreeNode? root, int low, int high)
    {
        if (root == null)
        {
            return 0;
        }

        if (root.val >= low)
        {
            if (root.val <= high)
            {
                var sum = RangeSumBST5(root.left, low, high);
                sum += RangeSumBST5(root.right, low, high);
                sum += root.val;

                return sum;
            }

            return RangeSumBST5(root.left, low, high);
        }

        if (root.val <= high)
        {
            return RangeSumBST5(root.right, low, high);
        }

        return 0;
    }
}
