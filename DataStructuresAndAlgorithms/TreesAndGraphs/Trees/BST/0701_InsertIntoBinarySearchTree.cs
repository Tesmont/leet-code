using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.TreesAndGraphs.BST;

internal class _0701_InsertIntoBinarySearchTree
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var root1 = new TreeNode(4,
                new TreeNode(2, new TreeNode(1), new TreeNode(3)),
                new TreeNode(7));

            Test1(root1, 5);
        }

        private void Test1(TreeNode? root, int val)
        {
            List<(string Name, string? Value)> parameters =
            [
                (nameof(root), Environment.NewLine + root?.ToString() ?? "NULL"),
                (nameof(val), val.ToString())
            ];

            var result = new _0701_InsertIntoBinarySearchTree().InsertIntoBST(root, val);

            List<(string Name, string? Value)> processedParameters =
            [
                (nameof(root), Environment.NewLine + root?.ToString() ?? "NULL"),
                (nameof(val), val.ToString())
            ];

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    /// <summary>
    /// DFS. Recursion
    /// </summary>
    public TreeNode InsertIntoBST(TreeNode? root, int val)
    {
        void Recursion(TreeNode root, int val)
        {
            if (val < root.val)
            {
                if (root.left == null)
                {
                    root.left = new TreeNode(val);
                    return;
                }

                Recursion(root.left, val);
                return;
            }

            if (root.right == null)
            {
                root.right = new TreeNode(val);
                return;
            }

            Recursion(root.right, val);
        }

        if (root == null)
        {
            return new TreeNode(val);
        }

        Recursion(root, val);

        return root;
    }

    /// <summary>
    /// DFS. Iteration.
    /// </summary>
    public TreeNode InsertIntoBST2(TreeNode? root, int val)
    {
        if (root == null)
        {
            return new TreeNode(val);
        }

        var currentNode = root;
        while (true)
        {
            if (val < currentNode.val)
            {
                if(currentNode.left == null)
                {
                    currentNode.left = new TreeNode(val);
                    return root;
                }

                currentNode = currentNode.left;
                continue;
            }

            if (currentNode.right == null)
            {
                currentNode.right = new TreeNode(val);
                return root;
            }

            currentNode = currentNode.right;
        }
    }
}
