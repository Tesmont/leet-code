using Helpers;

namespace DataStructuresAndAlgorithms.StacksAndQueues;

internal class _0496_NextGreaterElementI
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1([4, 1, 2], [1, 3, 4, 2]);
            Test1([2, 4], [1, 2, 3, 4]);
        }

        private void Test1(int[] nums1, int[] nums2)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(nums1), string.Join(", ", nums1)),
                (nameof(nums2), string.Join(", ", nums2)));

            var result = new _0496_NextGreaterElementI().NextGreaterElement(nums1, nums2);

            printTable.AddProcessedParameters(
                (nameof(nums1), string.Join(", ", nums1)),
                (nameof(nums2), string.Join(", ", nums2)));

            printTable.AddResult(string.Join(", ", result));
            Helper.PrintTable(printTable);
        }
    }

    public int[] NextGreaterElement(int[] nums1, int[] nums2)
    {
        var hashSet = new Dictionary<int, int>(nums2.Length);
        var decreasingDeque = new Stack<int>(nums2.Length);

        for(var i = 0; i < nums2.Length; i++)
        {
            var num = nums2[i];
            while(decreasingDeque.TryPeek(out var lastNum) && num > lastNum)
            {
                hashSet.Add(lastNum, num);
                decreasingDeque.Pop();
            }

            decreasingDeque.Push(num);
        }

        for(var i = 0; i < nums1.Length; i++)
        {
            nums1[i] = hashSet.TryGetValue(nums1[i], out var nextGreaterElement) 
                ? nextGreaterElement 
                : -1;
        }

        return nums1;
    }
}
