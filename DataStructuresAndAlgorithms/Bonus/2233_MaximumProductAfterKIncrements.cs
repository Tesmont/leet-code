using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.Bonus;

internal class _2233_MaximumProductAfterKIncrements
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var nums = new int[] { 1, 2, 3 };
            var k = 3;
            Test(nums, k);
        }

        private void Test(int[] nums, int k)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(nums), JsonSerializer.Serialize(nums)),
                (nameof(k), JsonSerializer.Serialize(k))
            };

            var result = new _2233_MaximumProductAfterKIncrements().MaximumProduct(nums, k);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(nums), JsonSerializer.Serialize(nums)),
                (nameof(k), JsonSerializer.Serialize(k))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public int MaximumProduct(int[] nums, int k)
    {
        Array.Sort(nums);

        while(k > 0)
        {
            var lookForNum = nums[0];
            nums[0]++;
            k--;
            for (var i = 1; i < nums.Length & k > 0; i++)
            {
                if (nums[i] != lookForNum)
                {
                    break;
                }

                nums[i]++;
                k--;
            }
        }

        const int mod = 1_000_000_000 + 7;

        long product = nums[0];
        for(var i = 1; i < nums.Length; i++)
        {
            //product = (product * nums[i]) % mod;
            product *= nums[i];
        }

        return (int)(product & mod);
    }

    public int MaximumProduct2(int[] nums, int k)
    {
        var heapSource = nums.Select(num => (num, num));
        var heap = new PriorityQueue<int, int>(heapSource);

        while (k > 0)
        {
            var num = heap.Dequeue();
            num++;
            k--;
            heap.Enqueue(num, num);
        }

        const int mod = 1_000_000_000 + 7;

        long product = heap.Dequeue();
        while(heap.TryDequeue(out var num, out _))
        {
            product = (product * num) % mod;
        }

        return (int)product;
    }
}
