using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wallet;

namespace Test
{
    [TestClass]
    public class TestBank
    {
        Bank bank;

        [TestInitialize]
        public void TestInitialize()
        {
            bank = new Bank();
        }

        [TestMethod]
        public void ConvertTestRubToUsd()
        {
            int value = bank.Convert("rub", "usd", 12300);
            Assert.AreEqual(192, value);
        }

        [TestMethod]
        public void ConvertTestUsdToEur()
        {
            int value2 = bank.Convert("usd", "eur", 500);
            Assert.AreEqual(411, value2);
        }

        [TestMethod]
        public void ConvertTestEurToTenge()
        {
            int value2 = bank.Convert("eur", "tenge", 100);
            Assert.AreEqual(38000, value2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConvertTestUsdToEur2()
        {
            int value3 = bank.Convert("usd", "eur", -2);
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void ConvertTestExcepted()
        {
            int value = bank.Convert("uan", "usd", 9);
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConvertTestTengeToRub()
        {
            int value3 = bank.Convert("tenge", "rub", 0);
            Assert.Fail();
        }
    }
}
