using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.TreesAndGraphs.BFS;

internal class _0103_BinaryTreeZigzagLevelOrderTraversal
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var root1 = new TreeNode(1,
                new TreeNode(2), new TreeNode(3));

            var root2 = TreeNodeHelper.BuildPerfectTree(4);

            Test1(root1);
            Test1(root2);
        }

        private void Test1(TreeNode? root)
        {
            List<(string Name, string? Value)> parameters =
            [
                (nameof(root), Environment.NewLine + root?.ToString() ?? "NULL")
            ];

            var result = new _0103_BinaryTreeZigzagLevelOrderTraversal().ZigzagLevelOrder(root);

            List<(string Name, string? Value)> processedParameters =
            [
                (nameof(root), Environment.NewLine + root?.ToString() ?? "NULL")
            ];

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public IList<IList<int>> ZigzagLevelOrder(TreeNode? root)
    {
        if(root == null)
        {
            return Array.Empty<IList<int>>();
        }

        var list = new LinkedList<TreeNode>();
        list.AddLast(root);

        var result = new List<IList<int>>();

        while(list.Count > 0)
        {
            var rowLenght = list.Count();

            var row = new int[rowLenght];
            result.Add(row);

            if (result.Count % 2 == 0)
            {
                for (var i = 0; i < rowLenght; i++)
                {
                    var node = list.Last();
                    list.RemoveLast();

                    if (node.right != null)
                    {
                        list.AddFirst(node.right);
                    }

                    if (node.left != null)
                    {
                        list.AddFirst(node.left);
                    }

                    row[i] = node.val;
                }
            }
            else
            {
                for (var i = 0; i < rowLenght; i++)
                {
                    var node = list.First();
                    list.RemoveFirst();

                    if (node.left != null)
                    {
                        list.AddLast(node.left);
                    }

                    if (node.right != null)
                    {
                        list.AddLast(node.right);
                    }

                    row[i] = node.val;
                }
            }
        }

        return result;
    }
}
