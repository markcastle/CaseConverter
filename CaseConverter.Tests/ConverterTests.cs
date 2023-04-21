using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CaseConverter.Tests
{
    [TestClass]
    public class ConverterTests
    {
        [TestMethod]
        public void Test_ToSnakeCase()
        {
            string test = "___test_SnakeCase123";
            Console.WriteLine(test.ToSnakeCase());

            Assert.IsTrue("TestSC".ToSnakeCase() == "test_sc");
            Assert.IsTrue("testSC".ToSnakeCase() == "test_sc");
            Assert.IsTrue("TestSnakeCase".ToSnakeCase() == "test_snake_case");
            Assert.IsTrue("testSnakeCase ".ToSnakeCase() == "test_snake_case");
            Assert.IsTrue("TestSnakeCase123".ToSnakeCase() == "test_snake_case123");
            Assert.IsTrue("_testSnakeCase123".ToSnakeCase() == "_test_snake_case123");
            Assert.IsTrue("test_SC".ToSnakeCase() == "test_sc");
            Assert.IsTrue("___test_SnakeCase123".ToSnakeCase() == "___test_snake_case123");

        }

        [TestMethod]
        public void Test_ToCamelCase()
        {
            string test = "____test_sc";
            Console.WriteLine(test.ToCamelCase());

            // For Comparison with... System.Text.Json.JsonNamingPolicy.CamelCase.ConvertName
            // Console.WriteLine(System.Text.Json.JsonNamingPolicy.CamelCase.ConvertName(test));

            Assert.IsTrue("TestSC".ToCamelCase() == "testSC");
            Assert.IsTrue("testSC".ToCamelCase() == "testSC");
            Assert.IsTrue("TestCamelCase".ToCamelCase() == "testCamelCase");
            Assert.IsTrue("test_camel_case".ToCamelCase() == "testCamelCase");
            Assert.IsTrue("test_camel_case123".ToCamelCase() == "testCamelCase123");
            Assert.IsTrue("_test_camel_case123".ToCamelCase() == "testCamelCase123");
            Assert.IsTrue("test_sc".ToCamelCase() == "testSc");
            Assert.IsTrue("____test_sc".ToCamelCase() == "testSc");
            Assert.IsTrue("____test_sc".ToCamelCase(true, true) == "_testSc");

            // Some tests from https://www.30secondsofcode.org/js/s/to-camel-case
            Assert.IsTrue("Some label that needs to be camelized".ToCamelCase() == "someLabelThatNeedsToBeCamelized");
            Assert.IsTrue("some_database_field_name".ToCamelCase() == "someDatabaseFieldName");
            Assert.IsTrue("some-javascript-property".ToCamelCase() == "someJavascriptProperty");
            Assert.IsTrue("some-mixed_string with spaces_underscores-and-hyphens".ToCamelCase() == "someMixedStringWithSpacesUnderscoresAndHyphens");

        }


        [TestMethod]
        public void Test_ToTitleCase()
        {
            const string test = "test_sc";
            Console.WriteLine(test.ToTitleCase());

            Assert.IsTrue("testSC".ToTitleCase() == "Testsc");
            Assert.IsTrue("this is a test".ToTitleCase() == "This Is A Test");
            Assert.IsTrue("test_snake_case".ToTitleCase() == "Test_Snake_Case");
            Assert.IsTrue("testSnakeCase".ToTitleCase() == "Testsnakecase");
            Assert.IsTrue("test_snake_case123".ToTitleCase() == "Test_Snake_Case123");
            Assert.IsTrue("_test_snake_case123_testSnakeCase123".ToTitleCase() == "_Test_Snake_Case123_Testsnakecase123");
            Assert.IsTrue("test_sc".ToTitleCase() == "Test_Sc");
        }

        [TestMethod]
        public void Test_ToPascalCase()
        {
            const string test = "test_sc";
            Console.WriteLine(test.ToPascalCase());

            Assert.IsTrue("this is a test".ToPascalCase() == "ThisIsATest");

            Assert.IsTrue("TestSC".ToPascalCase() == "TestSc");
            Assert.IsTrue("testSC".ToPascalCase() == "TestSc");
            Assert.IsTrue("test_snake_case".ToPascalCase() == "TestSnakeCase");
            Assert.IsTrue("testSnakeCase ".ToPascalCase() == "TestSnakeCase");
            Assert.IsTrue("test_snake_case123".ToPascalCase() == "TestSnakeCase123");
            Assert.IsTrue("_test_snake_case123_testSnakeCase123".ToPascalCase() == "TestSnakeCase123TestSnakeCase123");
            Assert.IsTrue("test_sc".ToPascalCase() == "TestSc");

        }

        [TestMethod]
        public void Test_ToKebabCase()
        {
            const string test = "IAmEditingSomeXMLAndHTML";
            Console.WriteLine(test.SplitCamelCase("-").ToLower());

            // For Comparison with... System.Text.Json.JsonNamingPolicy.CamelCase.ConvertName
            // Console.WriteLine(System.Text.Json.JsonNamingPolicy.CamelCase.ConvertName(test));

            // Some tests from https://www.30secondsofcode.org/js/s/to-kebab-case
            Assert.IsTrue("camelCase".ToKebabCase() == "camel-case");
            Assert.IsTrue("some text".ToKebabCase() == "some-text");
            Assert.IsTrue("some-mixed_string With spaces_underscores-and-hyphens".ToKebabCase() == "some-mixed-string-with-spaces-underscores-and-hyphens");
            Assert.IsTrue("AllThe-small Things".ToKebabCase() == "all-the-small-things");
            Assert.IsTrue("IAmEditingSomeXMLAndHTML".ToKebabCase() == "i-am-editing-some-xml-and-html");

        }

        [TestMethod]
        public void Test_TestAll()
        {

            const string plainEnglish = "The quick brown fox";
            const string titleCase = "The Quick Brown Fox";
            const string plainEnglishAllUpperCase = "THE QUICK BROWN FOX"; //  not working yet
            const string constantCase = "THE_QUICK_BROWN_FOX"; //  not working yet
            const string camelCase = "theQuickBrownFox";
            const string pascalCase = "TheQuickBrownFox";
            const string snakeCase = "the_quick_brown_fox";
            const string kebabCase = "the-quick-brown-fox";
            const string trainCase = "The-Quick-Brown-Fox";

            Console.WriteLine(plainEnglishAllUpperCase.ToKebabCase());

            // from Title English
            Assert.IsTrue(titleCase.ToCamelCase() == camelCase);
            Assert.IsTrue(titleCase.ToPascalCase() == pascalCase);
            Assert.IsTrue(titleCase.ToSnakeCase() == snakeCase);
            Assert.IsTrue(titleCase.ToKebabCase() == kebabCase);
            Assert.IsTrue(titleCase.ToTrainCase() == trainCase);

            // from camelCase
            Assert.IsTrue(camelCase.ToCamelCase() == camelCase);
            Assert.IsTrue(camelCase.ToKebabCase() == kebabCase);
            Assert.IsTrue(camelCase.ToPascalCase() == pascalCase);
            Assert.IsTrue(camelCase.ToSnakeCase() == snakeCase);
            Assert.IsTrue(camelCase.ToTrainCase() == trainCase);

            // from kebab-case
            Assert.IsTrue(kebabCase.ToCamelCase() == camelCase);
            Assert.IsTrue(kebabCase.ToKebabCase() == kebabCase);
            Assert.IsTrue(kebabCase.ToPascalCase() == pascalCase);
            Assert.IsTrue(kebabCase.ToSnakeCase() == snakeCase);
            Assert.IsTrue(kebabCase.ToTrainCase() == trainCase);

            // from PascalCase
            Assert.IsTrue(pascalCase.ToCamelCase() == camelCase);
            Assert.IsTrue(pascalCase.ToKebabCase() == kebabCase);
            Assert.IsTrue(pascalCase.ToPascalCase() == pascalCase);
            Assert.IsTrue(pascalCase.ToSnakeCase() == snakeCase);
            Assert.IsTrue(pascalCase.ToTrainCase() == trainCase);

            // from snake_case
            Assert.IsTrue(snakeCase.ToCamelCase() == camelCase);
            Assert.IsTrue(snakeCase.ToKebabCase() == kebabCase);
            Assert.IsTrue(snakeCase.ToPascalCase() == pascalCase);
            Assert.IsTrue(snakeCase.ToSnakeCase() == snakeCase);
            Assert.IsTrue(snakeCase.ToTrainCase() == trainCase);

            // from Train-Case
            Assert.IsTrue(trainCase.ToCamelCase() == camelCase);
            Assert.IsTrue(trainCase.ToKebabCase() == kebabCase);
            Assert.IsTrue(trainCase.ToPascalCase() == pascalCase);
            Assert.IsTrue(trainCase.ToSnakeCase() == snakeCase);
            Assert.IsTrue(trainCase.ToTrainCase() == trainCase);

            // from Plain English
            Assert.IsTrue(plainEnglish.ToCamelCase() == camelCase);
            Assert.IsTrue(plainEnglish.ToPascalCase() == pascalCase);
            Assert.IsTrue(plainEnglish.ToSnakeCase() == snakeCase);
            Assert.IsTrue(plainEnglish.ToKebabCase() == kebabCase);
            Assert.IsTrue(plainEnglish.ToTrainCase() == trainCase);

            // from Plain English (All upper case)
            Assert.IsTrue(plainEnglishAllUpperCase.ToCamelCase() == camelCase);
            Assert.IsTrue(plainEnglishAllUpperCase.ToPascalCase() == pascalCase);
            Assert.IsTrue(plainEnglishAllUpperCase.ToSnakeCase() == snakeCase);
            Assert.IsTrue(plainEnglishAllUpperCase.ToKebabCase() == kebabCase);
            Assert.IsTrue(plainEnglishAllUpperCase.ToTrainCase() == trainCase);

            // from CONSTANT_CASE (All upper case with underscore between words)
            Assert.IsTrue(constantCase.ToCamelCase() == camelCase);
            Assert.IsTrue(constantCase.ToPascalCase() == pascalCase);
            Assert.IsTrue(constantCase.ToSnakeCase() == snakeCase);
            Assert.IsTrue(constantCase.ToKebabCase() == kebabCase);
            Assert.IsTrue(constantCase.ToTrainCase() == trainCase);

        }

        [TestMethod]
        public void Test_GeneralTests()
        {
            Assert.IsTrue("THIS IS AN UPPER CASE STRING".IsAllUpper());
            Assert.IsTrue("THISISANUPPERCASESTRING".IsAllUpper());
            Assert.IsTrue("THIS-IS-AN-UPPER-CASE-STRING".IsAllUpper());
            Assert.IsTrue("THIS_IS_AN_UPPER_CASE_STRING".IsAllUpper());

            Assert.IsTrue("word".PascalCaseSingleWord() == "Word");
            Assert.IsTrue("pseudopseudohypoparathyroidism".PascalCaseSingleWord() == "Pseudopseudohypoparathyroidism");
            Assert.IsTrue("PSEUDOPSEUDOHYPOPARATHYROIDISM".PascalCaseSingleWord() == "Pseudopseudohypoparathyroidism");

            Assert.IsTrue("WordsAreAllYouNeed".InsertCharacterBeforeUpperCase() == "Words Are All You Need");
            Assert.IsTrue("WordsAreAllYouNeed".InsertCharacterBeforeUpperCase('+') == "Words+Are+All+You+Need");
            Assert.IsTrue("WordsAreAllYouNeed".InsertSpaceBeforeUpperCase() == "Words Are All You Need");

            // Remove all "punctuation" characters from the string
            char[] separators = new char[] { ' ', ';', ',', '-', '_', '.' };
            Assert.IsTrue("string. With. Punctuation;".Replace(separators, "-") == "string-With-Punctuation");

            Console.WriteLine("string. With. Punctuation;".Replace(separators, "-"));

            Console.WriteLine("string. With. Punctuation;".ReplaceWhitespace("+"));
            Assert.IsTrue("string. With. Punctuation;".ReplaceWhitespace("+") == "string.+With.+Punctuation;");

            Assert.IsTrue("PSEUDOPSEUDOHYPOPARATHYROIDISM".IsAllUpper());

            Assert.IsFalse("pseudopseudohypoparathyroidism".IsAllUpper());

            Assert.IsTrue("this_is_a_snake_case_string".SnakeCaseToCamelCase() == "thisIsASnakeCaseString");

            Assert.IsTrue("WordsAreAllYouNeed".FirstCharToLowerCase() == "wordsAreAllYouNeed");

            Assert.IsTrue("wordsAreAllYouNeed".FirstCharToUpperCase() == "WordsAreAllYouNeed");

        }
    }
}


