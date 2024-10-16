using Helpers;

namespace DataStructuresAndAlgorithms.StacksAndQueues;

internal class _0735_AsteroidCollision
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1([1, -2, -2, -2]);
            Test1([-2, 1, -1, -2]);

            Test1([5, 10, -5]);
            Test1([8, -8]);
            Test1([10, 2, -5]);
            Test1([-2, -1, 1, 2]);
        }

        private void Test1(int[] asteroids)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(asteroids), string.Join(", ", asteroids)));

            var result = new _0735_AsteroidCollision().AsteroidCollision2(asteroids);

            printTable.AddProcessedParameters(
                (nameof(asteroids), string.Join(", ", asteroids)));

            printTable.AddResult(string.Join(", ", result));
            Helper.PrintTable(printTable);
        }
    }

    public int[] AsteroidCollision(int[] asteroids)
    {
        var currentAsteroidIndex = 1;
        var previousAsteroidIndex = 0;

        for (; currentAsteroidIndex < asteroids.Length; currentAsteroidIndex++)
        {
            var currentAsteroid = asteroids[currentAsteroidIndex];

            if (currentAsteroid > 0
                || previousAsteroidIndex == -1)
            {
                previousAsteroidIndex++;
                asteroids[previousAsteroidIndex] = currentAsteroid;

                continue;
            }

            var currentAbsAsteroid = Math.Abs(currentAsteroid);
            var currentAsteroidDirection = Math.Sign(currentAsteroid);

            var previousAsteroid = asteroids[previousAsteroidIndex];
            var previousAbsAsteroid = Math.Abs(previousAsteroid);
            var previousAsteroidDirection = Math.Sign(previousAsteroid);

            while (currentAsteroidDirection != previousAsteroidDirection
                && currentAbsAsteroid > previousAbsAsteroid)
            {
                asteroids[previousAsteroidIndex] = currentAsteroid;

                previousAsteroidIndex--;
                if (previousAsteroidIndex == -1)
                {
                    break;
                }

                previousAsteroid = asteroids[previousAsteroidIndex];
                previousAbsAsteroid = Math.Abs(previousAsteroid);
                previousAsteroidDirection = Math.Sign(previousAsteroid);
            }

            if (previousAsteroidIndex == -1)
            {
                previousAsteroidIndex = 0;
                continue;
            }

            if (currentAsteroidDirection == previousAsteroidDirection)
            {
                //Skip gap if it exists
                previousAsteroidIndex++;
                asteroids[previousAsteroidIndex] = currentAsteroid;
                continue;
            }

            if (currentAbsAsteroid == previousAbsAsteroid)
            {
                //selft descruction
                previousAsteroidIndex--;
                continue;
            }

            //currentAbsAsteroid < previousAbsAsteroid
        }

        var result = new int[previousAsteroidIndex + 1];
        Array.Copy(asteroids, result, result.Length);

        return result;
    }

    public int[] AsteroidCollision2(int[] asteroids)
    {
        var currentAsteroidIndex = 1;
        var stackLenght = 1;

        for (; currentAsteroidIndex < asteroids.Length; currentAsteroidIndex++)
        {
            var currentAsteroid = asteroids[currentAsteroidIndex];

            while (stackLenght > 0)
            {
                var previousAsteroid = asteroids[stackLenght - 1];

                if (previousAsteroid < 0 || currentAsteroid > 0)
                {
                    break;
                }

                var difference = currentAsteroid + previousAsteroid;

                if (difference == 0)
                {
                    //Destroy both

                    currentAsteroid = 0;
                    stackLenght--;
                    break;
                }

                if (difference > 0)
                {
                    //Previous is bigger
                    //Destroy the current

                    currentAsteroid = 0;
                    break;
                }

                stackLenght--;
            }

            //push
            if (currentAsteroid == 0)
            {
                continue;
            }

            asteroids[stackLenght] = currentAsteroid;
            stackLenght++;
        }

        var result = new int[stackLenght];
        Array.Copy(asteroids, result, stackLenght);

        return result;
    }
}
