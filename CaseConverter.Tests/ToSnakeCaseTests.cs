using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CaseConverter.Tests
{
    [TestClass]
    public class ToSnakeCaseTests
    {
        [TestMethod]
        public void TestBasicString()
        {
            string input = "hello world";
            string expectedOutput = "hello_world";
            string actualOutput = input.ToSnakeCase();
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestCamelCaseString()
        {
            string input = "helloWorld";
            string expectedOutput = "hello_world";
            string actualOutput = input.ToSnakeCase();
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestPascalCaseString()
        {
            string input = "HelloWorld";
            string expectedOutput = "hello_world";
            string actualOutput = input.ToSnakeCase();
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestSpaceSeparatorString()
        {
            string input = "hello   world";
            string expectedOutput = "hello_world";
            string actualOutput = input.ToSnakeCase();
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestHyphenSeparatorString()
        {
            string input = "hello-world";
            string expectedOutput = "hello_world";
            string actualOutput = input.ToSnakeCase();
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestEmptyString()
        {
            string input = "";
            string expectedOutput = "";
            string actualOutput = input.ToSnakeCase();
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestAllUpperCase()
        {
            string input = "HELLO_WORLD";
            string expectedOutput = "hello_world";
            string actualOutput = input.ToSnakeCase();
            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}
