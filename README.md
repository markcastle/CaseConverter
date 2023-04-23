# Case Converter for .NET  [![Build status](https://ci.appveyor.com/api/projects/status/sa2aul12onxqf7e1?svg=true)](https://ci.appveyor.com/project/markcastle/caseconverter)  ![AppVeyor tests](https://img.shields.io/appveyor/tests/markcastle/caseconverter) ![GitHub](https://img.shields.io/nuget/v/CaseConverter.svg)  ![GitHub](https://img.shields.io/github/license/markcastle/CaseConverter)

> “Naming Conventions is one of the two hard things in Computer Science”
> --- Jeff Atwood (Stack Overflow Co-founder). 

**This library is designed to make it easier to convert the different case conventions in c# / .net through some simple to use string extension methods.**

Simple string extension library designed to make it easy to convert strings between different cases such as camelCase, snake_case, kebab-case, PascalCase, Train-Case and Title Case.

This is a .NET STANDARD 2.0 and .NET STANDARD 2.1 Library

## Installation

NuGet:

	Install-Package CaseConverter

dotnet CLI

	dotnet add package CaseConverter

## Usage

```csharp
	
    using CaseConverter;

    Console.WriteLine("Hello World!".ToCamelCase());
    Console.WriteLine("Hello World!".ToSnakeCase());
    Console.WriteLine("Hello World!".ToKebabCase());
    Console.WriteLine("Hello World!".ToPascalCase());
    Console.WriteLine("Hello World!".ToTitleCase());
    Console.WriteLine("Hello World!".ToTrainCase());
    
  ```

String extensions:

- string.**ToSnakeCase()** Converts any  string to snake_case.
- string.**ToCamelCase()** Converts any string to camelCase optionally removing whitespace.
- string.**ToKebabCase()** Converts any  string to kebab-case.
- string.**ToPascalCase()** Converts any string to PascalCase.
- string.**ToTrainCase()** Converts any  string to Train-Case.
- string.**ToTitleCase()** Converts any  string to Title Case.  *Wrapper for TextInfo.ToTitleCase()*

Supplementary string extensions included: 

- string.**PascalCaseSingleWord()** Convert a single word to Pascal Case.
- string.**InsertCharacterBeforeUpperCase()** Insert any character before all upper space characters in a string.
- string.**InsertSpaceBeforeUpperCase()** Insert a space before all upper space characters in a string.
- string.**SplitCamelCase()** Split a string by Uppercase whilst dealing correctly with acronyms.
- string.**Replace()** Replace specific characters found in a string.
- string.**ReplaceWhitespace()** C Replace all whitespace in a string.
- string.**InsertCharacterBeforeUpperCase()** Converts a string to Title Case.
- string.**IsAllUpper()** Test to determine if a string is all upper case.
- string.**SnakeCaseToCamelCase()** Convert SnakeCase to CamelCase.
- string.**FirstCharToLowerCase()** Convert the first character in a string to lower case.
- string.**FirstCharToUpperCase()** Convert the first character in a string to upper case.

## Tests


We added a lot more tests in the latest version.

To run tests:

	dotnet test

## Benchmarks

For the latest version we're working on improving performance and memory efficiency.. here is a comparison of the improvements.


Additional gains would likely be possible if we stopped targetting .NET STANDARD 2.0 and .NET STANDARD 2.1 and instead targetted .net 6+


#### ToPascalCase()

|                   Method |       Mean |    Error |   StdDev |   Gen0 | Allocated |
|--------------------------|------------|----------|----------|--------|-----------|
|    ToPascalCaseBenchmark |   179.9 ns |  3.00 ns |  2.34 ns | 0.0315 |     264 B |
| ToPascalCaseBenchmarkOld | 2,269.5 ns | 43.25 ns | 36.12 ns | 0.4005 |    3352 B |

#### ToKebabCase()

| Method                    | Mean        | Error     | StdDev    | Gen0    | Allocated |
|---------------------------|-------------|-----------|-----------|---------|-----------|
| ToKebabCaseBenchmark      | 132.1 ns    | 2.69 ns   | 4.02 ns   | 0.0324  | 272 B     |
| ToKebabCaseBenchmarkOld   | 1,423.1 ns  | 27.69 ns  | 27.19 ns  | 0.0496  | 424 B     |

#### ToTitleCase()

|                  Method |     Mean |   Error |  StdDev |   Gen0 | Allocated |
|------------------------ |----------|---------|---------|--------|-----------|
|    ToTitleCaseBenchmark | 218.3 ns | 2.59 ns | 2.43 ns | 0.0200 |     168 B |
| ToTitleCaseBenchmarkOld | 225.8 ns | 3.26 ns | 3.05 ns | 0.0381 |     320 B |

#### ToCamelCase()

