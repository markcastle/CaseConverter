using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseConverter.Tests
{
    [TestClass]
    public class ToKebabCaseTests
    {
        [TestMethod]
        public void TestToKebabCase()
        {
            string input = "This is a test";
            string expectedOutput = "this-is-a-test";
            string actualOutput = input.ToKebabCase();
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestToKebabCaseWithSpaces()
        {
            string input = "This   is a  test";
            string expectedOutput = "this-is-a-test";
            string actualOutput = input.ToKebabCase();
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestToKebabCaseWithUnderscores()
        {
            string input = "this_is_a_test";
            string expectedOutput = "this-is-a-test";
            string actualOutput = input.ToKebabCase();
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestToKebabCaseWithHyphens()
        {
            string input = "this-is-a-test";
            string expectedOutput = "this-is-a-test";
            string actualOutput = input.ToKebabCase();
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestEmptyString()
        {
            string input = "";
            string expectedOutput = "";
            string actualOutput = input.ToKebabCase();
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestAllUpperCase()
        {
            string input = "THIS IS A TEST";
            string expectedOutput = "this-is-a-test";
            string actualOutput = input.ToKebabCase();
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestAllLowerCase()
        {
            string input = "this is a test";
            string expectedOutput = "this-is-a-test";
            string actualOutput = input.ToKebabCase();
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestPascalCase()
        {
            string input = "ThisIsATest";
            string expectedOutput = "this-is-a-test";
            string actualOutput = input.ToKebabCase();
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestCamelCase()
        {
            string input = "thisIsATest";
            string expectedOutput = "this-is-a-test";
            string actualOutput = input.ToKebabCase();
            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}
