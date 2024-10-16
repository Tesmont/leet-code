using Helpers;

namespace Common;
internal class _1672_RichestCustomerWealth
{
    public void Launch()
    {
        Execute([[1, 2, 3], [3, 2, 1]]);
        Execute([[1, 5], [7, 3], [3, 5]]);
        Execute([[2, 8, 7], [7, 1, 3], [1, 9, 5]]);
    }

    private void Execute(int[][] accounts)
    {
        var result = MaximumWealth(accounts);

        Helper.PrintTable([
            ("accounts", accounts),
            ("result", result),
            ]);
    }

    public int MaximumWealth(int[][] accounts)
    {
        var maxWealth = int.MinValue;
        for (var i = 0; i < accounts.Length; i++)
        {
            var wealth = 0;
            for (var j = 0; j < accounts[i].Length; j++)
            {
                wealth += accounts[i][j];
            }
            maxWealth = Math.Max(maxWealth, wealth);
        }

        return maxWealth;
    }
}
