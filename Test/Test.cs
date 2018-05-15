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
            Assert.AreEqual(0, money.GetKeys());

        }


        [TestMethod]
        public void AddTest()
        {
            Money money = new Money();
            money.Add("rub", 100);
            money.Add("euro", 300);
            Assert.AreEqual(2, money.GetKeys());
            Assert.AreEqual(100, money.GetMoney("rub"));
            Assert.AreEqual(300, money.GetMoney("euro"));
        }

        [TestMethod]
        public void AddTest2()
        {
            Money money = new Money();
            money.Add("rub", 100);
            money.Add("rub", 300);
            Assert.AreEqual(1, money.GetKeys());
            Assert.AreEqual(400, money.GetMoney("rub"));
        }

        [TestMethod]
        public void RemoveTest()
        {
            Money money = new Money();
            money.Add("rub", 100);
            money.Remove("rub", 50);

            money.Add("euro", 1000);
            money.Remove("euro", 50);
            Assert.AreEqual(2, money.GetKeys());
            Assert.AreEqual(50, money.GetMoney("rub"));
            Assert.AreEqual(950, money.GetMoney("euro"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveTest2()
        {
            Money money = new Money();
            money.Add("rub", 100);
            money.Remove("rub", 500);
            Assert.Fail();
        }

        [TestMethod]
        public void RemoveTest3()
        {
            Money money = new Money();
            money.Add("rub", 100);
            money.Remove("rub", 100);
            Assert.AreEqual(0, money.GetKeys());
        }

        [TestMethod]
        public void GetMoneyTest()
        {
            Money money = new Money();
            Assert.AreEqual(0, money.GetMoney("rub"));
        }

        [TestMethod]
        public void ToStringTest()
        {
            Money money = new Money();
            money.Add("rub", 100);
            money.Add("euro", 300);
            
            Assert.AreEqual("{ 100 rub, 300 euro }", money.ToString());
        }
    }
}
