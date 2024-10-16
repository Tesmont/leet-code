namespace Helpers;

public static class TreeNodeHelper
{
    public static TreeNode BuildPerfectTree(int depth)
    {
        if(depth == 0)
        {
            throw new ArgumentException(depth.ToString(), nameof(depth));
        }

        var currentVal = 0;

        TreeNode root = new TreeNode(currentVal++);
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        for (var level = 1; level < depth; level++)
        {
            var levelNodeCount = Math.Pow(2, level - 1);
            for (var i = 0; i < levelNodeCount; i++)
            {
                TreeNode node = queue.Dequeue();
                node.left = new TreeNode(currentVal++);
                node.right = new TreeNode(currentVal++);
                queue.Enqueue(node.left);
                queue.Enqueue(node.right);
            }
        }

        return root;
    }

    public static TreeNode? ArrayToTreeNode(int?[] arr)
    {
        if (arr.Length == 0
            || arr[0] == null)
        {
            return null;
        }

        TreeNode root = new TreeNode(arr[0]!.Value);
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        int i = 1;

        while (i < arr.Length)
        {
            TreeNode current = queue.Dequeue();

            if (i < arr.Length && arr[i] != null)
            {
                current.left = new TreeNode(arr[i]!.Value);
                queue.Enqueue(current.left);
            }
            i++;

            if (i < arr.Length && arr[i] != null)
            {
                current.right = new TreeNode(arr[i]!.Value);
                queue.Enqueue(current.right);
            }
            i++;
        }

        return root;
    }
}
