using Helpers;

namespace DataStructuresAndAlgorithms.Hashing;

internal class _2248_IntersectionOfMultipleArrays
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1([[1, 2, 3], [4, 5, 6], [7, 8, 9]]);
            Test1([[1, 2, 3], [2, 3, 4], [3, 4, 5]]);
            Test1([[1, 2, 2, 1], [2, 2]]);
            Test1([[7, 34, 45, 10, 12, 27, 13], [27, 21, 45, 10, 12, 13]]);
        }

        private void Test1(int[][] nums)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(nums), nums));

            var result = new _2248_IntersectionOfMultipleArrays().Intersection(nums);

            printTable.AddProcessedParameters(
                (nameof(nums), nums));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    public IList<int> Intersection(int[][] nums)
    {
        var dict = new Dictionary<int, int>();
        for(var i = 0; i < nums[0].Length; i++) 
        {
            dict[nums[0][i]] = 1;
        }

        for(var i = 1; i < nums.Length; i++)
        {
            for(var ii = 0;  ii < nums[i].Length; ii++)
            {
                if (dict.TryGetValue(nums[i][ii], out var count))
                {
                    dict[nums[i][ii]] = count + 1;
                }
            }
        }

        var result = new List<int>(dict.Count);
        foreach(var kvPair in dict)
        {
            if(kvPair.Value == nums.Length)
            {
                result.Add(kvPair.Key);
            }
        }

        result.Sort();

        return result;
    }
}
