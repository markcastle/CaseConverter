using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CaseConverter.Tests
{
    [TestClass]
    public class ToPascalCaseTests
    {
        [TestMethod]
        public void TestToPascalCase()
        {
            string input = "this is a test";
            string expectedOutput = "ThisIsATest";
            string actualOutput = input.ToPascalCase();
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestToPascalCaseWithSpaces()
        {
            string input = "this   is a  test";
            string expectedOutput = "ThisIsATest";
            string actualOutput = input.ToPascalCase();
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestToPascalCaseWithUnderscores()
        {
            string input = "this_is_a_test";
            string expectedOutput = "ThisIsATest";
            string actualOutput = input.ToPascalCase();
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestToPascalCaseWithHyphens()
        {
            string input = "this-is-a-test";
            string expectedOutput = "ThisIsATest";
            string actualOutput = input.ToPascalCase();
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestEmptyString()
        {
            string input = "";
            string expectedOutput = "";
            string actualOutput = input.ToPascalCase();
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestAllUpperCase()
        {
            string input = "THIS IS A TEST";
            string expectedOutput = "ThisIsATest";
            string actualOutput = input.ToPascalCase();
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestAllLowerCase()
        {
            string input = "this is a test";
            string expectedOutput = "ThisIsATest";
            string actualOutput = input.ToPascalCase();
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestCamelCase()
        {
            string input = "thisIsATest";
            string expectedOutput = "ThisIsATest";
            string actualOutput = input.ToPascalCase();
            Assert.AreEqual(expectedOutput, actualOutput);

        }
    }
}