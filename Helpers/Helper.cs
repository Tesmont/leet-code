using System.Reflection;
using System.Text.Json;

namespace Helpers;

public static class Helper
{
    #region Obsolete. Easier to use ChatGPT to create a template

    [Obsolete]
    public static List<(string Name, object? Value)> CreatePrintTable(
        params (string ParameterName, object? Value)[] parameters)
    {
        var printTable = new List<(string Name, object? Value)>();
        foreach (var parameter in parameters)
        {
            printTable.Add((parameter.ParameterName, DeepClone(parameter.Value)));
        }

        return printTable;
    }

    [Obsolete]
    public static List<(string Name, object? Value)> AddProcessedParameters(
        this List<(string Name, object? Value)> printTable,
        params (string ParameterName, object? Value)[] parameters)
    {
        //they can't be changed
        var filteredParameters = parameters
            .Where(p => !_ignoreDefaultBehavior.Contains(p.Value?.GetType() ?? typeof(object)));

        foreach (var parameter in filteredParameters)
        {
            printTable.Add(($"processed {parameter.ParameterName}", parameter.Value));
        }

        return printTable;
    }

    [Obsolete]
    public static List<(string Name, object? Value)> AddResult(
        this List<(string Name, object? Value)> printTable, object? result)
    {
        printTable.Add(("result", result));

        return printTable;
    }

    [Obsolete]
    public static void PrintTable(IEnumerable<(string Name, object? Value)> table)
    {
        IEnumerable<(string Name, string Value)> stringTable = table
            .Select(r => (r.Name, Value: GetStringValue(r.Value)));

        var firstColumnLenght = stringTable
            .Select(t => t.Name)
            .Append("Label")
            .Max(n => n.Length);

        var secondColumnLenght = stringTable
            .Select(t => t.Value)
            .Append("Value")
            .Max(v => v.ToString().Length);
        var tableLenght = firstColumnLenght + secondColumnLenght + 2;

        Console.WriteLine($"{{0,{-firstColumnLenght}}}| {{1}}", "Label", "Value");
        Console.WriteLine(new string('-', tableLenght));

        foreach ((string name, string value) in stringTable)
        {
            Console.WriteLine($"{{0,{-firstColumnLenght}}}| {{1}}", name, value);
        }

        Console.WriteLine(new string('-', tableLenght));
        Console.WriteLine();
    }

    [Obsolete]
    public static T DeepClone<T>(T value)
    {
        switch (value)
        {
            case ValueType:
            case string:
                return value;
            default:
                var json = JsonSerializer.Serialize(value);
                value = JsonSerializer.Deserialize<T>(json)!;
                return value;
        }
    }

    [Obsolete]
    private static string GetStringValue<T>(T value)
    {
        if (_ignoreDefaultBehavior.Contains(typeof(T)))
        {
            return value?.ToString() ?? string.Empty;
        }

        return JsonSerializer.Serialize(value);
    }

    [Obsolete]
    private static HashSet<Type> _ignoreDefaultBehavior = new()
    {
        typeof(char),
        typeof(string),
        typeof(bool),
        typeof(byte),
        typeof(int),
        typeof(long),
    };

    #endregion

    public static void PrintTable(
        IEnumerable<(string Name, string? Value)> parameters,
        IEnumerable<(string Name, string? Value)> processedParameters,
        string? result)
    {
        processedParameters = processedParameters.Select(i => ("processed " + i.Name, i.Value));

        var table = parameters
            .Concat(processedParameters)
            .Append(("result", result));

        PrintTable(table);
    }

    public static void PrintTable(
        IEnumerable<(string Name, string? Value)> parameters,
        IEnumerable<(string Name, string? Value)> processedParameters)
    {
        processedParameters = processedParameters.Select(i => ("processed " + i.Name, i.Value));

        var table = parameters
            .Concat(processedParameters);

        PrintTable(table);
    }

    public static void PrintTable(IEnumerable<(string Name, string? Value)> table)
    {
        var proceseedTable = table
            .Select(i => (i.Name, Value: i.Value ?? "NULL"))
            .ToList();

        var firstColumnLenght = proceseedTable
            .Select(t => t.Name)
            .Append("Name")
            .Max(n => n.Length);

        var tableLenght = firstColumnLenght + 20;

        Console.WriteLine($"{{0,{-firstColumnLenght}}}| {{1}}", "Name", "Value");
        Console.WriteLine(new string('-', tableLenght));

        foreach ((string Name, string Value) in proceseedTable)
        {
            Console.WriteLine($"{{0,{-firstColumnLenght}}}| {{1}}", Name, Value);
        }

        Console.WriteLine(new string('-', tableLenght));
        Console.WriteLine();
    }

    public static void Launch(int number, string[] assemblyNames)
    {
        const string numberTemplate = "0000";
        const string methodName = "LaunchTests";

        var defaultColor = Console.ForegroundColor;

        var numberStr = number.ToString(numberTemplate);
        var classTypes =
            assemblyNames
            .Select(Assembly.LoadFrom)
            .SelectMany(a => a.GetTypes())
            .Where(t => t.IsClass && t.FullName!.Contains($"_{numberStr}_") && t.Name == "Tester")
            .ToList() ?? new();

        if (classTypes.Count != 1)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"INVALID NUMBER: {number}");
            return;
        }

        var classType = classTypes[0];

        var methodInfo = classType.GetMethod(methodName);
        if (methodInfo == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"INVALID CLASS: {classType.Name}");
            return;
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"LAUNCH {classType.Name}");
        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.Gray;
        var instance = Activator.CreateInstance(classType);
        methodInfo.Invoke(instance, null);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine();
        Console.WriteLine($"COMPLETED");

        //Reset the color to the default color. Otherwise it will be saved for future use of the console window.
        Console.ForegroundColor = defaultColor;
    }
}
