using Helpers;
using System.Text.Json;

namespace TopInterview150.ArrayString;

internal class _0013_RomanToInteger
{
    internal class Tester
    {
        public void LaunchTests()
        {
            var s = "MCMXCIV";
            Test(s);
        }

        private void Test(string s)
        {
            List<(string Name, string? Value)> parameters = new()
            {
                (nameof(s), JsonSerializer.Serialize(s))
            };

            var result = new _0013_RomanToInteger().RomanToInt(s);

            List<(string Name, string? Value)> processedParameters = new()
            {
                (nameof(s), JsonSerializer.Serialize(s))
            };

            var resultStr = JsonSerializer.Serialize(result);

            Helper.PrintTable(parameters, processedParameters, resultStr);
        }
    }

    public unsafe struct MappedValue
    {
        public int Value;
        public MappedValue* Map;
    }

    public unsafe int RomanToInt(string s)
    {
        MappedValue* map = stackalloc MappedValue['X' + 1];
        MappedValue* vxMap = stackalloc MappedValue['X' + 1];
        MappedValue* lcMap = stackalloc MappedValue['X' + 1];
        MappedValue* dmMap = stackalloc MappedValue['X' + 1];

        map['I'] = new MappedValue() { Value = 1, Map = map };
        map['V'] = new MappedValue() { Value = 5, Map = vxMap };
        map['X'] = new MappedValue() { Value = 10, Map = vxMap };
        map['L'] = new MappedValue() { Value = 50, Map = lcMap };
        map['C'] = new MappedValue() { Value = 100, Map = lcMap };
        map['D'] = new MappedValue() { Value = 500, Map = dmMap };
        map['M'] = new MappedValue() { Value = 1000, Map = dmMap };

        vxMap['I'] = new MappedValue() { Value = -1, Map = map };
        vxMap['V'] = map['V'];
        vxMap['X'] = map['X'];
        vxMap['L'] = map['L'];
        vxMap['C'] = map['C'];
        vxMap['D'] = map['D'];
        vxMap['M'] = map['M'];

        lcMap['I'] = map['I'];
        lcMap['V'] = map['V'];
        lcMap['X'] = new MappedValue { Value = -10, Map = map };
        lcMap['L'] = map['L'];
        lcMap['C'] = map['C'];
        lcMap['D'] = map['D'];
        lcMap['M'] = map['M'];

        dmMap['I'] = map['I'];
        dmMap['V'] = map['V'];
        dmMap['X'] = map['X'];
        dmMap['L'] = map['L'];
        dmMap['C'] = new MappedValue { Value = -100, Map = map };
        dmMap['D'] = map['D'];
        dmMap['M'] = map['M'];

        var result = 0;
        var currentMap = map;
        for (var i = s.Length - 1; i >= 0; i--)
        {
            var ch = s[i];
            var mappedValue = currentMap[ch];

            result += mappedValue.Value;
            currentMap = mappedValue.Map;
        }

        return result;
    }

    public int RomanToInt2(string s)
    {
        Span<int> map = stackalloc int['X' + 1];
        map['I'] = 1;
        map['V'] = 5;
        map['X'] = 10;
        map['L'] = 50;
        map['C'] = 100;
        map['D'] = 500;
        map['M'] = 1000;

        var result = 0;
        var prevValue = 0;

        for (var i = s.Length - 1; i >= 0; i--)
        {
            var ch = s[i];
            var value = map[ch];

            if (value < prevValue)
            {
                result -= value;
            }
            else
            {
                result += value;
            }

            prevValue = value;
        }

        return result;
    }
}
