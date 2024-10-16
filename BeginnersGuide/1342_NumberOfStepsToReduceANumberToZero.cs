using Helpers;

namespace Common;
internal class _1342_NumberOfStepsToReduceANumberToZero
{
    public void Launch()
    {
        Execute(14);
        Execute(8);
        Execute(123);
    }

    private void Execute(int num)
    {
        var result = NumberOfSteps(num);

        Helper.PrintTable([
            ("num", num),
            ("result", result),
            ]);
    }

    public int NumberOfSteps(int num)
    {
        GC.Collect();

        var steps = 0;

        while (num != 0)
        {
            if (num % 2 == 0)
            {
                num /= 2;
                steps++;
            }
            else
            {
                num -= 1;
                steps++;
            }
        }

        return steps;
    }
}
