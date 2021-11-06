# Case Converter for .NET [![Build status](https://ci.appveyor.com/api/projects/status/sa2aul12onxqf7e1?svg=true)](https://ci.appveyor.com/project/markcastle/caseconverter)  ![AppVeyor tests](https://img.shields.io/appveyor/tests/markcastle/caseconverter)

> “Naming Conventions is one of the two hard things in Computer Science” - Jeff Atwood (Stack Overflow Co-founder)*. 

**This library is designed to make it easier to convert the different case conventions in c# / .net through some simple to use string extension methods.**

Simple string extension library designed to make it easy to convert strings between different cases such as camelCase, snake_case, kebab-case, PascalCase and Train-Case.

This is a .NET STANDARD 2.1 Library

## Installation

NuGet:

	Install-Package CaseConverter

dotnet CLI

	dotnet add package CaseConverter

## Usage

	using CaseConverter;

	Console.WriteLine("Hello World!".ToCamelCase());
    Console.WriteLine("Hello World!".ToSnakeCase());
    Console.WriteLine("Hello World!".ToKebabCase());
    Console.WriteLine("Hello World!".ToPascalCase());
    Console.WriteLine("Hello World!".ToTitleCase());
    Console.WriteLine("Hello World!".ToTrainCase());

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

I make no claims about the speed and efficiency of the included string extensions but welcome any pull requests that make improvements.

## Tests

To run tests:

	dotnet test
 
## Contributing

1. Fork it!
2. Create your feature branch: `git checkout -b my-new-feature`
3. Commit your changes: `git commit -am 'Add some feature'`
4. Push to the branch: `git push origin my-new-feature`
5. Submit a pull request :D

## License
The MIT License (MIT)
See LICENCE file for Licence (MIT Licence)  

© 2021 Captive Reality Ltd.  All Rights Reserved. 
Author: Mark Castle