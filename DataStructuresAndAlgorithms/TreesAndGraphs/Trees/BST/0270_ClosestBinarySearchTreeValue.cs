using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.TreesAndGraphs.BST;

internal class _0270_ClosestBinarySearchTreeValue
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var root1 = new TreeNode(4,
                new TreeNode(2, new TreeNode(1), new TreeNode(3)),
                new TreeNode(5));

            var root2 = new TreeNode(36,
                new TreeNode(13,
                    new TreeNode(4,
                        new TreeNode(1,
                            new TreeNode(0,
                                null,
                                new TreeNode(2,
                                    new TreeNode(3),
                                    null
                                )
                            ),
                            new TreeNode(5,
                                new TreeNode(9,
                                    new TreeNode(7,
                                        new TreeNode(6),
                                        new TreeNode(8)
                                    ),
                                    new TreeNode(11,
                                        new TreeNode(10),
                                        new TreeNode(12)
                                    )
                                ),
                                null
                            )
                        ),
                        new TreeNode(20,
                            new TreeNode(17,
                                new TreeNode(14,
                                    null,
                                    new TreeNode(16,
                                        new TreeNode(15),
                                        null
                                    )
                                ),
                                new TreeNode(18,
                                    null,
                                    new TreeNode(19)
                                )
                            ),
                            new TreeNode(33,
                                new TreeNode(22,
                                    new TreeNode(21),
                                    new TreeNode(27,
                                        new TreeNode(26),
                                        null
                                    )
                                ),
                                new TreeNode(34,
                                    null,
                                    new TreeNode(35)
                                )
                            )
                        )
                    ),
                    new TreeNode(37,
                        null,
                        new TreeNode(48,
                            new TreeNode(43,
                                new TreeNode(40,
                                    new TreeNode(39,
                                        new TreeNode(38),
                                        null
                                    ),
                                    new TreeNode(42,
                                        new TreeNode(41),
                                        null
                                    )
                                ),
                                new TreeNode(46,
                                    new TreeNode(45),
                                    new TreeNode(47)
                                )
                            ),
                            new TreeNode(49)
                        )
                    )
                )
            );

            Test1(root1, 3.714286);
            Test1(root2, 3.142857);
        }

        private void Test1(TreeNode root, double target)
        {
            List<(string Name, string? Value)> parameters =
            [
                (nameof(root), Environment.NewLine + root.ToString()),
                (nameof(target), target.ToString())
            ];

            var result = new _0270_ClosestBinarySearchTreeValue().ClosestValue(root, target);

            List<(string Name, string? Value)> processedParameters =
            [
                (nameof(root), Environment.NewLine + root.ToString()),
                (nameof(target), target.ToString())
            ];

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    /// <summary>
    /// Binary search
    /// </summary>
    public int ClosestValue(TreeNode root, double target)
    {
        if(target == root.val)
        {
            return root.val;
        }

        var closestNode = root;
        var closestDifference = Math.Abs(closestNode.val - target);

        var currentNode = target < root.val 
            ? root.left 
            : root.right;
        while (currentNode != null)
        {
            var difference = Math.Abs(currentNode.val - target);
            if (difference < closestDifference
                || (difference == closestDifference && currentNode.val < closestNode.val))
            {
                closestNode = currentNode;
                closestDifference = difference;
            }

            if (target == currentNode.val)
            {
                return currentNode.val;
            }

            if (target < currentNode.val)
            {
                currentNode = currentNode.left;
                continue;
            }

            //if (target > currentNode.val)
            currentNode = currentNode.right;
        }

        return closestNode.val;
    }
}
