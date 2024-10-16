using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.TreesAndGraphs.DFS;

internal class _0236_LowestCommonAncestorOfABinaryTree
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var root1 = new TreeNode(3,
                new TreeNode(5, new TreeNode(6), new TreeNode(2, new TreeNode(7), new TreeNode(4))),
                new TreeNode(1, new TreeNode(0), new TreeNode(8)));

            Test1(root1, root1.left!, root1.left!.right!.right!);

            var root2 = new TreeNode(1,
                new TreeNode(2));

            Test1(root2, root2, root2.left!);

            var root3 = new TreeNode(1,
                new TreeNode(2,
                    new TreeNode(4, new TreeNode(8), new TreeNode(9)),
                    new TreeNode(5, new TreeNode(10), new TreeNode(11))),
                new TreeNode(3,
                    new TreeNode(6, new TreeNode(12), new TreeNode(13)),
                    new TreeNode(7, new TreeNode(14), new TreeNode(15)))
                );

            Test1(root3, new TreeNode(9), new TreeNode(11));
        }

        private void Test1(TreeNode root, TreeNode p, TreeNode q)
        {
            List<(string Name, string? Value)> parameters =
            [
                (nameof(root), Environment.NewLine + root.ToString()),
                (nameof(p), Environment.NewLine + p.ToString()),
                (nameof(q), Environment.NewLine + q.ToString())
            ];

            var result = new _0236_LowestCommonAncestorOfABinaryTree().LowestCommonAncestor2(root, p, q);

            List<(string Name, string? Value)> processedParameters =
            [
                (nameof(root), Environment.NewLine + root.ToString()),
                (nameof(p), Environment.NewLine + p.ToString()),
                (nameof(q), Environment.NewLine + q.ToString())
            ];

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public TreeNode? LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        var stack = new Stack<TreeNode>();
        var postorderStack = new Stack<TreeNode>();

        stack.Push(root);

        while (stack.TryPop(out var node))
        {
            postorderStack.Push(node);

            if (node.right != null)
            {
                stack.Push(node.right);
            }

            if (node.left != null)
            {
                stack.Push(node.left);
            }
        }

        while (postorderStack.TryPop(out var node))
        {
            var pFlag = false;
            var qFlag = false;

            if (p.val == node.val
                || p.val == node.left?.val
                || p.val == node.right?.val)
            {
                pFlag = true;
            }

            if (q.val == node.val
                || q.val == node.left?.val
                || q.val == node.right?.val)
            {
                qFlag = true;
            }

            if (pFlag && qFlag)
            {
                return node;
            }

            if (p.val == node.left?.val
                || p.val == node.right?.val)
            {
                node.val = p.val;

                continue;
            }

            if (q.val == node.left?.val
                || q.val == node.right?.val)
            {
                node.val = q.val;

                continue;
            }
        }

        return null;
    }

    private enum State
    {
        NoPassedNodes,
        LeftNodePassed,
        BothNodesPassed
    }

    public TreeNode? LowestCommonAncestor2(TreeNode root, TreeNode p, TreeNode q)
    {
        LinkedList<(TreeNode Node, State State)> stack = new();
        stack.AddLast((root, State.NoPassedNodes));

        var isOneNodeFound = false;

        TreeNode? LCA = null;

        while (stack.Last != null)
        {
            ref (TreeNode Node, State State) nodeTuple = ref stack.Last.ValueRef;
            if (nodeTuple.State == State.NoPassedNodes)
            {
                if (nodeTuple.Node == p
                    || nodeTuple.Node == q)
                {
                    if (isOneNodeFound)
                    {
                        return LCA;
                    }
                    else
                    {
                        isOneNodeFound = true;
                        LCA = nodeTuple.Node;
                    }
                }

                nodeTuple.State = State.LeftNodePassed;

                if (nodeTuple.Node.left != null)
                {
                    stack.AddLast((nodeTuple.Node.left, State.NoPassedNodes));
                }

                continue;
            }
            else if (nodeTuple.State == State.LeftNodePassed)
            {
                nodeTuple.State = State.BothNodesPassed;

                if (nodeTuple.Node.right != null)
                {
                    stack.AddLast((nodeTuple.Node.right, State.NoPassedNodes));
                }

                continue;
            }

            //if(nodeTuple.State == State.BothNodesPassed)

            stack.RemoveLast();
            if (nodeTuple.Node == LCA
                && isOneNodeFound)
            {
                LCA = stack.Last.Value.Node;
            }
        }

        return null;
    }
}
