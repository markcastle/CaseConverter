using BenchmarkDotNet.Attributes;

namespace CaseConverter.Benchmarks;

[MemoryDiagnoser]
public class CaseConverterBenchmarks
{
    private const string TestString = "ThisIsATestString";
    private const string TestString2 = "thisisateststring";

    private const string LongTestString =
        "This method appears to be efficient already as it utilizes regular expressions, which are highly performant for string operations such as this. However, if you would like an alternative approach that remains compatible with .NET Standard 2.0 and 2.1, you can use a StringBuilder to build a new string while iterating over the input string's characters:";

    [Benchmark]
    public string ToSnakeCaseBenchmark()
    {
        return TestString.ToSnakeCase();
    }

    [Benchmark]
    public string ToCamelCaseBenchmark()
    {
        return TestString.ToCamelCase();
    }

    [Benchmark]
    public string ToKebabCaseBenchmark()
    {
        return TestString.ToKebabCase();
    }

    [Benchmark]
    public string ToPascalCaseBenchmark()
    {
        return TestString2.ToPascalCase();
    }

    [Benchmark]
    public string ToTitleCaseBenchmark()
    {
        return TestString.ToTitleCase();
    }

    [Benchmark]
    public string ToTrainCaseBenchmark()
    {
        return TestString.ToTrainCase();
    }

    [Benchmark]
    public bool IsAllUpperBenchmark()
    {
        return TestString.IsAllUpper();
    }

    [Benchmark]
    public string ReplaceWhitespaceBenchmark()
    {
        return LongTestString.ReplaceWhitespace(".");
    }
    
}