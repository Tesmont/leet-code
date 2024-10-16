﻿using Helpers;

namespace Common;
internal class _0412_FizzBuzz
{
    public void Launch()
    {
        Execute(3);
        Execute(5);
        Execute(15);
    }

    private void Execute(int n)
    {
        var result = FizzBuzz(n);

        Helper.PrintTable([
            ("n", n),
            ("result", result),
            ]);
    }

    public IList<string> FizzBuzz(int n)
    {
        var result = new string[n];
        for (var i = 1; i <= n; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                result[i - 1] = "FizzBuzz";
            }
            else if (i % 3 == 0)
            {
                result[i - 1] = "Fizz";
            }
            else if (i % 5 == 0)
            {
                result[i - 1] = "Buzz";
            }
            else
            {
                result[i - 1] = i.ToString();
            }
        }

        return result;
    }
}
