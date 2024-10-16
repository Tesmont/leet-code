using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.TreesAndGraphs.DFS;

internal class _0543_DiameterOfBinaryTree
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var root1 = new TreeNode(1,
                new TreeNode(2,
                    new TreeNode(4),
                    new TreeNode(5)
                ),
                new TreeNode(3)
            );


            var root2 = new TreeNode(1,
                new TreeNode(2), new TreeNode(3)
            );

            var root3 = new TreeNode(4,
                new TreeNode(-7,
                    null,
                    new TreeNode(-9,
                        new TreeNode(9,
                            new TreeNode(0,
                                new TreeNode(-1),
                                null),
                            new TreeNode(6,
                                new TreeNode(6),
                                null)
                        ),
                        new TreeNode(-7,
                            new TreeNode(5),
                            new TreeNode(9,
                                null,
                                new TreeNode(-1)
                            )
                        )
                    )
                ),
                new TreeNode(-3,
                    new TreeNode(-9,
                        new TreeNode(-4),
                        null
                    ),
                    new TreeNode(-3,
                        new TreeNode(-4,
                            null,
                            null
                        ),
                        new TreeNode(-2)
                    )
                )
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

            var result = new _0543_DiameterOfBinaryTree().DiameterOfBinaryTree2(root);

            List<(string Name, string? Value)> processedParameters =
            [
                (nameof(root), Environment.NewLine + root.ToString())
            ];

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    /// <summary>
    /// DFS. Two stacks + HashMap
    /// </summary>
    public int DiameterOfBinaryTree(TreeNode root)
    {
        var stack = new Stack<TreeNode>();
        stack.Push(root);

        var postOrderStack = new Stack<TreeNode>();
        var hashMap = new Dictionary<TreeNode, int>();
        var maxLength = int.MinValue;

        while (stack.TryPop(out var node))
        {
            postOrderStack.Push(node);

            if (node.right != null)
            {
                stack.Push(node.right);
            }

            if (node.left != null)
            {
                stack.Push(node.left);
            }
        }

        while (postOrderStack.TryPop(out var node))
        {
            var leftLenght = node.left != null
                ? hashMap[node.left] + 1
                : 0;

            var rightLenght = node.right != null
                ? hashMap[node.right] + 1
                : 0;

            var length = Math.Max(leftLenght, rightLenght);
            hashMap[node] = length;

            maxLength = Math.Max(maxLength, leftLenght + rightLenght);
        }

        return maxLength;
    }

    /// <summary>
    /// DFS. Recursion
    /// </summary>
    public int DiameterOfBinaryTree2(TreeNode root)
    {
        _maxLenght = 0;
        DiameterOfBinaryTreeRecursion(root);

        return _maxLenght;
    }

    private int _maxLenght;

    private int DiameterOfBinaryTreeRecursion(TreeNode? root)
    {
        if (root == null)
        {
            return 0;
        }

        var leftLenght = DiameterOfBinaryTreeRecursion(root.left);
        var rightLenght = DiameterOfBinaryTreeRecursion(root.right);

        _maxLenght = Math.Max(_maxLenght, leftLenght + rightLenght);

        return Math.Max(leftLenght, rightLenght) + 1;
    }

    public enum NodeState
    {
        NoPassedNodes,
        LeftNodePassed,
        BothNodesPassed
    }

    /// <summary>
    /// DFS. Single stack
    /// </summary>
    public int DiameterOfBinaryTree3(TreeNode root)
    {
        //Need an opportunity to chage value type field. Stack<> doesn't let it.
        var stack = new LinkedList<(TreeNode Node, NodeState State)>();
        stack.AddLast((root, NodeState.NoPassedNodes));

        var hashMap = new Dictionary<TreeNode, int>();

        var maxLength = int.MinValue;

        while (stack.Last != null)
        {
            ref var nodeTuple = ref stack.Last.ValueRef;

            if (nodeTuple.State == NodeState.NoPassedNodes)
            {
                nodeTuple.State = NodeState.LeftNodePassed;

                if (nodeTuple.Node.left != null)
                {
                    stack.AddLast((nodeTuple.Node.left, NodeState.NoPassedNodes));
                }

                continue;
            }
            else if (nodeTuple.State == NodeState.LeftNodePassed)
            {
                nodeTuple.State = NodeState.BothNodesPassed;

                if (nodeTuple.Node.right != null)
                {
                    stack.AddLast((nodeTuple.Node.right, NodeState.NoPassedNodes));
                }

                continue;
            }

            //if(nodeTuple.State == NodeState.BothNodesPassed) { }
            stack.RemoveLast();
            var leftLength = nodeTuple.Node.left != null
                ? hashMap[nodeTuple.Node.left] + 1
                : 0;

            var rightLength = nodeTuple.Node.right != null
                ? hashMap[nodeTuple.Node.right] + 1
                : 0;

            hashMap[nodeTuple.Node] = Math.Max(leftLength, rightLength);
            maxLength = Math.Max(maxLength, leftLength + rightLength);
        }

        return maxLength;
    }
}
