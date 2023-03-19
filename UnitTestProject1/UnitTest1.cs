using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void InputParser()
        {
            string excpected = "Департамент закупок:".Split(' ')[0];
            string actual = MadeDepartament
                .InputParser(
                    "Департамент закупок: 9*manager1, 3*manager2, 2*manager3, 2*marketer1 + руководитель департамента manager2")
                .Split(' ')[0];
            Assert.AreEqual(excpected, actual);

        }
    }
}
