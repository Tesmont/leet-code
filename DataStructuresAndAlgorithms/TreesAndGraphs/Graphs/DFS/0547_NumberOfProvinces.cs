using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.TreesAndGraphs.Graphs.DFS;

internal class _0547_NumberOfProvinces
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var isConnected1 = new int[][]
            {
                [1, 1, 0],
                [1, 1, 0],
                [0, 0, 1]
            };

            Test1(isConnected1);
        }

        private void Test1(int[][] isConnected)
        {
            List<(string Name, string? Value)> parameters =
            [
                (nameof(isConnected), Environment.NewLine + GraphHelper.ConvertGridToString(isConnected))
            ];

            var result = new _0547_NumberOfProvinces().FindCircleNum(isConnected);

            List<(string Name, string? Value)> processedParameters =
            [
                (nameof(isConnected), Environment.NewLine + GraphHelper.ConvertGridToString(isConnected))
            ];

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    /// <summary>
    /// DFS. Recursion
    /// Time: O(n^2).
    /// Space: O(n).
    /// </summary>
    public int FindCircleNum(int[][] isConnected)
    {
        var processedCities = new bool[isConnected.Length];
        var provinceCount = 0;

        for (var firstProvinceCity = 0; firstProvinceCity < isConnected.Length; firstProvinceCity++)
        {
            if (processedCities[firstProvinceCity])
            {
                continue;
            }

            provinceCount++;
            ProcessCityInProvince(firstProvinceCity);
        }

        return provinceCount;

        void ProcessCityInProvince(int parentCity)
        {
            processedCities[parentCity] = true;

            for (var childCity = isConnected[parentCity].Length - 1; childCity >= 0; childCity--)
            {
                if (isConnected[parentCity][childCity] == 0
                    || processedCities[childCity])
                {
                    continue;
                }

                ProcessCityInProvince(childCity);
            }
        }
    }

    /// <summary>
    /// DFS. Stack
    /// Time: O(n^2).
    /// Space: O(n).
    /// </summary>
    public int FindCircleNumV2(int[][] isConnected)
    {
        var processedCities = new bool[isConnected.Length];
        var provinceCount = 0;

        var stack = new Stack<int>();
        for (var city = 0; city < isConnected.Length; city++)
        {
            if (processedCities[city])
            {
                continue;
            }

            provinceCount++;
            processedCities[city] = true;
            stack.Push(city);

            while (stack.TryPop(out var parentCity))
            {
                for (var childCity = isConnected[parentCity].Length - 1; childCity >= 0; childCity--)
                {
                    if (isConnected[parentCity][childCity] == 0
                        || processedCities[childCity])
                    {
                        continue;
                    }

                    processedCities[childCity] = true;
                    stack.Push(childCity);
                }
            }
        }

        return provinceCount;
    }
}
