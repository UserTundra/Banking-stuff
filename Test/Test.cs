using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wallet;

namespace Test
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void CreateTest()
        {
            Money money = new Money();
            Assert.AreEqual(0, money.getKeys());

        }


        [TestMethod]
        public void AddTest()
        {
            Money money = new Money();
            money.add("rub", 100);
            money.add("euro", 300);
            Assert.AreEqual(2, money.getKeys());
            Assert.AreEqual(100, money.getValues("rub"));
            Assert.AreEqual(300, money.getValues("euro"));
        }

        [TestMethod]
        public void AddTest2()
        {
            Money money = new Money();
            money.add("rub", 100);
            money.add("rub", 300);
            Assert.AreEqual(1, money.getKeys());
            Assert.AreEqual(400, money.getValues("rub"));
        }

    }
}
