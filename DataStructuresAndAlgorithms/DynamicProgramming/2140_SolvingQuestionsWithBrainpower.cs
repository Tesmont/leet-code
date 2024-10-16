using Helpers;
using System.Text.Json;

namespace DataStructuresAndAlgorithms.DynamicProgramming;

internal class _2140_SolvingQuestionsWithBrainpower
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var questions = new int[][]
            {
                [21,2],[1,2],[12,5],[7,2],[35,3],[32,2],[80,2],[91,5],[92,3],[27,3],[19,1],[37,3],[85,2],[33,4],[25,1],[91,4],[44,3],[93,3],[65,4],[82,3],[85,5],[81,3],[29,2],[25,1],[74,2],[58,1],[85,1],[84,2],[27,2],[47,5],[48,4],[3,2],[44,3],[60,5],[19,2],[9,4],[29,5],[15,3],[1,3],[60,2],[63,3],[79,3],[19,1],[7,1],[35,1],[55,4],[1,4],[41,1],[58,5]
            };
            Test(questions);
        }

        private void Test(int[][] questions)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(questions), JsonSerializer.Serialize(questions))
            };

            var result = new _2140_SolvingQuestionsWithBrainpower().MostPoints2(questions);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(questions), JsonSerializer.Serialize(questions))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public long MostPoints(int[][] questions)
    {
        var dp = new long[questions.Length];
        dp[^1] = questions[^1][0];

        for (var i = 2; i <= questions.Length; i++)
        {
            var points = questions[^i][0];
            var brainpower = questions[^i][1];

            long pointsSum = points;
            for (var j = i - brainpower - 1; j >= 1; j--)
            {
                pointsSum = Math.Max(pointsSum, points + dp[^j]);
            }
            dp[^i] = pointsSum;
        }

        return dp.Max();
    }

    public long MostPoints2(int[][] questions)
    {
        var dp = new long[questions.Length];
        dp[^1] = questions[^1][0];

        for (var i = 2; i <= questions.Length; i++)
        {
            var currentPoints = questions[^i][0];
            var currentBrainpower = questions[^i][1];
            var previousPointsSum = dp[^(i - 1)];

            long currentPointsSum = currentPoints;
            var index = i - currentBrainpower - 1;
            if (index >= 1)
            {
                currentPointsSum += dp[^index];
            }

            dp[^i] = Math.Max(previousPointsSum, currentPointsSum);
        }

        return dp[0];
    }
}
