using Helpers;

namespace TopInterview150;

internal class _0134_GasStation
{
    public void Launch()
    {
        Execute([1, 2, 3, 4, 5], [3, 4, 5, 1, 2]);
        Execute([2, 3, 4], [3, 4, 3]);

        Execute([5, 8, 2, 8], [6, 5, 6, 6]);
        Execute([4, 5, 2, 6, 5, 3], [3, 2, 7, 3, 2, 9]);

        Execute([1, 2, 3, 4, 5], [2, 3, 4, 5, 6]);
        Execute([1], [1]);
        Execute([0], [1]);
    }

    private void Execute(int[] gas, int[] cost)
    {
        var originalGas = gas.Clone();
        var result = CanCompleteCircuitV2(gas, cost);

        Helper.PrintTable([
            ("original gas", originalGas),
            ("processed gas", gas),
            ("cost", cost),
            ("result", result),
            ]);
    }

    public int CanCompleteCircuit(int[] gas, int[] cost)
    {
        var lenght = gas.Length;

        //gas is used to store leftover gas in tank

        var gasInTank = 0;
        var possibleStartIndex = -1;
        var availableIndex = -1;
        for (var i = 0; i < lenght; i++)
        {
            var stationProfit = gas[i] - cost[i];
            var possibleGasInTank = gasInTank + stationProfit;

            if (possibleGasInTank < 0)
            {
                gasInTank = 0;
                possibleStartIndex = -1;

                gas[i] = stationProfit;
            }
            else
            {
                if (possibleStartIndex == -1)
                {
                    possibleStartIndex = i;
                }
                else
                {
                    gas[i] = 0;
                }

                availableIndex = i;
                gasInTank = possibleGasInTank;

                gas[possibleStartIndex] = gasInTank;
            }
        }

        if (possibleStartIndex == -1
            || availableIndex != lenght - 1)
        {
            return -1;
        }

        for (var i = 0; i < possibleStartIndex; i++)
        {
            gasInTank += gas[i];
            if (gasInTank < 0)
            {
                return -1;
            }
        }

        return possibleStartIndex;
    }

    public int CanCompleteCircuitV2(int[] gas, int[] cost)
    {
        var totalGasVolume = 0;
        var gasInTank = 0;
        var possibleStartIndex = 0;

        for (var i = 0; i < gas.Length; i++)
        {
            totalGasVolume += gas[i] - cost[i];
            gasInTank += gas[i] - cost[i];

            if (gasInTank < 0)
            {
                possibleStartIndex = i + 1;
                gasInTank = 0;
            }
        }

        return totalGasVolume >= 0 ? possibleStartIndex : -1;
    }
}
