using System.Text;

namespace Helpers;

public record class TreeNode(int val, TreeNode? left = null, TreeNode? right = null)
{
    public int val { get; set; } = val;
    public TreeNode? left { get; set; } = left;
    public TreeNode? right { get; set; } = right;

    public override string ToString()
    {
        return PrintTree(this);
    }

    private string PrintTree(TreeNode? node, string indent = "", bool last = true)
    {
        if (node == null)
        {
            return string.Empty;
        }

        var result = new StringBuilder();
        result.Append(indent);
        if (last)
        {
            result.Append("└─");
            indent += "  ";
        }
        else
        {
            result.Append("├─");
            indent += "| ";
        }

        result.AppendLine(node.val.ToString());

        result.Append(PrintTree(node.left, indent, node.right == null));
        result.Append(PrintTree(node.right, indent, true));

        return result.ToString();
    }
}