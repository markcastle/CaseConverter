using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CaseConverter.Tests
{
    [TestClass]
    public class InsertCharacterBeforeUpperCaseTests
    {
        [TestMethod]
        public void TestInsertSpaceBeforeUpperCase()
        {
            string input = "InsertCharacterBeforeUpperCase";
            string expectedOutput = "Insert Character Before Upper Case";
            string actualOutput = input.InsertCharacterBeforeUpperCase();
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestInsertUnderscoreBeforeUpperCase()
        {
            string input = "InsertCharacterBeforeUpperCase";
            string expectedOutput = "Insert_Character_Before_Upper_Case";
            string actualOutput = input.InsertCharacterBeforeUpperCase('_');
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestEmptyString()
        {
            string input = "";
            string expectedOutput = "";
            string actualOutput = input.InsertCharacterBeforeUpperCase();
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestAllLowerCase()
        {
            string input = "insertcharacterbeforeuppercase";
            string expectedOutput = "insertcharacterbeforeuppercase";
            string actualOutput = input.InsertCharacterBeforeUpperCase();
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestAllUpperCase()
        {
            string input = "INSERTCHARACTERBEFOREUPPERCASE";
            string expectedOutput = "I N S E R T C H A R A C T E R B E F O R E U P P E R C A S E";
            string actualOutput = input.InsertCharacterBeforeUpperCase();
            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}