|                  Method |     Mean |     Error |    StdDev |   Gen0 | Allocated |
|------------------------ |----------|-----------|-----------|--------|-----------|
|    ToCamelCaseBenchmark | 1.497 us | 0.0206 us | 0.0193 us | 0.1659 |   1.36 KB |
| ToCamelCaseOldBenchmark | 5.362 us | 0.0730 us | 0.0609 us | 0.4272 |   3.52 KB |

#### ToSnakeCase()

Wasn't able to improve it so left the original code intact.

|                  Method |     Mean |     Error |    StdDev |   Gen0 | Allocated |
|------------------------ |----------|-----------|-----------|--------|-----------|
|    ToSnakeCaseBenchmark | 1.765 us | 0.0112 us | 0.0094 us | 0.1793 |   1.47 KB |

#### All Tests

|                     Method |           Job |       Runtime |          Mean |       Error |      StdDev | Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|--------------------------- |-------------- |-------------- |---------------|-------------|-------------|-------|---------|--------|-----------|-------------|
|       ToSnakeCaseBenchmark |      .NET 5.0 |      .NET 5.0 |    199.257 ns |   3.8065 ns |   3.9090 ns |  0.95 |    0.02 | 0.0343 |     288 B |        1.00 |
|       ToSnakeCaseBenchmark |      .NET 6.0 |      .NET 6.0 |    177.983 ns |   3.4400 ns |   3.6807 ns |  0.84 |    0.02 | 0.0343 |     288 B |        1.00 |
|       ToSnakeCaseBenchmark |      .NET 7.0 |      .NET 7.0 |    164.851 ns |   1.4823 ns |   1.3140 ns |  0.78 |    0.01 | 0.0343 |     288 B |        1.00 |
|       ToSnakeCaseBenchmark | .NET Core 3.1 | .NET Core 3.1 |    211.328 ns |   2.4708 ns |   2.0633 ns |  1.00 |    0.00 | 0.0343 |     288 B |        1.00 |
|                            |               |               |               |             |             |       |         |        |           |             |
|       ToCamelCaseBenchmark |      .NET 5.0 |      .NET 5.0 |    115.336 ns |   2.3167 ns |   2.2753 ns |  0.77 |    0.05 | 0.0200 |     168 B |        1.00 |
|       ToCamelCaseBenchmark |      .NET 6.0 |      .NET 6.0 |     82.941 ns |   1.4910 ns |   1.3946 ns |  0.56 |    0.03 | 0.0200 |     168 B |        1.00 |
|       ToCamelCaseBenchmark |      .NET 7.0 |      .NET 7.0 |     86.708 ns |   1.3273 ns |   1.0363 ns |  0.58 |    0.03 | 0.0200 |     168 B |        1.00 |
|       ToCamelCaseBenchmark | .NET Core 3.1 | .NET Core 3.1 |    156.865 ns |   3.6809 ns |  10.8532 ns |  1.00 |    0.00 | 0.0200 |     168 B |        1.00 |
|                            |               |               |               |             |             |       |         |        |           |             |
|       ToKebabCaseBenchmark |      .NET 5.0 |      .NET 5.0 |    188.836 ns |   2.3753 ns |   2.1056 ns |  0.89 |    0.03 | 0.0324 |     272 B |        1.00 |
|       ToKebabCaseBenchmark |      .NET 6.0 |      .NET 6.0 |    129.301 ns |   1.7678 ns |   1.5671 ns |  0.61 |    0.02 | 0.0324 |     272 B |        1.00 |
|       ToKebabCaseBenchmark |      .NET 7.0 |      .NET 7.0 |    127.751 ns |   2.3711 ns |   2.2179 ns |  0.60 |    0.02 | 0.0324 |     272 B |        1.00 |
|       ToKebabCaseBenchmark | .NET Core 3.1 | .NET Core 3.1 |    210.257 ns |   4.2073 ns |   6.0339 ns |  1.00 |    0.00 | 0.0324 |     272 B |        1.00 |
|                            |               |               |               |             |             |       |         |        |           |             |
|      ToPascalCaseBenchmark |      .NET 5.0 |      .NET 5.0 |    278.123 ns |   3.2519 ns |   3.0418 ns |  0.85 |    0.02 | 0.0315 |     264 B |        1.00 |
|      ToPascalCaseBenchmark |      .NET 6.0 |      .NET 6.0 |    189.604 ns |   2.2500 ns |   1.9945 ns |  0.58 |    0.02 | 0.0315 |     264 B |        1.00 |
|      ToPascalCaseBenchmark |      .NET 7.0 |      .NET 7.0 |    170.063 ns |   2.5240 ns |   2.1076 ns |  0.52 |    0.01 | 0.0315 |     264 B |        1.00 |
|      ToPascalCaseBenchmark | .NET Core 3.1 | .NET Core 3.1 |    324.897 ns |   6.4022 ns |   8.0968 ns |  1.00 |    0.00 | 0.0315 |     264 B |        1.00 |
|                            |               |               |               |             |             |       |         |        |           |             |
|       ToTitleCaseBenchmark |      .NET 5.0 |      .NET 5.0 |    281.820 ns |   5.5559 ns |   4.6395 ns |  0.90 |    0.02 | 0.0200 |     168 B |        1.00 |
|       ToTitleCaseBenchmark |      .NET 6.0 |      .NET 6.0 |    506.287 ns |   8.0127 ns |   8.9061 ns |  1.62 |    0.05 | 0.1211 |    1016 B |        6.05 |
|       ToTitleCaseBenchmark |      .NET 7.0 |      .NET 7.0 |    485.576 ns |   8.4432 ns |   8.6705 ns |  1.54 |    0.04 | 0.1211 |    1016 B |        6.05 |
|       ToTitleCaseBenchmark | .NET Core 3.1 | .NET Core 3.1 |    314.564 ns |   4.8291 ns |   4.0325 ns |  1.00 |    0.00 | 0.0200 |     168 B |        1.00 |
|                            |               |               |               |             |             |       |         |        |           |             |
|       ToTrainCaseBenchmark |      .NET 5.0 |      .NET 5.0 |    488.572 ns |   9.3516 ns |   8.7475 ns |  0.90 |    0.02 | 0.0639 |     536 B |        1.00 |
|       ToTrainCaseBenchmark |      .NET 6.0 |      .NET 6.0 |    343.272 ns |   4.4961 ns |   4.2056 ns |  0.63 |    0.02 | 0.0639 |     536 B |        1.00 |
|       ToTrainCaseBenchmark |      .NET 7.0 |      .NET 7.0 |    302.115 ns |   5.8996 ns |   6.5574 ns |  0.56 |    0.02 | 0.0639 |     536 B |        1.00 |
|       ToTrainCaseBenchmark | .NET Core 3.1 | .NET Core 3.1 |    542.426 ns |  10.8240 ns |  10.6306 ns |  1.00 |    0.00 | 0.0639 |     536 B |        1.00 |
|                            |               |               |               |             |             |       |         |        |           |             |
|        IsAllUpperBenchmark |      .NET 5.0 |      .NET 5.0 |      6.971 ns |   0.1332 ns |   0.1480 ns |  0.74 |    0.02 |      - |         - |          NA |
|        IsAllUpperBenchmark |      .NET 6.0 |      .NET 6.0 |      5.091 ns |   0.1288 ns |   0.1533 ns |  0.54 |    0.02 |      - |         - |          NA |
|        IsAllUpperBenchmark |      .NET 7.0 |      .NET 7.0 |      4.166 ns |   0.0988 ns |   0.1057 ns |  0.44 |    0.01 |      - |         - |          NA |
|        IsAllUpperBenchmark | .NET Core 3.1 | .NET Core 3.1 |      9.476 ns |   0.0494 ns |   0.0385 ns |  1.00 |    0.00 |      - |         - |          NA |
|                            |               |               |               |             |             |       |         |        |           |             |
| ReplaceWhitespaceBenchmark |      .NET 5.0 |      .NET 5.0 |  7,583.997 ns | 132.7825 ns | 124.2049 ns |  0.40 |    0.01 | 0.0839 |     728 B |        0.06 |
| ReplaceWhitespaceBenchmark |      .NET 6.0 |      .NET 6.0 |  7,196.590 ns | 125.6170 ns | 117.5022 ns |  0.38 |    0.01 | 0.0839 |     728 B |        0.06 |
| ReplaceWhitespaceBenchmark |      .NET 7.0 |      .NET 7.0 |  7,353.717 ns | 144.7446 ns | 148.6420 ns |  0.39 |    0.02 | 0.0839 |     728 B |        0.06 |
| ReplaceWhitespaceBenchmark | .NET Core 3.1 | .NET Core 3.1 | 18,699.030 ns | 362.7740 ns | 542.9830 ns |  1.00 |    0.00 | 1.4343 |   12168 B |        1.00 |

If you can suggest further improvements please get in touch or better still make the improvements and send us a PR :-)
 
## Contributing

1. Fork it!
2. Create your feature branch: `git checkout -b my-new-feature`
3. Commit your changes: `git commit -am 'Add some feature'`
4. Push to the branch: `git push origin my-new-feature`
5. Submit a pull request :D

## License
The MIT License (MIT)
See LICENCE file for Licence (MIT Licence)  

© 2021-2023 Captive Reality Ltd.  All Rights Reserved. 
Author: Mark Castle