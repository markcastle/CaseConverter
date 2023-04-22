using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CaseConverter.Tests
{
    [TestClass]
    public class ToTitleCaseTests
    {
        [TestMethod]
        public void TestToTitleCase()
        {
            string input = "this is a test";
            string expectedOutput = "This Is A Test";
            string actualOutput = input.ToTitleCase();
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestToTitleCaseWithHyphen()
        {
            string input = "this-is-a-test";
            string expectedOutput = "This-Is-A-Test";
            string actualOutput = input.ToTitleCase();
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestToTitleCaseWithUnderscore()
        {
            string input = "this_is_a_test";
            string expectedOutput = "This_Is_A_Test";
            string actualOutput = input.ToTitleCase();
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestEmptyString()
        {
            string input = "";
            string expectedOutput = "";
            string actualOutput = input.ToTitleCase();
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestAllUpperCase()
        {
            string input = "THIS IS A TEST";
            string expectedOutput = "This Is A Test";
            string actualOutput = input.ToTitleCase();
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestAllLowerCase()
        {
            string input = "this is a test";
            string expectedOutput = "This Is A Test";
            string actualOutput = input.ToTitleCase();
            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}
