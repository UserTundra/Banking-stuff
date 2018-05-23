using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wallet;
using Moq;

namespace Test
{
    [TestClass]
    public class TestMoney
    {
        Money money;
        //Bank bank;
        //MoneyPrinterConsole console;

        [TestMethod]
        public void CreateTest()
        {            
            Assert.AreEqual(0, money.GetKeys());
        }

        [TestInitialize]
        public void TestInitialize()
        {
            var bank = new Mock<Bank>();
            bank.Setup(x => x.Convert(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<Int32>())).Returns(2);
            var console = new Mock<MoneyPrinterConsole>();
            console.Setup(x => x.Print(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>()));
            
            money = new Money(bank.Object, console.Object);
        }

        [TestMethod]
        public void AddTest()
        {
            money.Add("rub", 100);
            money.Add("euro", 300);
            Assert.AreEqual(2, money.GetKeys());
            Assert.AreEqual(100, money.GetMoney("rub"));
            Assert.AreEqual(300, money.GetMoney("euro"));
        }

        [TestMethod]
        public void AddTest2()
        {
            money.Add("rub", 100);
            money.Add("rub", 300);
            Assert.AreEqual(1, money.GetKeys());
            Assert.AreEqual(400, money.GetMoney("rub"));
        }

        [TestMethod]
        public void RemoveTest()
        {
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
            money.Add("rub", 100);
            money.Remove("rub", 500);
            Assert.Fail();
        }

        [TestMethod]
        public void RemoveTest3()
        {
            money.Add("rub", 100);
            money.Remove("rub", 100);
            Assert.AreEqual(0, money.GetKeys());
        }

        [TestMethod]
        public void GetMoneyTest()
        {
            Assert.AreEqual(0, money.GetMoney("rub"));
        }

        [TestMethod]
        public void ToStringTest()
        {
            money.Add("rub", 100);
            money.Add("euro", 300);
            
            Assert.AreEqual("{ 100 rub, 300 euro }", money.ToString());
        }

        [TestMethod]
        public void GetTotalTest()
        {
            money.Add("rub", 100);
            money.Add("euro", 300);
            Assert.AreEqual(4, money.GetTotalMoney("rub"));


        }
    }
}
