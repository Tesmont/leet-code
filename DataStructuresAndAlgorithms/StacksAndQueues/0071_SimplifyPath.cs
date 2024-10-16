using Helpers;
using System.Text;

namespace DataStructuresAndAlgorithms.StacksAndQueues;

internal class _0071_SimplifyPath
{
    internal class Tester
    {
        public void LaunchTests()
        {
            Test1("/home//sdfg//./qwe/asd//..");
            Test1("/../");
            Test1("/home//foo/");
            Test1("/a/./b/../../c/");
            Test1("/a/../../b/../c//.//");
            Test1("/a//b////c/d//././/..");
        }

        private void Test1(string path)
        {
            var printTable = Helper.CreatePrintTable(
                (nameof(path), path));

            var result = new _0071_SimplifyPath().SimplifyPath(path);

            printTable.AddProcessedParameters(
                (nameof(path), path));

            printTable.AddResult(result);
            Helper.PrintTable(printTable);
        }
    }

    public string SimplifyPath(string path)
    {
        var segments = new List<(int startIndex, int lenght)>();

        for (var i = 1; i < path.Length; i++)
        {
            var slashIndex = FindSlashIndex(path, i);

            var difference = slashIndex > 0 ? slashIndex - i : path.Length - i;
            if (difference == 0)
            {
                //Double slash or first slash found
                //Ignore it
                continue;
            }

            if (difference == 1
                && path[i] == '.')
            {
                //Single period
                //Skip segment
                i += difference;
                continue;
            }

            if (difference == 2
                && path[i] == '.'
                && path[i + 1] == '.')
            {
                //Double period
                //Remove previous segment
                if (segments.Count > 0)
                {
                    segments.RemoveAt(segments.Count - 1);
                }
                i += difference;
                continue;
            }


            segments.Add((i, difference));
            i += difference;
        }

        if (segments.Count == 0)
        {
            return "/";
        }

        var simplifiedPathBuilder = new StringBuilder(path.Length);
        for (var i = 0; i < segments.Count; i++)
        {
            var segment = segments[i];
            simplifiedPathBuilder.Append('/');
            simplifiedPathBuilder.Append(path.AsSpan().Slice(segment.startIndex, segment.lenght));
        }

        var simplifiedPath = simplifiedPathBuilder.ToString();

        return simplifiedPath;
    }

    private int FindSlashIndex(string path, int startIndex)
    {
        for (var i = startIndex; i < path.Length; i++)
        {
            var letter = path[i];

            if (letter == '/')
            {
                return i;
            }
        }

        return -1;
    }
}
