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
            Assert.AreEqual(100, money.getMoney("rub"));
            Assert.AreEqual(300, money.getMoney("euro"));
        }

        [TestMethod]
        public void AddTest2()
        {
            Money money = new Money();
            money.add("rub", 100);
            money.add("rub", 300);
            Assert.AreEqual(1, money.getKeys());
            Assert.AreEqual(400, money.getMoney("rub"));
        }

        [TestMethod]
        public void RemoveTest()
        {
            Money money = new Money();
            money.add("rub", 100);
            money.remove("rub", 50);

            money.add("euro", 1000);
            money.remove("euro", 50);
            Assert.AreEqual(2, money.getKeys());
            Assert.AreEqual(50, money.getMoney("rub"));
            Assert.AreEqual(950, money.getMoney("euro"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveTest2()
        {
            Money money = new Money();
            money.add("rub", 100);
            money.remove("rub", 500);
            Assert.Fail();
        }

        [TestMethod]
        public void RemoveTest3()
        {
            Money money = new Money();
            money.add("rub", 100);
            money.remove("rub", 100);
            Assert.AreEqual(0, money.getKeys());
        }

        [TestMethod]
        public void GetMoneyTest()
        {
            Money money = new Money();
            Assert.AreEqual(0, money.getMoney("rub"));
        }
    }
}
