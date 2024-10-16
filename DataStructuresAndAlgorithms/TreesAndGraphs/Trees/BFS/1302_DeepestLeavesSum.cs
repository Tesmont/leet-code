using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.TreesAndGraphs.BFS;

internal class _1302_DeepestLeavesSum
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

            var result = new _1302_DeepestLeavesSum().DeepestLeavesSum(root);

            List<(string Name, string? Value)> processedParameters =
            [
                (nameof(root), Environment.NewLine + root?.ToString() ?? "NULL")
            ];

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int DeepestLeavesSum(TreeNode? root)
    {
        if (root == null)
        {
            return 0;
        }

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        int sum = 0;
        while (queue.Count > 0)
        {
            var rowLenght = queue.Count();

            sum = 0;
            for(var i = 0; i < rowLenght; i++)
            {
                var node = queue.Dequeue();

                if(node.left != null)
                {
                    queue.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }

                sum += node.val;
            }

        }

        return sum;
    }
}
