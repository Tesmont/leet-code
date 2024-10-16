using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.TreesAndGraphs.BFS;

internal class _0515_FindLargestValueInEachTreeRow
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

            var result = new _0515_FindLargestValueInEachTreeRow().LargestValues(root);

            List<(string Name, string? Value)> processedParameters =
            [
                (nameof(root), Environment.NewLine + root?.ToString() ?? "NULL")
            ];

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public IList<int> LargestValues(TreeNode? root)
    {
        if(root == null)
        {
            return Array.Empty<int>();
        }

        var result = new List<int>();

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while(queue.Count > 0)
        {
            var rowLength = queue.Count;

            var maxValue = int.MinValue;
            for(var i = 0; i < rowLength; i++)
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

                maxValue = Math.Max(maxValue, node.val);
            }

            result.Add(maxValue);
        }

        return result;
    }
}
