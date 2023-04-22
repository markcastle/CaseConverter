using BenchmarkDotNet.Attributes;
using CaseConverter;

namespace CaseConverter.Benchmarks;

[MemoryDiagnoser]
public class CaseConverterBenchmarks
{
    private const string TestString = "ThisIsATestString";
    private const string TestString2 = "thisisateststring";

    //[Benchmark]
    //public string ToSnakeCaseBenchmark()
    //{
    //    return TestString.ToSnakeCase();
    //}

    //[Benchmark]
    //public string ToCamelCaseBenchmark()
    //{
    //    return TestString.ToCamelCase();
    //}

    [Benchmark]
    public string ToKebabCaseBenchmark()
    {
        return TestString.ToKebabCase();
    }
    
    [Benchmark]
    public string ToKebabCaseBenchmarkOld()
    {
        return TestString.ToKebabCaseOld();
    }

    [Benchmark]
    public string ToPascalCaseBenchmark()
    {
        return TestString2.ToPascalCase();
    }

    [Benchmark]
    public string ToPascalCaseBenchmarkOld()
    {
        return TestString2.ToPascalCaseOld();
    }

    //[Benchmark]
    //public string ToTitleCaseBenchmark()
    //{
    //    return TestString.ToTitleCase();
    //}

    //[Benchmark]
    //public string ToTrainCaseBenchmark()
    //{
    //    return TestString.ToTrainCase();
    //}
}