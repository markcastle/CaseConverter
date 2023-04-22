using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CaseConverter.Tests
{
    [TestClass]
    public class ToCamelCaseTests
    {
        [TestMethod]
        public void TestBasicString()
        {
            string input = "hello world";
            string expectedOutput = "helloWorld";
            string actualOutput = input.ToCamelCase();
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestHyphenatedString()
        {
            string input = "hello-world";
            string expectedOutput = "helloWorld";
            string actualOutput = input.ToCamelCase();
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestUnderscoreString()
        {
            string input = "hello_world";
            string expectedOutput = "helloWorld";
            string actualOutput = input.ToCamelCase();
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestPreserveLeadingUnderscore()
        {
            string input = "_hello_world";
            string expectedOutput = "_helloWorld";
            string actualOutput = input.ToCamelCase(preserveLeadingUnderscore: true);
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestRemoveWhitespace()
        {
            string input = "hello   world";
            string expectedOutput = "helloWorld";
            string actualOutput = input.ToCamelCase(removeWhitespace: true);
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestPreserveWhitespace()
        {
            string input = "hello   world";
            string expectedOutput = "hello   world";
            string actualOutput = input.ToCamelCase(removeWhitespace: false);
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestEmptyString()
        {
            string input = "";
            string expectedOutput = "";
            string actualOutput = input.ToCamelCase();
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestAllUpperCase()
        {
            string input = "HELLO_WORLD";
            string expectedOutput = "helloWorld";
            string actualOutput = input.ToCamelCase();
            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}
