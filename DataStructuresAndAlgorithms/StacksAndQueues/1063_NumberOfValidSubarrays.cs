using Helpers;

namespace DataStructuresAndAlgorithms.StacksAndQueues;

internal class _1063_NumberOfValidSubarrays
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1([1, 4, 2, 5, 3]);
            Test1([3, 2, 1]);
            Test1([2, 2, 2]);
        }

        private void Test1(int[] nums)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(nums), string.Join(", ", nums)));

            var result = new _1063_NumberOfValidSubarrays().ValidSubarrays4(nums);

            printTable.AddProcessedParameters(
                (nameof(nums), string.Join(", ", nums)));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    public int ValidSubarrays(int[] nums)
    {
        var increasingStack = new Stack<int>(nums.Length);
        var subarrayCount = 0;

        for(var i = 0; i < nums.Length; i++)
        {
            var num = nums[i];
            while(increasingStack.TryPeek(out var minNum) 
                && num < minNum)
            {
                increasingStack.Pop();
            }

            increasingStack.Push(num);
            subarrayCount += increasingStack.Count;
        }
        
        return subarrayCount;
    }

    public int ValidSubarrays2(int[] nums)
    {
        var increasingStack = new int[nums.Length];
        var stackLength = 0;
        var subarrayCount = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            var num = nums[i];
            while (stackLength > 0
                && num < increasingStack[stackLength - 1])
            {
                stackLength--;
            }

            increasingStack[stackLength] = num;
            stackLength++;
            subarrayCount += stackLength;
        }

        return subarrayCount;
    }

    public int ValidSubarrays3(int[] nums)
    {
        var increasingStack = new int[nums.Length];
        var stackIndex = -1;
        var subarrayCount = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            var num = nums[i];
            while (stackIndex > -1
                && num < increasingStack[stackIndex])
            {
                stackIndex--;
            }

            stackIndex++;
            increasingStack[stackIndex] = num;
            subarrayCount += stackIndex + 1;
        }

        return subarrayCount;
    }

    public int ValidSubarrays4(int[] nums)
    {
        var increasingStackLength = 0;
        var subarrayCount = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            var num = nums[i];
            while (increasingStackLength > 0
                && num < nums[increasingStackLength - 1])
            {
                increasingStackLength--;
            }

            nums[increasingStackLength] = num;
            increasingStackLength++;
            subarrayCount += increasingStackLength;
        }

        return subarrayCount;
    }
}
