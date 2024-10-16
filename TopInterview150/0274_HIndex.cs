using Helpers;
using System.Text.Json;

namespace TopInterview150;

internal class _0274_HIndex
{
    public void Launch()
    {
        Execute([1]);
        Execute([1, 1]);
        Execute([3, 0, 6, 1, 5]);
        Execute([1, 3, 1]);
        Execute([1000, 3, 1]);
        Execute([1000, 1, 1]);
    }

    private void Execute(int[] nums)
    {
        var originalNums = JsonSerializer.Serialize(nums);
        var result = HIndexV4(nums);

        Helper.PrintTable([
            ("numns", originalNums),
            ("processed numns", JsonSerializer.Serialize(nums)),
            ("result", result),
            ]);
    }

    public int HIndexV1(int[] citations)
    {
        Array.Sort(citations);
        Array.Reverse(citations);
        var hIndex = 1;
        for (var i = 0; i < citations.Length; i++)
        {
            if (citations[i] < hIndex)
            {
                break;
            }

            hIndex++;
        }
        return hIndex - 1;
    }

    public int HIndexV2(int[] citations)
    {
        Array.Sort(citations);
        var hIndex = 1;
        for (var i = citations.Length - 1; i >= 0; i--)
        {
            if (citations[i] < hIndex)
            {
                break;
            }

            hIndex++;
        }
        return hIndex - 1;
    }

    public int HIndexV3(int[] citations)
    {
        //Reduce array lenght before sorting
        var hIndex = 0;
        for (var i = 0; i < citations.Length; i++)
        {
            if (citations[i] >= citations.Length)
            {
                citations[i] = citations[hIndex];
                hIndex++;
            }
        }

        var newStartIndex = hIndex;
        var newLenght = citations.Length - hIndex;
        Array.Sort(citations, newStartIndex, newLenght);

        hIndex++;
        for (var i = citations.Length - 1; i >= newStartIndex; i--)
        {
            if (citations[i] < hIndex)
            {
                break;
            }

            hIndex++;
        }
        return hIndex - 1;
    }

    public int HIndexV4(int[] citations)
    {
        int total = 0;
        int[] counts = new int[citations.Length];

        for (var i = 0; i < citations.Length; i++)
        {
            if (citations[i] >= citations.Length)
            {
                total++;
            }
            else
            {
                counts[citations[i]]++;
            }
        }

        if (total == citations.Length)
        {
            return total;
        }

        for (var i = citations.Length - 1; i >= 0; i--)
        {
            total += counts[i];

            if (total >= i)
            {
                return i;
            }
        }

        return 0;
    }
}
