using Helpers;
using System.Text.Json;

namespace Common;

internal class _0124_BinaryTreeMaximumPathSum
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var root1 = new TreeNode(1,
                new TreeNode(2), new TreeNode(3)
            );

            var root2 = new TreeNode(-10,
                new TreeNode(9),
                new TreeNode(20,
                    new TreeNode(15),
                    new TreeNode(7)
                )
            );

            var root3 = new TreeNode(2,
                new TreeNode(-1)
            );

            Test1(root1);
            Test1(root2);
            Test1(root3);
        }

        private void Test1(TreeNode root)
        {
            List<(string Name, string? Value)> parameters =
            [
                (nameof(root), Environment.NewLine + root.ToString())
            ];

            var result = new _0124_BinaryTreeMaximumPathSum().MaxPathSum(root);

            List<(string Name, string? Value)> processedParameters =
            [
                (nameof(root), Environment.NewLine + root.ToString())
            ];

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    private int _maxPathSum;

    /// <summary>
    /// DFS. Recursuion
    /// </summary>
    public int MaxPathSum(TreeNode root)
    {
        _maxPathSum = int.MinValue;
        
        MaxPathSumRecusrion(root);

        return _maxPathSum;
    }

    private int MaxPathSumRecusrion(TreeNode? root)
    {
        if(root == null)
        {
            return 0;
        }

        var leftPathSum = MaxPathSumRecusrion(root.left);
        var rightPathSum = MaxPathSumRecusrion(root.right);

        var pathSum = leftPathSum + rightPathSum + root.val;
        _maxPathSum = Math.Max(_maxPathSum, pathSum);

        var maxPathSum = Math.Max(leftPathSum, rightPathSum) + root.val;

        return Math.Max(maxPathSum, 0);
    }
}
