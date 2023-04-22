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

|                     Method |         Mean |       Error |      StdDev |   Gen0 | Allocated |
|--------------------------- |-------------:|------------:|------------:|-------:|----------:|
|       ToSnakeCaseBenchmark |   172.143 ns |   3.2836 ns |   3.2249 ns | 0.0343 |     288 B |
|       ToCamelCaseBenchmark |    80.951 ns |   1.5001 ns |   1.3298 ns | 0.0200 |     168 B |
|       ToKebabCaseBenchmark |   129.666 ns |   2.4154 ns |   2.6847 ns | 0.0324 |     272 B |
|      ToPascalCaseBenchmark |   191.285 ns |   3.7843 ns |   3.8862 ns | 0.0315 |     264 B |
|       ToTitleCaseBenchmark |   210.939 ns |   4.0187 ns |   4.3000 ns | 0.0200 |     168 B |
|       ToTrainCaseBenchmark |   346.119 ns |   4.3459 ns |   4.0651 ns | 0.0639 |     536 B |
|        IsAllUpperBenchmark |     5.075 ns |   0.0638 ns |   0.0533 ns |      - |         - |
| ReplaceWhitespaceBenchmark | 7,099.933 ns | 113.6132 ns | 100.7152 ns | 0.0839 |     728 B |

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