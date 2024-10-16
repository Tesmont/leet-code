using Helpers;
using System.Text.Json;

namespace TopInterview150.ArrayString;

internal class _0088_MergeSortedArray
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var nums1 = new int[] { 1, 2, 3, 0, 0, 0 };
            var m = 3;
            var nums2 = new int[] { 2, 5, 6 };
            var n = 3;
            Test(nums1, m, nums2, n);
        }

        private void Test(int[] nums1, int m, int[] nums2, int n)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(nums1), JsonSerializer.Serialize(nums1)),
                (nameof(m), JsonSerializer.Serialize(m)),
                (nameof(nums2), JsonSerializer.Serialize(nums2)),
                (nameof(n), JsonSerializer.Serialize(n))
            };

            new _0088_MergeSortedArray().Merge(nums1, m, nums2, n);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(nums1), JsonSerializer.Serialize(nums1)),
                (nameof(m), JsonSerializer.Serialize(m)),
                (nameof(nums2), JsonSerializer.Serialize(nums2)),
                (nameof(n), JsonSerializer.Serialize(n))
            };

            Helper.PrintTable(parameters, processedParameters);
        }
    }

    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        var i = m - 1;
        var j = n - 1;
        var k = nums1.Length - 1;

        while (i >= 0 && j >= 0)
        {
            var num1 = nums1[i];
            var num2 = nums2[j];

            if(num1 > num2)
            {
                nums1[k] = num1;
                i--;
            }
            else
            {
                nums1[k] = num2;
                j--;
            }

            k--;
        }

        while(j >= 0)
        {
            var num2 = nums2[j];
            nums1[k] = num2;

            j--;
            k--;
        }
    }
}
